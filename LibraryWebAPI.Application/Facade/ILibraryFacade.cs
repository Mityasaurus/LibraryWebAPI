using LibraryWebAPI.Application.Dtos;
using LibraryWebAPI.Domain.Enums;

namespace LibraryWebAPI.Application.Facade
{
    public interface ILibraryFacade
    {
        Task<IReadOnlyList<AuthorDto>> GetAllAuthors();
        Task<AuthorDto> GetAuthor(string id);
        Task AddAuthor(AuthorDto authorDto);
        Task UpdateAuthor(AuthorDto authorDto);
        Task DeleteAuthor(string id);

        Task<IReadOnlyList<BookDto>> GetAllBooks();
        Task<BookDto> GetBook(string id);
        Task<IReadOnlyList<BookDto>> GetBooksByGenre(Genre genre);
        Task<IReadOnlyList<BookDto>> GetBooksByTitle(string title);
        Task AddBook(BookDto bookDto);
        Task UpdateBook(BookDto bookDto);
        Task DeleteBook(string id);

        Task<StatisticsDto> GetStatistics();
        Task<IReadOnlyList<BookDto>> SearchBooks(string criteria, BookSearchType searchType);
    }
}
