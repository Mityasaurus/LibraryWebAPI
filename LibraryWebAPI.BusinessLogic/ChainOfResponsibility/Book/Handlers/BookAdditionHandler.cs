using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Dtos;

namespace LibraryWebAPI.BusinessLogic.ChainOfResponsibility.Book.Handlers
{
    public class BookAdditionHandler : BookHandlerBase
    {
        private readonly IBookService _bookService;

        public BookAdditionHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public override async Task Handle(BookDto book)
        {
            await _bookService.Add(book);
            await base.Handle(book);
        }
    }
}
