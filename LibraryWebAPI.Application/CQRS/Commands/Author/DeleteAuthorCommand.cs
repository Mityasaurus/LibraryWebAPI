namespace LibraryWebAPI.Application.CQRS.Commands.Author
{
    public class DeleteAuthorCommand(string id) : ICommand
    {
        public string Id { get; } = id;
    }
}
