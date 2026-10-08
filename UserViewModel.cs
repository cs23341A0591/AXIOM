using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AcxiomCRM.ViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } = "SalesExecutive";

        public string? ManagerId { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsLockedOut { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public List<SelectListItem> AvailableRoles { get; set; } = new();
        public List<SelectListItem> AvailableManagers { get; set; } = new();
    }

    public class RoleViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Role Name is required.")]
        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;

        public int UserCount { get; set; }
    }
}
