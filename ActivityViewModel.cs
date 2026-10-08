using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.ViewModels
{
    public class ActivityViewModel
    {
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "Activity Type is required.")]
        public string ActivityType { get; set; } = "Call";

        [Required(ErrorMessage = "Subject is required.")]
        [StringLength(150, ErrorMessage = "Subject cannot exceed 150 characters.")]
        public string Subject { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Activity Date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime ActivityDate { get; set; } = DateTime.UtcNow;

        public int? CustomerId { get; set; }
        public int? LeadId { get; set; }

        [Required(ErrorMessage = "Assigned User is required.")]
        public string AssignedToUserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = "Pending";

        public List<SelectListItem> AvailableCustomers { get; set; } = new();
        public List<SelectListItem> AvailableLeads { get; set; } = new();
        public List<SelectListItem> AvailableUsers { get; set; } = new();
    }
}
