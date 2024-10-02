using LibraryWebAPI.DataAccess.Entities;
using LibraryWebAPI.DataAccess.Repositories.Author;
using LibraryWebAPI.DataAccess.Repositories.Book;
using LibraryWebAPI.Infrastructure.Exceptions;

namespace LibraryWebAPI.DataAccess.Repositories.Factory
{
    public sealed class RepositoryFactory : IRepositoryFactory
    {
        private static IRepositoryFactory _instance;

        private static readonly object Locker = new();

        private RepositoryFactory() { }

        public static IRepositoryFactory Instance()
        {
            if(_instance != null)
            {
                return _instance;
            }

            lock(Locker)
            {
                _instance ??= new RepositoryFactory();
            }

            return _instance;
        }

        public IRepository<TEntity> Instantiate<TEntity>(LibraryContext context) where TEntity : BaseEntity
        {
            return typeof(TEntity).Name switch
            {
                nameof(AuthorEntity) => (IRepository<TEntity>)new AuthorRepository(context),
                nameof(BookEntity) => (IRepository<TEntity>)new BookRepository(context),
                _ => throw new UnsupportedRepositoryTypeException(typeof(TEntity).Name)
            };
        }

    }
}
