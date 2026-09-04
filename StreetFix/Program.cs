using Microsoft.EntityFrameworkCore;
using StreetFix.Data;
using StreetFix.Services.Interfaces;
using StreetFix.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


// Add services to the container.
builder.Services.AddScoped<IReportServices, ReportServices>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();