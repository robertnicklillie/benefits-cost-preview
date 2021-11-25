namespace benefits_cost_preview.Models
{
    public class EmployeeBenefitsCostViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Decimal SelfCostAnnual { get; set; }
        public Decimal DependentsCostAnnual { get; set; }
        public int DependentsCount { get; set; }
        public Decimal DiscountAnnual { get; set; }
        public Decimal TotalAnnual
        {
            get
            {
                return SelfCostAnnual + DependentsCostAnnual - DiscountAnnual;
            }
        }
        public Decimal EmployerCostRate { get; set; }
        public Decimal EmployerCostAnnual
        {
            get
            {
                return (EmployerCostRate * TotalAnnual);
            }
        }
        public Decimal EmployeeCostAnnual
        {
            get
            {
                return ((1 - EmployerCostRate) * TotalAnnual);
            }
        }
    }
}
