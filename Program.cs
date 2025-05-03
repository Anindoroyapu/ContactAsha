using ContactFormApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
//builder.Services.AddDbContext<AppDbContext>(options =>
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConString")));

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5050;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(); // Opens Swagger at /swagger

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
