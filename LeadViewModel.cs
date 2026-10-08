using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.ViewModels
{
    public class LeadViewModel
    {
        public int LeadId { get; set; }

        public string LeadCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lead Name is required.")]
        [StringLength(100, ErrorMessage = "Lead Name cannot exceed 100 characters.")]
        public string LeadName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Enter a valid phone number.")]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(150)]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Lead Source is required.")]
        public string Source { get; set; } = "Web";

        [Required(ErrorMessage = "Lead Status is required.")]
        public string Status { get; set; } = "New";

        [Range(0, 1000000000, ErrorMessage = "Expected Value cannot be negative.")]
        public decimal ExpectedValue { get; set; }

        [Required(ErrorMessage = "Assigned User is required.")]
        public string AssignedToUserId { get; set; } = string.Empty;

        public List<SelectListItem> AvailableUsers { get; set; } = new();
    }

    public class LeadConversionViewModel
    {
        public int LeadId { get; set; }
        public string LeadName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? CompanyName { get; set; }

        public bool CreateOpportunity { get; set; } = true;

        [Display(Name = "Opportunity Name")]
        public string? OpportunityName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Opportunity Amount must be greater than 0.")]
        public decimal? Amount { get; set; }

        public string Stage { get; set; } = "Qualification";

        [Range(0, 100, ErrorMessage = "Probability must be between 0 and 100.")]
        public int? Probability { get; set; } = 50;

        [DataType(DataType.Date)]
        public DateTime? ExpectedCloseDate { get; set; } = DateTime.UtcNow.AddDays(30);
    }
}
