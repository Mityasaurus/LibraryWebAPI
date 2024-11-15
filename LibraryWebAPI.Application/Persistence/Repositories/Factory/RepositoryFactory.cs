//using LibraryWebAPI.Domain.Entities;
//using LibraryWebAPI.Domain.Exceptions;
//using LibraryWebAPI.Application.Persistence.Repositories.Factory;
//using LibraryWebAPI.Application.Persistence;
//using LibraryWebAPI.Application.Persistence.Repositories;

//namespace LibraryWebAPI.Infrastructure.Persistence.Repositories.Factory
//{
//    public sealed class RepositoryFactory : IRepositoryFactory
//    {
//        private static readonly Lazy<IRepositoryFactory> _instance = new(() => new RepositoryFactory());

//        public static IRepositoryFactory Instance => _instance.Value;

//        private RepositoryFactory() { }

//        public IRepository<TEntity> Instantiate<TEntity>(LibraryContext context) where TEntity : BaseEntity
//        {
//            return typeof(TEntity).Name switch
//            {
//                nameof(AuthorEntity) => (IRepository<TEntity>)new AuthorRepository(context),
//                nameof(BookEntity) => (IRepository<TEntity>)new BookRepository(context),
//                _ => throw new UnsupportedRepositoryTypeException(typeof(TEntity).Name)
//            };
//        }
//    }
//}
