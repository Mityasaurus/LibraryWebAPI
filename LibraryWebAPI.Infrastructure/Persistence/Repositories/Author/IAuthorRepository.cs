using LibraryWebAPI.Domain.Entities;
using System.Collections.ObjectModel;

namespace LibraryWebAPI.Infrastructure.Persistence.Repositories.Author
{
    public interface IAuthorRepository : IRepository<AuthorEntity>
    {
        public Task<ReadOnlyCollection<AuthorEntity>> GetAll();
        public Task<AuthorEntity?> Get(string id);
        public Task<ReadOnlyCollection<AuthorEntity>> Get(Func<AuthorEntity, bool> predicate);
        public Task Create(AuthorEntity entity);
        public Task Update(AuthorEntity entity);
        public Task Delete(string id);
    }
}
