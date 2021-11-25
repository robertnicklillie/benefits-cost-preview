using System.ComponentModel.DataAnnotations;

namespace benefits_cost_preview.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Range(0, 20)]
        public int DependentsCount { get; set; }
        [Required(ErrorMessage = "Please provide the percent that the employer is willing to cover")]
        [Range(0, 100)]
        public Decimal EmployerCoveragePercent { get; set; }
    }
}
