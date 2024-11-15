using LibraryWebAPI.Domain.Entities;
using System.Collections.ObjectModel;

namespace LibraryWebAPI.Application.Persistence.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<ReadOnlyCollection<T>> GetAll();
        public Task<T?> Get(string id);
        public Task<ReadOnlyCollection<T>> Get(Func<T, bool> predicate);
        public Task Create(T entity);
        public Task Update(T entity);
        public Task Delete(string id);
    }
}
