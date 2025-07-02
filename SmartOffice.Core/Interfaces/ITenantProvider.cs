namespace SmartOffice.Core.Interfaces
{
    /// <summary>
    /// Provides current tenant context per request.
    /// Used for resolving tenant-specific configurations.
    /// </summary>
    public interface ITenantProvider
    {
        string GetTenantId();
    }
}
