using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.CQRS.Queries.Author;
using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.CQRS.Handlers.Author
{
    public class GetAllAuthorsQueryHandler : IQueryHandler<GetAllAuthorsQuery, IReadOnlyList<AuthorDto>>
    {
        private readonly IAuthorService _authorService;

        public GetAllAuthorsQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IReadOnlyList<AuthorDto>> Handle(GetAllAuthorsQuery query)
        {
            return await _authorService.GetAll();
        }
    }

}
