using Domain.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Employee : Entity
    {
        public Employee() { }

        public Employee(Employee other) 
        {
            Id = other.Id;
            Name = other.Name;
            LastName = other.LastName;
            Patronymic = other.Patronymic;
            Email = other.Email;
        }

        /// <summary>
        /// Employee name
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Employee last name
        /// </summary>
        [StringLength(256)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Employee patronymic
        /// </summary>
        [StringLength(256)]
        public string Patronymic { get; set; } = string.Empty;

        /// <summary>
        /// Employee email
        /// </summary>
        [StringLength(256)]
        public string Email { get; set; } = string.Empty;
    }
}
