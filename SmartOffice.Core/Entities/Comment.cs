using System.ComponentModel.DataAnnotations;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents a comment made by an employee on a task.
    /// Used for task discussions, clarifications, or status updates.
    /// </summary>
    public class Comment : BaseEntity
    {
        /// <summary>
        /// Text content of the comment.
        /// </summary>
        [Required(ErrorMessage = "Comment text is required.")]
        [MaxLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
        public required string Text { get; set; }

        /// <summary>
        /// Foreign key: Task to which this comment belongs.
        /// </summary>
        public int TaskItemId { get; set; }

        /// <summary>
        /// Navigation property: Related TaskItem.
        /// </summary>
        public TaskItem? TaskItem { get; set; }

        /// <summary>
        /// Foreign key: Employee who made the comment.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Navigation property: The employee who posted this comment.
        /// </summary>
        public Employee? Employee { get; set; }
    }
}
