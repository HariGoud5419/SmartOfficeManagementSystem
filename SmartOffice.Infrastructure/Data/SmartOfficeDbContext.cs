using Microsoft.EntityFrameworkCore;
using SmartOffice.Core.Entities;

namespace SmartOffice.Infrastructure.Data
{
    /// <summary>
    /// Main DbContext for Smart Office Management System
    /// Handles all entity mappings and is multi-tenant ready
    /// </summary>
    public class SmartOfficeDbContext(DbContextOptions<SmartOfficeDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Create Data tables for each core entity by using Ef' DbSet
        /// </summary>
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<EmployeeTeam> EmployeeTeams => Set<EmployeeTeam>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Attachment> Attachments => Set<Attachment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Keys for Join Tables
            modelBuilder.Entity<EmployeeTeam>()
                .HasKey(et => new { et.EmployeeId, et.TeamId });

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.EmployeeId, ur.RoleId });

            // Optional: Enum to String mapping for TaskStatus and TaskPriority
            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Status)
                .HasConversion<string>();

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Priority)
                .HasConversion<string>();

            modelBuilder.Entity<LeaveRequest>()
                .Property(l => l.Status)
                .HasConversion<string>();

            modelBuilder.Entity<LeaveRequest>()
                .Property(l => l.LeaveType)
                .HasConversion<string>();
        }

    }
}