using benefits_cost_preview.Data.Models;

namespace benefits_cost_preview.Data
{
    public interface IBenefitsCostRepository
    {
        public Task<List<EmployeeBenefitsCostProfile>> GetAllEmployeesBenefitsCosts();

        public Task<EmployeeBenefitsCostProfile?> GetEmployeeBenefitsCost(int employeeId);

        public Task AddOrUpdateEmployee(EmployeeBenefitsCostProfile profile);
    }
}
