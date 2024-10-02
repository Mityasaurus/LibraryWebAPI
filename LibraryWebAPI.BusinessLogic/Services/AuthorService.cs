using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Dtos;
using LibraryWebAPI.DataAccess;
using LibraryWebAPI.DataAccess.Entities;
using LibraryWebAPI.DataAccess.Repositories.Author;
using LibraryWebAPI.DataAccess.Repositories.Factory;

namespace LibraryWebAPI.BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(LibraryContext context)
        {
            var factory = RepositoryFactory.Instance();
            _authorRepository = (IAuthorRepository)factory.Instantiate<AuthorEntity>(context);
        }

        public async Task<IReadOnlyList<AuthorDto>> GetAll()
        {
            var authors = await _authorRepository.GetAll();
            if(authors == null || authors.Count == 0)
                return [];

            return authors.Select(a => new AuthorDto(
                id: a.Id,
                name: a.Name,
                lastname: a.Lastname)).ToList().AsReadOnly();
        }

        public async Task<AuthorDto> Get(string id)
        {
            var author = await _authorRepository.Get(id);
            if(author == null)
            {
                return AuthorDto.Default;
            }

            return new AuthorDto(
                id: author.Id,
                name: author.Name,
                lastname: author.Lastname);
        }

        public async Task Add(AuthorDto authorDto)
        {
            if (authorDto == AuthorDto.Default)
                return;

            await _authorRepository.Create(new AuthorEntity
            {
                Id = authorDto.Id,
                Name = authorDto.Name,
                Lastname = authorDto.Lastname
            });
        }

        public async Task Update(AuthorDto authorDto)
        {
            if (authorDto == AuthorDto.Default)
                return;

            await _authorRepository.Update(new AuthorEntity
            {
                Id = authorDto.Id,
                Name = authorDto.Name,
                Lastname = authorDto.Lastname
            });
        }

        public async Task Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(message: "Empty Author ID", paramName: nameof(id));

            await _authorRepository.Delete(id);
        }
    }
}
