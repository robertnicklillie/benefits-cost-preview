using benefits_cost_preview.Data.Models;

namespace benefits_cost_preview.Data
{
    public interface IBenefitsCostRepository
    {
        public Task<List<EmployeeBenefitsCostProfile>> GetAllEmployeesBenefitsCosts(int companyId);

        public Task<EmployeeBenefitsCostProfile?> GetEmployeeBenefitsCost(int employeeId);
    }
}
