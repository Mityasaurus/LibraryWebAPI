using LibraryWebAPI.Application.ChainOfResponsibility.Book;
using LibraryWebAPI.Application.ChainOfResponsibility.Book.Handlers;
using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.CQRS.Commands.Author;
using LibraryWebAPI.Application.CQRS.Mediator;
using LibraryWebAPI.Application.CQRS.Queries.Author;
using LibraryWebAPI.Application.Dtos;
using LibraryWebAPI.Application.Strategy.Search;
using LibraryWebAPI.Application.Visitor;
using LibraryWebAPI.Domain.Enums;

namespace LibraryWebAPI.Application.Facade
{
    public class LibraryFacade : ILibraryFacade
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IBookHandler _bookHandler;
        private readonly IMediator _mediator;

        public LibraryFacade(IAuthorService authorService, IBookService bookService, IMediator mediator)
        {
            _authorService = authorService;
            _bookService = bookService;
            _mediator = mediator;
            _bookHandler = new BookValidationHandler();
            _bookHandler.SetNext(new AuthorExistenceHandler(authorService))
                        .SetNext(new BookAdditionHandler(bookService));
        }

        // Authors methods (with command/queries logic)
        public async Task<IReadOnlyList<AuthorDto>> GetAllAuthors()
        {
            return await _mediator.Send(new GetAllAuthorsQuery());
        }

        public async Task<AuthorDto> GetAuthor(string authorId)
        {
            return await _mediator.Send(new GetAuthorByIdQuery(authorId));
        }

        public async Task AddAuthor(AuthorDto authorDto)
        {
            var command = new AddAuthorCommand(authorDto);
            await _mediator.Send(command);
        }

        public async Task UpdateAuthor(AuthorDto authorDto)
        {
            var command = new UpdateAuthorCommand(authorDto);
            await _mediator.Send(command);
        }

        public async Task DeleteAuthor(string authorId)
        {
            var command = new DeleteAuthorCommand(authorId);
            await _mediator.Send(command);
        }

        // Books methods
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
            return await _bookService.GetByGenre(bookGenre);
        }

        public async Task<IReadOnlyList<BookDto>> GetBooksByTitle(string bookTitle)
        {
            return await _bookService.GetByTitle(bookTitle);
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

        public async Task<IReadOnlyList<BookDto>> SearchBooks(string criteria, BookSearchType searchType)
        {
            var searchContext = new SearchContext();

            switch (searchType)
            {
                case BookSearchType.Title:
                    searchContext.SetSearchStrategy(new SearchByTitleStrategy(_bookService));
                    break;
                case BookSearchType.Genre:
                    searchContext.SetSearchStrategy(new SearchByGenreStrategy(_bookService));
                    break;
                default:
                    throw new ArgumentException("Invalid search type specified.");
            }

            return await searchContext.SearchAsync(criteria);
        }
    }
}
