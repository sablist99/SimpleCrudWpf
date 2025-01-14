using CrudApplication.BusinessLogic;
using CrudApplication.Interface.Repository;
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
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ProjectService>();

builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
builder.Services.AddScoped<GenericService<Employee>>();

builder.Services.AddScoped<IEmployeeOnProjectRepository, EmployeeOnProjectRepository>();
builder.Services.AddScoped<EmployeeOnProjectService>();

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
