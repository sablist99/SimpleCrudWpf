using DataAccessLayer.Context;
using Domain.Model;

namespace DataAccessLayer.DataSeeder
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Employees.Any() || context.Projects.Any())
                return;

            var employees = new[]
            {
                new Employee { Name = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Employee { Name = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
            };

            var projects = new[]
            {
                new Project
                {
                    Title = "Project A",
                    Customer = "Customer A",
                    Performer = "Performer A",
                    StartDate = DateTime.UtcNow.AddDays(-10),
                    EndDate = DateTime.UtcNow.AddMonths(1),
                    Priority = 1,
                    SupervisorId = 1
                },
                new Project
                {
                    Title = "Project B",
                    Customer = "Customer B",
                    Performer = "Performer B",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(2),
                    Priority = 2,
                    SupervisorId = 2
                }
            };

            context.Employees.AddRange(employees);
            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}
