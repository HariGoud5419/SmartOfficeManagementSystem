using System;
using System.ComponentModel.DataAnnotations;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Join table representing the many-to-many relationship between Employees and Roles.
    /// Supports role assignment metadata.
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// Foreign key: Employee.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Navigation property: Related Employee.
        /// </summary>
        public required Employee Employee { get; set; }

        /// <summary>
        /// Foreign key: Role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Navigation property: Related Role.
        /// </summary>
        public required Role Role { get; set; }

        /// <summary>
        /// Date when the role was assigned.
        /// </summary>
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Whether this role assignment is currently active.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
