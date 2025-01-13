using Application.BusinessLogic;
using Application.Interface.Repository;
using DataAccessLayer.Context;
using DataAccessLayer.DataSeeder;
using DataAccessLayer.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Context")?.Replace("{PASSWORD}", Environment.GetEnvironmentVariable("CCTV_DB_PASSWORD"))
        ?? throw new InvalidOperationException("Connection string 'Context' not found.")));

// Register repositories and services
builder.Services.AddScoped<IGenericRepository<Project>, GenericRepository<Project>>();
builder.Services.AddScoped<GenericService<Project>>();

builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
builder.Services.AddScoped<GenericService<Employee>>();

builder.Services.AddScoped<IGenericRepository<EmployeeOnProject>, GenericRepository<EmployeeOnProject>>();
builder.Services.AddScoped<GenericService<EmployeeOnProject>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Migrate DB
    DataSeeder.Seed(dbContext);  // Add fake data
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
