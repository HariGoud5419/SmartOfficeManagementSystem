
using Microsoft.EntityFrameworkCore;
using SmartOffice.Infrastructure.Data;
using SmartOffice.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


//----------------------------------------------------------
// Configure Services (Dependency Injection Container)
//----------------------------------------------------------

// Add SmartOffice infrastructure services (TenantProvider, TenantService, etc.)
builder.Services.AddSmartOfficeInfrastructure();

// Register DbContext
builder.Services.AddDbContext<SmartOfficeDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Add Controllers (for API endpoints)
builder.Services.AddControllers();
// Optional: Enable API Explorer (for Swagger)
builder.Services.AddEndpointsApiExplorer();
// Optional: Add Swagger/OpenAPI Generator
builder.Services.AddSwaggerGen();

var app = builder.Build();

//----------------------------------------------------------
// Configure HTTP Request Pipeline (Middleware Pipeline)
//----------------------------------------------------------

// Enable Swagger UI and JSON endpoint during Development mode

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Optional: Enable HTTPS Redirection (forces API calls over HTTPS)
app.UseHttpsRedirection();

// Optional: Enable Authorization Middleware (JWT will hook here later)
app.UseAuthorization();

//  Map Controller endpoints
app.MapControllers();

// Run the Web Application
app.Run();