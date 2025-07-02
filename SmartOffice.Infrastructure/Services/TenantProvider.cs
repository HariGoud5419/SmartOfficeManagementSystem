using Microsoft.AspNetCore.Http;
using SmartOffice.Core.Interfaces;

namespace SmartOffice.Infrastructure.Services
{
    /// <summary>
    /// Default implementation of ITenantProvider.
    /// Retrieves TenantId from HTTP Headers (or Claims / Token / etc.).
    /// </summary>
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetTenantId()
        {
            var tenantId = _httpContextAccessor.HttpContext?.Request.Headers["TenantId"].FirstOrDefault();
            return tenantId ?? throw new Exception("TenantId header is missing in request.");
        }
    }
}
