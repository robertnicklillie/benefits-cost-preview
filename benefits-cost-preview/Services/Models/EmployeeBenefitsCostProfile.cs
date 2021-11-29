namespace benefits_cost_preview.Services.Models
{
    public class EmployeeBenefitsCostProfile
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<EmployeeDependentProfile> EmployeeDependents { get; set; } = new List<EmployeeDependentProfile>();
        public decimal EmployerCoverageRatio { get; set; }
        public decimal GrossPayPerPayPeriod { get; set; } = 2000.00m;
        public decimal BenefitsCostPerPayPeriod { get; set; }
    }
}
