using Microsoft.EntityFrameworkCore;
using StreetFix.Data;
using StreetFix.Services.Interfaces;
using StreetFix.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Services
builder.Services.AddScoped<IReportServices, ReportServices>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen();


var app = builder.Build();


// ===============================
// Seed Database
// ===============================
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();

    SeedData.Initialize(context);
}


// ===============================
// Middleware
// ===============================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Frontend");

app.MapControllers();

app.Run();