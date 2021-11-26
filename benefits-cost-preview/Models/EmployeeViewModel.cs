using System.ComponentModel.DataAnnotations;

namespace benefits_cost_preview.Models
{
    public class EmployeeViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Please provide a first name")]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please provide a last name")]
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please provide the percent that the employer is willing to cover")]
        [Range(0, 100)]
        public Decimal? EmployerCoveragePercent { get; set; }
        public List<DependentsViewModel> Dependents { get; set; } = new List<DependentsViewModel>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dependantsValid = true;

            foreach (var dependent in Dependents)
            {
                // only check dependents whose values matter (not removed)
                if (!(dependent.Action == CRUDAction.Remove && dependent.Id == 0))
                    if (string.IsNullOrEmpty(dependent.FirstName) || !string.IsNullOrEmpty(dependent.LastName))
                        dependantsValid = false;
            }

            if (!dependantsValid)
                yield return new ValidationResult("All dependents require a first and last name", new[] { nameof(FirstName) });
        }
    }
}
