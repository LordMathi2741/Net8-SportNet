using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SportnetApi.Booking.Application.Internal.CommandServices;
using SportnetApi.Booking.Application.Internal.QueryServices;
using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Booking.Domain.Repositories;
using SportnetApi.Booking.Domain.Services;
using SportnetApi.Booking.Infrastructure.Persistence.EFC.Repositories;
using SportnetApi.Shared.Domain.Repositories;
using SportnetApi.Shared.Infrastructure.Interfaces.ASP.Configuration;
using SportnetApi.Shared.Infrastructure.Persistence.EFC.Configuration;
using SportnetApi.Shared.Infrastructure.Persistence.EFC.Repositories;
using SportnetApi.Shared.Interface.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "SportNet API",
                Version = "v1",
                Description = "SportNet API",
                TermsOfService = new Uri("https://sportnet.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "SportNet.com",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Publishing Bounded Context Injection Configuration
builder.Services.AddScoped<ISportEventRepository, SportEventRepository>();
builder.Services.AddScoped<ISportEventCommandService, SportEventCommandService>();
builder.Services.AddScoped<ISportEventQueryService, SportEventQueryService>();
// configure lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Add authorization middleware to pipeline
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();