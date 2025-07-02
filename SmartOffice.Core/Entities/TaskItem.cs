using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using SmartOffice.Core.Enums;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents a task assigned to an employee within the Smart Office system.
    /// Supports status tracking, due dates, attachments, and comments.
    /// </summary>
    public class TaskItem : BaseEntity
    {
        /// <summary>
        /// Title or short Description of the Task
        /// </summary>
        [Required(ErrorMessage = "Task Title is required ")]
        [MaxLength(200)]
        public required string Title { get; set; }
        /// <summary>
        /// Detailed Description or instruction about the Task
        /// </summary>
        public string? Description { get; set; } = null;
        /// <summary>
        /// Optional: Parent task ID for task dependency or sub-task scenario.
        /// </summary>
        public int? ParentTaskId { get; set; }

        /// <summary>
        /// Navigation property: Parent Task (for sub-task scenarios).
        /// </summary>
        public TaskItem? ParentTask { get; set; }

        /// <summary>
        /// The due date by which the task should be completed
        /// </summary>

        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Current Status of the task 
        /// </summary>

        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.NotStarted;
        /// <summary>
        /// Priority level of the task (e.g., Low, Medium, High, Critical).
        /// </summary>
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        /// <summary>
        /// Foreign Key: Employee to whom this task is assigned 
        /// </summary>
        public int AssignedEmployeeId { get; set; }

        /// <summary>
        /// Navigation Property : The Employee assigned to this task
        /// </summary>
        public required Employee AssignedEmployee { get; set; }

        /// <summary>
        /// Navigation Property : Attachments related to this task
        /// </summary>

        public ICollection<Attachment>? Attachments { get; set; } = [];

        /// <summary>
        /// Navigation Property: Comments added to this task
        /// </summary>

        public ICollection<Comment>? Comments { get; set; } = [];

        /// <summary>
        /// Navigation property: List of sub-tasks dependent on this task.
        /// </summary>
        public ICollection<TaskItem> SubTasks { get; set; } = [];

    }
}
