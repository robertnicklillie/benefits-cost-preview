using benefits_cost_preview.Data.Models;

namespace benefits_cost_preview.Data
{
    public class BenefitsCostRepository : IBenefitsCostRepository
    {
        private List<EmployeeBenefitsCostProfile> employeeBenefitCosts = new List<EmployeeBenefitsCostProfile>()
        {
            new EmployeeBenefitsCostProfile
            {
                EmployeeId = 1,
                CompanyId = 1234,
                FirstName = "Archie",
                LastName = "Osborne",
                GrossPayPerPayPeriod = 2000m,
                BenefitsCostPerPayPeriod = 57.12m,
                EmployerCoverageRatio = .34m,
                EmployeeDependents = new List<EmployeeDependent>
                {
                    new EmployeeDependent
                    {
                        FirstName = "Angie",
                        LastName = "Osborne"
                    },
                    new EmployeeDependent
                    {
                        FirstName = "Devin",
                        LastName = "Osborne"
                    },
                    new EmployeeDependent
                    {
                        FirstName = "Craig",
                        LastName = "Osborne"
                    }
                }
            },
            new EmployeeBenefitsCostProfile
            {
                EmployeeId = 2,
                CompanyId = 1234,
                FirstName = "Kristian",
                LastName = "Willis",
                GrossPayPerPayPeriod = 2000m,
                BenefitsCostPerPayPeriod = 67.31m,
                EmployerCoverageRatio = .5m,
                EmployeeDependents = new List<EmployeeDependent>
                {
                    new EmployeeDependent
                    {
                        FirstName = "Roxanne",
                        LastName = "Willis"
                    },
                    new EmployeeDependent
                    {
                        FirstName = "Millie",
                        LastName = "Willis"
                    },
                    new EmployeeDependent
                    {
                        FirstName = "John",
                        LastName = "Willis"
                    },
                    new EmployeeDependent
                    {
                        FirstName = "Sarah",
                        LastName = "Willis"
                    },
                    new EmployeeDependent
                    {
                        FirstName = "Jeffrie",
                        LastName = "Willis"
                    }
                }
            },
            new EmployeeBenefitsCostProfile
            {
                EmployeeId = 3,
                CompanyId = 1234,
                FirstName = "Faye",
                LastName = "Adams",
                GrossPayPerPayPeriod = 2000m,
                BenefitsCostPerPayPeriod = 33.84m,
                EmployerCoverageRatio = .12m,
                EmployeeDependents = new List<EmployeeDependent> { }
            }
        };

        public async Task<List<EmployeeBenefitsCostProfile>> GetAllEmployeesBenefitsCosts(int companyId)
        {
            return employeeBenefitCosts.Where(e => e.CompanyId == companyId).ToList();
        }

        public async Task<EmployeeBenefitsCostProfile?> GetEmployeeBenefitsCost(int employeeId)
        {
            return employeeBenefitCosts.FirstOrDefault(e => e.EmployeeId == employeeId);
        }
    }
}
