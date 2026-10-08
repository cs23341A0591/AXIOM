using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.ViewModels
{
    public class OpportunityViewModel
    {
        public int OpportunityId { get; set; }

        [Required(ErrorMessage = "Opportunity Name is required.")]
        [StringLength(150, ErrorMessage = "Opportunity Name cannot exceed 150 characters.")]
        public string OpportunityName { get; set; } = string.Empty;

        public int? CustomerId { get; set; }
        public int? LeadId { get; set; }

        [Required(ErrorMessage = "Opportunity Amount is required.")]
        [Range(0.01, 1000000000.00, ErrorMessage = "Opportunity Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Stage is required.")]
        public string Stage { get; set; } = "Qualification";

        [Required(ErrorMessage = "Probability is required.")]
        [Range(0, 100, ErrorMessage = "Probability must be between 0 and 100.")]
        public int Probability { get; set; } = 50;

        [Required(ErrorMessage = "Expected Close Date is required.")]
        [DataType(DataType.Date)]
        public DateTime ExpectedCloseDate { get; set; } = DateTime.UtcNow.AddDays(30);

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = "Active";

        [Required(ErrorMessage = "Assigned User is required.")]
        public string AssignedToUserId { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Notes { get; set; }

        public List<SelectListItem> AvailableCustomers { get; set; } = new();
        public List<SelectListItem> AvailableLeads { get; set; } = new();
        public List<SelectListItem> AvailableUsers { get; set; } = new();
    }
}
