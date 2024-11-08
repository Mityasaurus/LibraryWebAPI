using LibraryWebAPI.BusinessLogic.Dtos;

namespace LibraryWebAPI.BusinessLogic.ChainOfResponsibility.Book
{
    public interface IBookHandler
    {
        Task Handle(BookDto book);
        IBookHandler SetNext(IBookHandler handler);
    }
}
