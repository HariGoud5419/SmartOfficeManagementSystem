using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartOffice.Core.Enums;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents a team within the Smart Office system.
    /// Employees can belong to multiple teams (Many-to-Many relationship).
    /// </summary>
    public class Team : BaseEntity
    {
        /// <summary>
        /// Name of the Team (e.g., "Product Development", "QA Team")
        /// </summary>
        [Required(ErrorMessage = "Team Name is required.")]
        [MaxLength(100)]
        public required string Name { get; set; }
        /// <summary>
        /// Optional Description of the team
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; } = null;
        /// <summary>
        /// Optional: The EmployeeId of the team lead (manager of this team).
        /// </summary>
        public int? TeamLeadId { get; set; }
        public Employee? TeamLead { get; set; }

        /// <summary>
        /// Optional: For hierarchical team structures (e.g., Sub-teams).
        /// </summary>
        public int? ParentTeamId { get; set; }
        public Team? ParentTeam { get; set; }

        /// <summary>
        /// Enum indicating the type of team (e.g., Development, QA).
        /// </summary>
        public TeamType? TeamType { get; set; }
        /// <summary>
        /// Whether the team is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Navigation Property: List of EmployeeTeam mapping entities representing 
        /// employees in this team.
        /// </summary>
        public required ICollection<EmployeeTeam> EmployeeTeams { get; set; }
    }
}
