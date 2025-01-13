using Domain.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class Project : Entity
    {
        /// <summary>
        /// Project name
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Name of the customer company
        /// </summary>
        [StringLength(256)]
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Name of the performer company
        /// </summary>
        [StringLength(256)]
        public string Performer { get; set; } = string.Empty;

        /// <summary>
        /// Project start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Project end date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Project Priority (Numeric Value) 
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Project Manager
        /// </summary>
        public int SupervisorId { get; set; }

        /// <summary>
        /// Project Manager
        /// </summary>
        [ForeignKey(nameof(SupervisorId))]
        public virtual Employee? Supervisor { get; set; }
    }
}
