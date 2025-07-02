using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents a system-defined role for RBAC (Role-Based Access Control).
    /// Example roles: Admin, Manager, HR, Developer.
    /// </summary>
    public class Role : BaseEntity
    {
        [Required(ErrorMessage = "Role Name is required.")]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        /// <summary>
        /// Navigation property: Users assigned to this role.
        /// </summary>
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
