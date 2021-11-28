using benefits_cost_preview.Data;
using benefits_cost_preview.Data.Models;
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

        public async Task<IEnumerable<EmployeeBenefitsCost>> GetAllEmployeesBenefitsCosts(int companyId)
        {
            var allEmployeeCosts = await _benefitsCostRepository.GetAllEmployeesBenefitsCosts(companyId);

            return allEmployeeCosts.Select(e => CalculateBenefitsCost(e));
        }

        public async Task<EmployeeBenefitsCost> GetEmployeeBenefitsCost(int employeeId)
        {
            var employeeBenefitsCost = await _benefitsCostRepository.GetEmployeeBenefitsCost(employeeId);

            return CalculateBenefitsCost(employeeBenefitsCost);
        }

        private EmployeeBenefitsCost CalculateBenefitsCost(EmployeeBenefitsCostProfile profile)
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
