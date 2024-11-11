using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.ChainOfResponsibility.Book
{
    public interface IBookHandler
    {
        Task Handle(BookDto book);
        IBookHandler SetNext(IBookHandler handler);
    }
}
