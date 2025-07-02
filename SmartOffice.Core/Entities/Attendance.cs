using System;
using System.ComponentModel.DataAnnotations;
using SmartOffice.Core.Enums;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents daily attendance record for an employee.
    /// Tracks check-in and check-out times.
    /// </summary>
    public class Attendance : BaseEntity
    {
        /// <summary>
        /// Date of attendance (without time component).
        /// </summary>
        [Required(ErrorMessage = "Attendance date is required.")]
        public DateTime AttendanceDate { get; set; }

        /// <summary>
        /// Check-in time for the day.
        /// </summary>
        public DateTime? CheckInTime { get; set; }

        /// <summary>
        /// Check-out time for the day.
        /// </summary>
        public DateTime? CheckOutTime { get; set; }

        /// <summary>
        /// Foreign key: Employee to whom this attendance belongs.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Navigation property: Related employee.
        /// </summary>
        public required Employee Employee { get; set; }

        /// <summary>
        /// Optional: Status for the day (e.g., Present, Absent, OnLeave).
        /// </summary>
        public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
    }
}
