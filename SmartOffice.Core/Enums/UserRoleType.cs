namespace SmartOffice.Core.Enums
{
    /// <summary>
    /// Enumeration representing different role types for system users.
    /// Useful for Role-Based Access Control (RBAC) and feature-based authorization.
    /// </summary>
    public enum UserRoleType
    {
        Admin = 0,
        Manager = 1,
        HR = 2,
        Developer = 3,
        QA = 4,
        Support = 5,
        Employee = 6,
        Guest = 7,
        Others = 8
    }
}
