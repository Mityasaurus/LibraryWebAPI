using LibraryWebAPI.Domain.Entities;
using System.Collections.ObjectModel;
using LibraryWebAPI.Application.Persistence;
using LibraryWebAPI.Application.Persistence.Repositories.Book;

namespace LibraryWebAPI.Infrastructure.Persistence.Repositories.Book
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public Task<ReadOnlyCollection<BookEntity>> GetAll() =>
            Task.FromResult(_context.Books.ToList().AsReadOnly());

        public Task<BookEntity?> Get(string id) => 
            Task.FromResult(_context.Books.FirstOrDefault(b => b.Id == id));

        public Task<ReadOnlyCollection<BookEntity>> Get(Func<BookEntity, bool> predicate) => 
            Task.FromResult(_context.Books.Where(predicate).ToList().AsReadOnly());

        public Task Create(BookEntity entity)
        {
            _context.Books.Add(entity);
            return Task.CompletedTask;
        }

        public Task Update(BookEntity entity)
        {
            foreach (var b in _context.Books)
            {
                if (b.Id == entity.Id)
                { 
                    b.Title = entity.Title;
                    b.Genre = entity.Genre;
                    b.PublishedDate = entity.PublishedDate;
                    b.AuthorId = entity.AuthorId;
                }
            }
            return Task.CompletedTask;
        }

        public Task Delete(string id)
        {
            var entity = _context.Books.FirstOrDefault(b => b.Id == id);
            if (entity != null)
            {
                _context.Books.Remove(entity);
            }
            return Task.CompletedTask;
        }
    }
}
