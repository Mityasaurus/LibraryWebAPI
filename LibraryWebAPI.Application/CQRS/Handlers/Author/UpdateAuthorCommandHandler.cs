using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.CQRS.Commands.Author;

namespace LibraryWebAPI.Application.CQRS.Handlers.Author
{
    public class UpdateAuthorCommandHandler : ICommandHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorService _authorService;

        public UpdateAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task Handle(UpdateAuthorCommand command)
        {
            await _authorService.Update(command.Author);
        }
    }

}
