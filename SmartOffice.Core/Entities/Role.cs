using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartOffice.Core.Enums;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents a system-defined role for RBAC (Role-Based Access Control).
    /// Example roles: Admin, Manager, HR, Developer.
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// Name of the Role
        /// </summary>
        [Required(ErrorMessage = "Role Name is required.")]
        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// a small Description for each role
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; }

        /// <summary>
        /// Type of role for categorization (e.g., Admin, Manager, Developer).
        /// </summary>
        public UserRoleType RoleType { get; set; }


        /// <summary>
        /// Navigation property: Users assigned to this role.
        /// </summary>
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
