using System;
using System.ComponentModel.DataAnnotations;
using SmartOffice.Core.Enums;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents a leave request submitted by an employee.
    /// Tracks leave period, status, and remarks.
    /// </summary>
    public class LeaveRequest : BaseEntity
    {
        /// <summary>
        /// Start date of the leave.
        /// </summary>
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the leave.
        /// </summary>
        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Optional reason or remarks for the leave.
        /// </summary>
        [MaxLength(500)]
        public string? Reason { get; set; }

        /// <summary>
        /// Current approval status of the leave request.
        /// </summary>
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        /// <summary>
        /// Type of leave requested (e.g., Sick, Casual, Paid).
        /// </summary>
        public LeaveType LeaveType { get; set; } = LeaveType.CasualLeave;


        /// <summary>
        /// Foreign key: Employee who requested this leave.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Navigation property: Related employee.
        /// </summary>
        public required Employee Employee { get; set; }
    }
}
