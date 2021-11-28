using benefits_cost_preview.Services.Models;

namespace benefits_cost_preview.Services
{
    public interface IBenefitsCostService
    {
        public Task<IEnumerable<EmployeeBenefitsCost>> GetAllEmployeesBenefitsCosts();

        public Task<EmployeeBenefitsCostProfile> GetEmployeeBenefitsCost(int employeeId);

        public Task<EmployeeBenefitsCost> Preview(EmployeeBenefitsCostProfile profile);

        public Task AddOrUpdateEmployee(EmployeeBenefitsCostProfile profile);
    }
}
