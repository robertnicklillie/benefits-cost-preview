namespace benefits_cost_preview.Services.Models
{
    public class EmployeeBenefitsCostPreview
    {
        public decimal EmployeeGrossPerPayPeriod { get; set; }
        public decimal EmployeeCostPerPayPeriod { get; set; }
        public decimal EmployeeNetPerPayPeriod { get { return EmployeeGrossPerPayPeriod - EmployeeCostPerPayPeriod; } }
        public bool CanCalculate { get; set; }
    }
}
