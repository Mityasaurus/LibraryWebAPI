using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.Contracts
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
