using Domain.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class EmployeeOnProject : Entity
    {
        /// <summary>
        /// Employee assigned to the project
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Employee assigned to the project
        /// </summary>
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee? Employee { get; set; }

        /// <summary>
        /// The project to which the employee is assigned
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The project to which the employee is assigned
        /// </summary>
        [ForeignKey(nameof(ProjectId))]
        public virtual Project? Project { get; set; }
    }
}
