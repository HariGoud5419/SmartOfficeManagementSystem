using System;
using System.ComponentModel.DataAnnotations;

namespace SmartOffice.Core.Entities
{
    ///<summary>
    /// Base Entity classs providing common properities for all entities in the SmartOfficeManagementSystem
    /// Includes auditiong fields for tracking creation and modification details
    /// </summary>
    public abstract class BaseEntity
    {
        ///<summary>
        /// Primary key for the entity
        /// </summary>
        /// 
        [Key]
        public int Id { get; set; }

        ///<summary>
        /// TimeStamp Indicating when the entity was created
        /// Automatically set when the entity is instantiated.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Timestamp indicating when the entity was last modified
        /// Nullable because the entity may never be modified after creation
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Optional : Username or identifier for who created the entity
        /// which is useful for auditing and tracking purposes
        /// </summary>

        [MaxLength(100)]
        public string? CreatedBy { get; set; }
        /// <summary>
        /// optional : Username or identifier for who last modified the entity
        /// Useful for auditing and tracking purposes.
        /// </summary>

        [MaxLength(100)]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Soft delete flag. True if the entity is marked as deleted but not physically removed from the database.
        /// </summary>
        public bool IsDeleted { get; set; } = false;

    }
}