using ContactFormApi.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=51.79.229.154;port=3306;Database=ashastd24_ashastd;User=ashastd24;Password=T%va(oyL[anE";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    try
    {
        // For MySQL
        // options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        options.EnableSensitiveDataLogging(true); // Enable sensitive data logging
    }
    catch(Exception ex)
    {

        Console.WriteLine("+++++++++++++++++++++++++++++...");
        Console.WriteLine(ex.Message);
    }
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();