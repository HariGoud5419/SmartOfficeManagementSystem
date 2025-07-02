using System;
using System.ComponentModel.DataAnnotations;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents an attachment (file) associated with a task.
    /// Includes metadata like file name, size, and uploaded by information.
    /// </summary>
    public class Attachment : BaseEntity
    {
        /// <summary>
        /// Name of the uploaded file.
        /// </summary>
        [Required(ErrorMessage = "File Name is required.")]
        [MaxLength(255)]
        public required string FileName { get; set; }

        /// <summary>
        /// Full path or URL where the file is stored.
        /// </summary>
        [Required(ErrorMessage = "File path is required.")]
        [MaxLength(500)]
        public required string FilePath { get; set; }

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        public long FileSizeInBytes { get; set; }

        /// <summary>
        /// MIME type or file content type (e.g., application/pdf, image/png).
        /// </summary>
        [MaxLength(100)]
        public string? ContentType { get; set; }

        /// <summary>
        /// Foreign key: TaskItem to which this attachment belongs.
        /// </summary>
        public int TaskItemId { get; set; }

        /// <summary>
        /// Navigation property: Related TaskItem.
        /// </summary>
        public TaskItem? TaskItem { get; set; }

        /// <summary>
        /// Foreign key: Employee who uploaded this file.
        /// </summary>
        public int UploadedByEmployeeId { get; set; }

        /// <summary>
        /// Navigation property: The employee who uploaded this attachment.
        /// </summary>
        public required Employee UploadedByEmployee { get; set; }
    }
}
