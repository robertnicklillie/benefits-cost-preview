namespace benefits_cost_preview.Models
{
    public class BenefitsCostPreviewViewModel
    {
        public Decimal TotalCostPPP
        {
            get
            {
                return Employees.Sum(e => Math.Round(e.EmployerCostAnnual / 26, 2));
            }
        }
        public IEnumerable<EmployeeBenefitsCostViewModel> Employees { get; set; }
    }
}
