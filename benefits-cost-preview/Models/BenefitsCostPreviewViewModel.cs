namespace benefits_cost_preview.Models
{
    public class BenefitsCostPreviewViewModel
    {
        public Decimal TotalCostAnnual
        {
            get
            {
                return Employees.Sum(e => e.EmployerCostAnnual);
            }
        }
        public IEnumerable<EmployeeBenefitsCostViewModel> Employees { get; set; }
    }
}
