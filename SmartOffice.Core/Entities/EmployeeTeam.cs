using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Join table representing the many-to-many relationship between Employees and Teams
    /// </summary>
    public class EmployeeTeam
    {
        /// <summary>
        /// Foreign key: Employee Id.
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Navigation Property: Related Employees
        /// </summary>
        public required Employee Employee { get; set; }
        /// <summary>
        /// Foreign Key: Team Id
        /// </summary>
        public int TeamId { get; set; }
        /// <summary>
        /// Navigation Property: Related Team
        /// </summary>
        public required Team Team { get; set; }

        /// <summary>
        /// Date when the employee joined this team.
        /// </summary>
        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Optional: Role of the employee within the team (e.g., Developer, QA, Lead).
        /// </summary>
        [MaxLength(100)]
        public string? RoleInTeam { get; set; }

        /// <summary>
        /// Whether the employee's membership in the team is currently active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Optional comments about the employee's team membership.
        /// </summary>
        [MaxLength(500)]
        public string? Comments { get; set; }

    }
}