using ContactFormApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Database connection string configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConString"))
);

// Enable HTTPS redirection
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5050; // Define the port for HTTPS
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(); // Opens Swagger at /swagger

// HTTPS redirection middleware
app.UseHttpsRedirection();

// Enable authorization (if needed for your API)
app.UseAuthorization();

// Map controller routes
app.MapControllers();

app.Run();
