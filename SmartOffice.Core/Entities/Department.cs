using System;
using System.ComponentModel.DataAnnotations;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents a department within in the SmartOfficeManagementSystem.
    /// Each department can have multiple employees.
    /// </summary>
    public class Department : BaseEntity
    {
        /// <summary>
        /// Name of the Deapartment (e.g.IT, HR, Finance)
        /// </summary>
        [Required]
        [MaxLength(100, ErrorMessage = "Department Name cannot exceed 100 chartacters.")]
        public required string Name { get; set; }

        /// <summary>
        /// Optional Description provided more details about the department
        /// </summary>

        [MaxLength(250, ErrorMessage = "Description cannot exceed more than 250 characters")]
        public string Description { get; set; } = "";

        /// <summary>
        /// Navigation Property: List of employees assigned to this department.
        /// one department -> Many employees (one to Many relationship)
        /// </summary>
        public ICollection<Employee> Employees { get; set; } = [];
    }
}