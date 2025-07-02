using System.ComponentModel.DataAnnotations;

namespace SmartOffice.Core.Entities
{
    /// <summary>
    /// Represents a tenant (client company) in a multi-tenant Smart Office system.
    /// Each tenant has its own database connection.
    /// </summary>
    public class Tenant : BaseEntity
    {
        [Required(ErrorMessage = "Tenant Name is required.")]
        [MaxLength(150)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Connection string is required.")]
        [MaxLength(1000)]
        public required string ConnectionString { get; set; }

        /// <summary>
        /// Whether this tenant is active and allowed to access the system.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Optional contact person for the tenant.
        /// </summary>
        [MaxLength(100)]
        public string? AdminContactPerson { get; set; }

        /// <summary>
        /// Optional contact email for the tenant. Must be a valid email format.
        /// </summary>
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? AdminEmail { get; set; }

    }
}
