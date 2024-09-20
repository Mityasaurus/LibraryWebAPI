using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Dtos;
using LibraryWebAPI.DataAccess.Entities;
using LibraryWebAPI.DataAccess.Repositories.Author;
using LibraryWebAPI.DataAccess.Repositories.Book;
using LibraryWebAPI.Infrastructure.Enums;

namespace LibraryWebAPI.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public BookService(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IReadOnlyList<BookDto>> GetAll()
        {
            var books = await _bookRepository.GetAll();
            if (books == null || books.Count == 0)
                return [];

            return books.Select(b => new BookDto(
                id: b.Id,
                title: b.Title,
                genre: b.Genre,
                publishedDate: b.PublishedDate,
                authorId: b.AuthorId)).ToList().AsReadOnly();
        }

        public async Task<BookDto> Get(string id)
        {
            var book = await _bookRepository.Get(id);
            if (book == null)
                return BookDto.Default;

            return new BookDto(
                id: book.Id,
                title: book.Title,
                genre: book.Genre,
                publishedDate: book.PublishedDate,
                authorId: book.AuthorId);
        }

        public async Task<IReadOnlyList<BookDto>> GetByGenre(Genre genre)
        {
            var books = await _bookRepository.Get(b => b.Genre == genre);
            if (books == null || books.Count == 0)
                return [];

            return books.Select(b => new BookDto(
                id: b.Id,
                title: b.Title,
                genre: b.Genre,
                publishedDate: b.PublishedDate,
                authorId: b.AuthorId)).ToList().AsReadOnly();
        }

        public async Task Add(BookDto bookDto)
        {
            if (bookDto == BookDto.Default)
                return;

            var author = _authorRepository.Get(bookDto.AuthorId);

            if (author == null)
                throw new ArgumentNullException(paramName: nameof(bookDto.AuthorId), 
                    message: $"Author with id {bookDto.AuthorId} not found");

            await _bookRepository.Create(new BookEntity
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                PublishedDate = bookDto.PublishedDate,
                AuthorId = bookDto.AuthorId
            });
        }

        public async Task Update(BookDto bookDto)
        {
            if (bookDto == BookDto.Default)
                return;

            var author = _authorRepository.Get(bookDto.AuthorId);

            if (author == null)
                throw new ArgumentNullException(paramName: nameof(bookDto.AuthorId),
                    message: $"Author with id {bookDto.AuthorId} not found");

            await _bookRepository.Update(new BookEntity
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                PublishedDate = bookDto.PublishedDate,
                AuthorId = bookDto.AuthorId
            });
        }

        public async Task Delete(string id)
        {
            if(string.IsNullOrEmpty(id))
                throw new ArgumentNullException(message: "Empty Book ID", paramName: nameof(id));

            await _bookRepository.Delete(id);
        }
    }
}
