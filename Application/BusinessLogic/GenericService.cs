using CrudApplication.Interface.Repository;
using Domain.Infrastructure;

namespace CrudApplication.BusinessLogic
{
    public class GenericService<T>(IGenericRepository<T> repository) where T : Entity
    {
        protected readonly IGenericRepository<T> Repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await Repository.GetAllAsync();
        public async Task<T?> GetByIdAsync(int id) => await Repository.GetByIdAsync(id);
        public async Task AddAsync(T entity) => await Repository.AddAsync(entity);
        public async Task UpdateAsync(T entity) => await Repository.UpdateAsync(entity);
        public async Task DeleteAsync(T entity) => await Repository.DeleteAsync(entity.Id);
        public async Task SaveAsync() => await Repository.SaveAsync();
    }
}
