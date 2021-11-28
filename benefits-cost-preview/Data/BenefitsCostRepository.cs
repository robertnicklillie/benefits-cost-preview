using benefits_cost_preview.Data.Models;

namespace benefits_cost_preview.Data
{
    public class BenefitsCostRepository : IBenefitsCostRepository
    {
        public List<EmployeeBenefitsCostProfile> _profiles = new List<EmployeeBenefitsCostProfile>()
        {
            new EmployeeBenefitsCostProfile
            {
                EmployeeId = 1,
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
                FirstName = "Faye",
                LastName = "Adams",
                GrossPayPerPayPeriod = 2000m,
                BenefitsCostPerPayPeriod = 33.84m,
                EmployerCoverageRatio = .12m,
                EmployeeDependents = new List<EmployeeDependent> { }
            }
        };

        public async Task AddOrUpdateEmployee(EmployeeBenefitsCostProfile profile)
        {
            if (profile.EmployeeId == 0 || !_profiles.Any(p => p.EmployeeId == profile.EmployeeId))
            {
                // add new

                profile.EmployeeId = _profiles.Count + 1;

                _profiles.Add(profile);
            }
            else
            {
                // update existing

                var dataProfile = _profiles.Where(p => p.EmployeeId == profile.EmployeeId).First();

                dataProfile.FirstName = profile.FirstName;
                dataProfile.LastName = profile.LastName;
                dataProfile.GrossPayPerPayPeriod = profile.GrossPayPerPayPeriod;
                dataProfile.BenefitsCostPerPayPeriod = profile.BenefitsCostPerPayPeriod;
                dataProfile.EmployerCoverageRatio = profile.EmployerCoverageRatio;
                
                if (profile.EmployeeDependents != null && profile.EmployeeDependents.Any())
                {
                    if (dataProfile.EmployeeDependents != null) dataProfile.EmployeeDependents = null;

                    dataProfile.EmployeeDependents = profile.EmployeeDependents;
                }
            }
        }

        public async Task<List<EmployeeBenefitsCostProfile>> GetAllEmployeesBenefitsCosts()
        {
            return _profiles;
        }

        public async Task<EmployeeBenefitsCostProfile?> GetEmployeeBenefitsCost(int employeeId)
        {
            return _profiles.FirstOrDefault(e => e.EmployeeId == employeeId);
        }
    }
}
