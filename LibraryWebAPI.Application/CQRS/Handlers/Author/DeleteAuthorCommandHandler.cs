using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.CQRS.Commands.Author;

namespace LibraryWebAPI.Application.CQRS.Handlers.Author
{
    public class DeleteAuthorCommandHandler : ICommandHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorService _authorService;

        public DeleteAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task Handle(DeleteAuthorCommand command)
        {
            await _authorService.Delete(command.Id);
        }
    }

}
