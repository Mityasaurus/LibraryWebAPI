using LibraryWebAPI.Domain.Entities;

namespace LibraryWebAPI.Application.Persistence.Repositories.Factory
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> Instantiate<TEntity>(LibraryContext context) where TEntity : BaseEntity;
    }
}
