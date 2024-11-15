using LibraryWebAPI.Domain.Entities;
using System.Collections.ObjectModel;
using LibraryWebAPI.Application.Persistence;
using LibraryWebAPI.Application.Persistence.Repositories.Author;

namespace LibraryWebAPI.Infrastructure.Persistence.Repositories.Author
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public Task<ReadOnlyCollection<AuthorEntity>> GetAll() => 
            Task.FromResult(_context.Authors.ToList().AsReadOnly());

        public Task<AuthorEntity?> Get(string id) =>
            Task.FromResult(_context.Authors.FirstOrDefault(a => a.Id == id));

        public Task<ReadOnlyCollection<AuthorEntity>> Get(Func<AuthorEntity, bool> predicate) => 
            Task.FromResult(_context.Authors.Where(predicate).ToList().AsReadOnly());

        public Task Create(AuthorEntity entity)
        {
            _context.Authors.Add(entity);
            return Task.CompletedTask;
        }

        public Task Update(AuthorEntity entity)
        {
            foreach (var a in _context.Authors)
            {
                if(a.Id == entity.Id)
                {
                    a.Name = entity.Name;
                    a.Lastname = entity.Lastname;
                }
            }
            return Task.CompletedTask;
        }

        public Task Delete(string id)
        {
            var entity = _context.Authors.FirstOrDefault(a => a.Id == id);
            if(entity != null)
            {
                _context.Authors.Remove(entity);
            }
            return Task.CompletedTask;
        }
    }
}
