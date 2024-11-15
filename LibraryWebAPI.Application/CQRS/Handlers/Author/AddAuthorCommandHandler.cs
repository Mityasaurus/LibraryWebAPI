using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.CQRS.Commands.Author;

namespace LibraryWebAPI.Application.CQRS.Handlers.Author
{
    public class AddAuthorCommandHandler : ICommandHandler<AddAuthorCommand>
    {
        private readonly IAuthorService _authorService;

        public AddAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task Handle(AddAuthorCommand command)
        {
            await _authorService.Add(command.Author);
        }
    }

}
