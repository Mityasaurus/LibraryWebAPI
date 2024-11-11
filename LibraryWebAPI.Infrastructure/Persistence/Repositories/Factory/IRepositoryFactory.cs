using LibraryWebAPI.Domain.Entities;

namespace LibraryWebAPI.Infrastructure.Persistence.Repositories.Factory
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> Instantiate<TEntity>(LibraryContext context) where TEntity : BaseEntity;
    }
}
