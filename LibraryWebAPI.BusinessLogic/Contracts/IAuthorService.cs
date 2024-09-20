using LibraryWebAPI.BusinessLogic.Dtos;

namespace LibraryWebAPI.BusinessLogic.Contracts
{
    public interface IAuthorService
    {
        Task<IReadOnlyList<AuthorDto>> GetAll();
        Task<AuthorDto> Get(string id);
        Task Add(AuthorDto authorDto);
        Task Update(AuthorDto authorDto);
        Task Delete(string id);
    }
}
