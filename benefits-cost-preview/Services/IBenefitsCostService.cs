using benefits_cost_preview.Services.Models;

namespace benefits_cost_preview.Services
{
    public interface IBenefitsCostService
    {
        public Task<IEnumerable<EmployeeBenefitsCost>> GetAllEmployeesBenefitsCosts(int companyId);

        public Task<EmployeeBenefitsCostProfile> GetEmployeeBenefitsCost(int employeeId);
    }
}
