using benefits_cost_preview.Data;
using benefits_cost_preview.Services.Models;

namespace benefits_cost_preview.Services
{
    public class BenefitsCostService : IBenefitsCostService
    {
        private IBenefitsCostRepository _benefitsCostRepository;

        // this really should be a configuration item that changes dependent on when the benefits plan changes (with appropriate mechanisms for historical persistence)

        public BenefitsCostService(IBenefitsCostRepository benefitsCostRepository)
        {
            _benefitsCostRepository = benefitsCostRepository;
        }

        public async Task AddOrUpdateEmployee(EmployeeBenefitsCostProfile profile)
        {
            var dataProfile = new Data.Models.EmployeeBenefitsCostProfile
            {
                EmployeeId = profile.EmployeeId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                EmployerCoverageRatio = profile.EmployerCoverageRatio,
                BenefitsCostPerPayPeriod = profile.BenefitsCostPerPayPeriod
            };

            if (profile.EmployeeDependents != null && profile.EmployeeDependents.Any())
            {
                dataProfile.EmployeeDependents = profile.EmployeeDependents.Select(d => new Data.Models.EmployeeDependent
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName
                }).ToList();
            }

            await _benefitsCostRepository.AddOrUpdateEmployee(dataProfile);
        }

        public async Task<IEnumerable<EmployeeBenefitsCost>> GetAllEmployeesBenefitsCosts()
        {
            var allEmployeeCosts = await _benefitsCostRepository.GetAllEmployeesBenefitsCosts();

            return allEmployeeCosts.Select(e => CalculateBenefitsCost(e));
        }

        public async Task<EmployeeBenefitsCostProfile> GetEmployeeBenefitsCost(int employeeId)
        {
            var dataProfile = await _benefitsCostRepository.GetEmployeeBenefitsCost(employeeId);

            if (dataProfile == null) throw new ArgumentException($"Could not find employee with employee id {employeeId}");

            var serviceProfile = new EmployeeBenefitsCostProfile
            {
                EmployeeId = dataProfile.EmployeeId,
                FirstName = dataProfile.FirstName,
                LastName = dataProfile.LastName,
                BenefitsCostPerPayPeriod = dataProfile.BenefitsCostPerPayPeriod,
                EmployerCoverageRatio = dataProfile.EmployerCoverageRatio,
                GrossPayPerPayPeriod = dataProfile.GrossPayPerPayPeriod
            };

            if (dataProfile.EmployeeDependents != null && dataProfile.EmployeeDependents.Any())
            {
                serviceProfile.EmployeeDependents = dataProfile.EmployeeDependents.Select(d => new EmployeeDependentProfile
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName
                }).ToList();
            }

            return serviceProfile;
        }

        public Task<EmployeeBenefitsCost> Preview(EmployeeBenefitsCostProfile profile)
        {
            throw new NotImplementedException();
        }

        private EmployeeBenefitsCost CalculateBenefitsCost(Data.Models.EmployeeBenefitsCostProfile profile)
        {
            // steps to determine what the costs are include:
            // 1) determine self cost
            // 2) determine dependent cost
            // 3) determine discount (if employee or dependents have name beginning with a)
            // 4) determine ratio that the employer will cover and thereby the portion that the employee will cover

            var totalAnnualCost = 0.0m;

            // 1:

            var selfCost = BenefitsCostCalculationContext.SelfCost;

            // 2:
            var dependentsCount = profile.EmployeeDependents?.Count ?? 0;

            var dependentsCost = dependentsCount * BenefitsCostCalculationContext.DependentsCost;

            // 3:

            var names = new List<string> { { profile.FirstName ?? string.Empty }, { profile.LastName ?? string.Empty } };
            if (profile.EmployeeDependents != null && profile.EmployeeDependents.Any())
            {
                names.AddRange(profile.EmployeeDependents.Select(d => d.FirstName));
                names.AddRange(profile.EmployeeDependents.Select(d => d.LastName));
            }
            
            var discount = CalculateDiscount(names, selfCost + dependentsCost);

            // 4:

            totalAnnualCost = selfCost + dependentsCost - discount;

            var employerBenefitsCostPerYear = Math.Round(totalAnnualCost * profile.EmployerCoverageRatio, 2);
            var employeeBenefitsCostPerYear = totalAnnualCost - employerBenefitsCostPerYear;

            return new EmployeeBenefitsCost
            {
                EmployeeId = profile.EmployeeId,
                EmployeeName = $"{profile.FirstName} {profile.LastName}",
                SelfCostAnnual = selfCost,
                DependentsCostAnnual = dependentsCost,
                DependentsCount = dependentsCount,
                DiscountAnnual = discount,
                EmployerCoverageRate = profile.EmployerCoverageRatio
            };
        }

        private decimal CalculateDiscount(List<string> names, decimal cost)
        {
            var discount = 0.0m;

            foreach (var name in names)
            {
                if ((!string.IsNullOrEmpty(name) && BenefitsCostCalculationContext.DiscountCriteria.Invoke(name))
                    || (!string.IsNullOrEmpty(name) && BenefitsCostCalculationContext.DiscountCriteria.Invoke(name)))
                {
                    discount = cost * BenefitsCostCalculationContext.DiscountRatio;
                    break;
                }   
            }

            return discount;
        }
    }

    public static class BenefitsCostCalculationContext
    {
        public static decimal SelfCost = 1000m;
        public static decimal DependentsCost = 500m;
        public static decimal DiscountRatio = .1m;
        public static Predicate<string> DiscountCriteria = (string name) => name.StartsWith("a", StringComparison.InvariantCultureIgnoreCase);
    }
}
