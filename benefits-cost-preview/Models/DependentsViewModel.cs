using System.ComponentModel.DataAnnotations;

namespace benefits_cost_preview.Models
{
    public class DependentsViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
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
