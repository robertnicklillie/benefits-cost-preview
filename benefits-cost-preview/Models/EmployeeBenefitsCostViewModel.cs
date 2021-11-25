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
        public Decimal EmployerCoverageRate { get; set; }
        public Decimal EmployerCostAnnual
        {
            get
            {
                return EmployerCostPPP * 26;
            }
        }
        public Decimal EmployerCostPPP
        {
            get
            {
                return Math.Round(EmployerCoverageRate * TotalAnnual / 26, 2);
            }
        }
        public Decimal EmployeeCostAnnual
        {
            get
            {
                return EmployeeCostPPP * 26;
            }
        }
        public Decimal EmployeeCostPPP
        {
            get
            {
                return Math.Round((1 - EmployerCoverageRate) * TotalAnnual / 26, 2);
            }
        }
    }
}
