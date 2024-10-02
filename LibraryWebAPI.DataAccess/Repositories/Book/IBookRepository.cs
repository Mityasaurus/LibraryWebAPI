using LibraryWebAPI.DataAccess.Entities;
using System.Collections.ObjectModel;

namespace LibraryWebAPI.DataAccess.Repositories.Book
{
    public interface IBookRepository : IRepository<BookEntity>
    {
        public Task<ReadOnlyCollection<BookEntity>> GetAll();
        public Task<BookEntity?> Get(string id);
        public Task<ReadOnlyCollection<BookEntity>> Get(Func<BookEntity, bool> predicate);
        public Task Create(BookEntity entity);
        public Task Update(BookEntity entity);
        public Task Delete(string id);
    }
}
