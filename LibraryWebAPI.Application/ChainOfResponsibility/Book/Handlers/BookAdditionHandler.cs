using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.ChainOfResponsibility.Book.Handlers
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
