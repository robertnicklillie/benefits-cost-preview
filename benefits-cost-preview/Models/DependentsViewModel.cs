using System.ComponentModel.DataAnnotations;

namespace benefits_cost_preview.Models
{
    public class DependentsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a first name")]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please provide a last name")]
        [MaxLength(100)]
        public string? LastName { get; set; }
        public CRUDAction Action { get; set; }
    }

    public enum CRUDAction
    {
        None,
        Add,
        Remove
    }
}
