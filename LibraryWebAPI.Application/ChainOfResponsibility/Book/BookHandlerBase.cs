using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.ChainOfResponsibility.Book
{
    public abstract class BookHandlerBase : IBookHandler
    {
        private IBookHandler? _nextHandler;

        public IBookHandler SetNext(IBookHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual async Task Handle(BookDto book)
        {
            if (_nextHandler != null)
            {
                await _nextHandler.Handle(book);
            }
        }
    }
}
