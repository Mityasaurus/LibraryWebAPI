using LibraryWebAPI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebAPI.DataAccess.Repositories.Author
{
    public interface IAuthorRepository
    {
        public Task<ReadOnlyCollection<AuthorEntity>> GetAll();
        public Task<AuthorEntity?> Get(string id);
        public Task<ReadOnlyCollection<AuthorEntity>> Get(Func<AuthorEntity, bool> predicate);
        public Task Create(AuthorEntity entity);
        public Task Update(AuthorEntity entity);
        public Task Delete(string id);
    }
}
