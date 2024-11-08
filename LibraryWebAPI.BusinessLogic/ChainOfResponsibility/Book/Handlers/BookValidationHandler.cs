using LibraryWebAPI.BusinessLogic.Dtos;

namespace LibraryWebAPI.BusinessLogic.ChainOfResponsibility.Book.Handlers
{
    public class BookValidationHandler : BookHandlerBase
    {
        public override async Task Handle(BookDto book)
        {
            if (string.IsNullOrWhiteSpace(book.Title) || book.PublishedDate > DateTime.Now)
            {
                throw new ArgumentException("Invalid book data.");
            }

            await base.Handle(book);
        }
    }
}
