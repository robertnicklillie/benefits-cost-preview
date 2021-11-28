using benefits_cost_preview.Data.Models;
using benefits_cost_preview.Services.Models;

namespace benefits_cost_preview.Services
{
    public interface IBenefitsCostService
    {
        public Task<IEnumerable<EmployeeBenefitsCost>> GetAllEmployeesBenefitsCosts(int companyId);

        public Task<EmployeeBenefitsCost> GetEmployeeBenefitsCost(int employeeId);
    }
}
