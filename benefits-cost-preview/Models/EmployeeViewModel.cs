﻿using System.ComponentModel.DataAnnotations;

namespace benefits_cost_preview.Models
{
    public class EmployeeViewModel
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
    }
}
