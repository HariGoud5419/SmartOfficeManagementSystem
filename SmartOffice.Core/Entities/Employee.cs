using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents an employee in the Smart Office System
    /// Each employee belongs to a department and can participate in multiple teams
    /// </summary>
    public class Employee : BaseEntity
    {

        ///<summary>
        /// First Name of the employee
        /// </summary>
        [Required(ErrorMessage = "Employee First Name Is Required.")]
        [MaxLength(100)]
        public required string FirstName { get; set; }

        /// <summary>
        ///Optional: MiddleName of the Employee 
        /// </summary>
        [MaxLength(100)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Last Name (surname) of an employee
        /// </summary>
        [Required(ErrorMessage = "Employee LastName is required.")]
        [MaxLength(100)]
        public required string LastName { get; set; }

        /// <summary>
        /// Optional Salutations like Mr. , Ms., Dr., etc
        /// </summary>

        [MaxLength(20)]
        public string? Salutation { get; set; }


        /// <summary>
        /// its a Foreign Key indicating which department the employee belongs 
        /// </summary>
        [Required(ErrorMessage = "DeaprtmentId is required.")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Navigation Property: The department this employee belongs to
        /// </summary>
        public required Department Department { get; set; }
        /// <summary>
        /// Navigation Property: Teams the employee is part of (Many-to-Many)
        /// </summary>

        public ICollection<EmployeeTeam> EmployeeTeams { get; set; } = [];
        /// <summary>
        /// Navigation Property: Tasks assigned to this employee.
        /// </summary>
        public ICollection<TaskItem> Tasks { get; set; } = [];
        /// <summary>
        /// Navigation Property : Attendace records for this employee
        /// </summary>
        public ICollection<Attendance> Attendaces { get; set; } = [];
        /// <summary>
        /// Navigation Property: Leave Requests submitted by this employee
        /// </summary>
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = [];
        /// <summary>
        /// Navigation Property : Comments made by this employee on tasks.
        /// </summary>
        public ICollection<Comment> Comments { get; set; } = [];

        /// <summary>
        /// Navigation Property: Roles assigned to this employee(Many-to-Many for RBAC)
        /// </summary>
        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}