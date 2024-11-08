using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Dtos;

namespace LibraryWebAPI.BusinessLogic.ChainOfResponsibility.Book.Handlers
{
    public class AuthorExistenceHandler : BookHandlerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorExistenceHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public override async Task Handle(BookDto book)
        {
            var author = await _authorService.Get(book.AuthorId);
            if (author.Equals(AuthorDto.Default))
            {
                throw new ArgumentException("Author does not exist.");
            }

            await base.Handle(book);
        }
    }
}
