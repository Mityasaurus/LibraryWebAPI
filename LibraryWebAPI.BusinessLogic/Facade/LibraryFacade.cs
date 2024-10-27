using LibraryWebAPI.BusinessLogic.ChainOfResponsibility.Book;
using LibraryWebAPI.BusinessLogic.ChainOfResponsibility.Book.Handlers;
using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Dtos;
using LibraryWebAPI.BusinessLogic.Visitor;
using LibraryWebAPI.Infrastructure.Enums;

namespace LibraryWebAPI.BusinessLogic.Facade
{
    public class LibraryFacade : ILibraryFacade
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IBookHandler _bookHandler;

        public LibraryFacade(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
            _bookHandler = new BookValidationHandler();
            _bookHandler.SetNext(new AuthorExistenceHandler(authorService))
                        .SetNext(new BookAdditionHandler(bookService));
        }

        //Authors methods
        public async Task<IReadOnlyList<AuthorDto>> GetAllAuthors()
        {
            return await _authorService.GetAll();
        }

        public async Task<AuthorDto> GetAuthor(string authodId)
        {
            return await _authorService.Get(authodId);
        }

        public async Task AddAuthor(AuthorDto authorDto)
        {
            await _authorService.Add(authorDto);
        }

        public async Task UpdateAuthor(AuthorDto authorDto)
        {
            await _authorService.Update(authorDto);
        }

        public async Task DeleteAuthor(string authodId)
        {
            await _authorService.Delete(authodId);
        }

        //Books methods
        public async Task<IReadOnlyList<BookDto>> GetAllBooks()
        {
            return await _bookService.GetAll();
        }

        public async Task<BookDto> GetBook(string bookId)
        {
            return await _bookService.Get(bookId);
        }

        public async Task<IReadOnlyList<BookDto>> GetBooksByGenre(Genre bookGenre)
        {
            var books = await _bookService.GetAll();
            return books.Where(b => b.Genre == bookGenre).ToList();
        }

        public async Task AddBook(BookDto bookDto)
        {
            await _bookHandler.Handle(bookDto);
        }

        public async Task UpdateBook(BookDto bookDto)
        {
            await _bookService.Update(bookDto);
        }

        public async Task DeleteBook(string bookId)
        {
            await _bookService.Delete(bookId);
        }

        public async Task<StatisticsDto> GetStatistics()
        {
            var authors = await _authorService.GetAll();
            var books = await _bookService.GetAll();

            var visitor = new StatisticsVisitor();

            foreach (var author in authors)
            {
                author.Accept(visitor);
            }

            foreach (var book in books)
            {
                book.Accept(visitor);
            }

            var statistics = new StatisticsDto(
                authorsCount: visitor.AuthorCount,
                booksCount: visitor.BookCount);

            return statistics;
        }
    }
}
