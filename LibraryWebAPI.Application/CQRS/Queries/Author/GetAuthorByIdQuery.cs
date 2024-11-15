using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.CQRS.Queries.Author
{
    public class GetAuthorByIdQuery(string id) : IQuery<AuthorDto>
    {
        public string Id { get; } = id;
    }
}
