using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.CQRS.Commands.Author
{
    public class AddAuthorCommand(AuthorDto author) : ICommand
    {
        public AuthorDto Author { get; } = author;
    }
}
