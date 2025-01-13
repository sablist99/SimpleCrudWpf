using System.ComponentModel.DataAnnotations;

namespace Domain.Infrastructure
{
    public abstract class Entity
    {
        /// <summary>
        /// Unique record identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        public override bool Equals(object? other) => (other as Entity)?.Id == Id;
        public override int GetHashCode() => Id.GetHashCode();
    }
}
