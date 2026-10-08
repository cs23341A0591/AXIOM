using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.ViewModels
{
    public class FollowUpViewModel
    {
        public int FollowUpId { get; set; }

        public int? CustomerId { get; set; }
        public int? LeadId { get; set; }

        [Required(ErrorMessage = "Follow-Up Date is required.")]
        [DataType(DataType.Date)]
        public DateTime FollowUpDate { get; set; } = DateTime.UtcNow.Date;

        [Required(ErrorMessage = "Follow-Up Type is required.")]
        public string FollowUpType { get; set; } = "Call";

        [StringLength(500, ErrorMessage = "Remarks cannot exceed 500 characters.")]
        public string? Remarks { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = "Planned";

        [Required(ErrorMessage = "Assigned User is required.")]
        public string AssignedToUserId { get; set; } = string.Empty;

        public List<SelectListItem> AvailableCustomers { get; set; } = new();
        public List<SelectListItem> AvailableLeads { get; set; } = new();
        public List<SelectListItem> AvailableUsers { get; set; } = new();
    }
}
