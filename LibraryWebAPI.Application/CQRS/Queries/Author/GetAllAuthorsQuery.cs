using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.CQRS.Queries.Author
{
    public class GetAllAuthorsQuery : IQuery<IReadOnlyList<AuthorDto>> { }
}
