using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.CQRS.Queries.Author;
using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.CQRS.Handlers.Author
{
    public class GetAuthorByIdQueryHandler : IQueryHandler<GetAuthorByIdQuery, AuthorDto>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorByIdQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery query)
        {
            return await _authorService.Get(query.Id);
        }
    }

}
