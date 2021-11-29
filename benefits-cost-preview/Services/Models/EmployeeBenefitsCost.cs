namespace benefits_cost_preview.Services.Models
{
    public class EmployeeBenefitsCost
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public decimal SelfCostAnnual { get; set; }
        public decimal DependentsCostAnnual { get; set; }
        public int DependentsCount { get; set; }
        public decimal DiscountAnnual { get; set; }
        public decimal EmployerCoverageRate { get; set; }
        public decimal EmployeeCostPerPayPeriod { get; set; }
    }
}
