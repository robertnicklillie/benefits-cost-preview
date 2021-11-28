namespace benefits_cost_preview.Services.Models
{
    public class EmployeeBenefitsCostProfile
    {
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<EmployeeDependentProfile>? EmployeeDependents { get; set; }
        public decimal EmployerCoverageRatio { get; set; }
        public decimal GrossPayPerPayPeriod { get; set; }
        public decimal BenefitsCostPerPayPeriod { get; set; }
    }
}
