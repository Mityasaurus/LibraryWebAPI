using LibraryWebAPI.DataAccess.Entities;

namespace LibraryWebAPI.DataAccess.Repositories.Factory
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> Instantiate<TEntity>(LibraryContext context) where TEntity : BaseEntity;
    }
}
