using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Dtos;
using LibraryWebAPI.Infrastructure.Enums;

namespace LibraryWebAPI.BusinessLogic.Strategy.Search
{
    public class SearchByGenreStrategy : ISearchStrategy
    {
        private readonly IBookService _bookService;

        public SearchByGenreStrategy(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IReadOnlyList<BookDto>> SearchAsync(string criteria)
        {
            if (Enum.TryParse<Genre>(criteria, true, out var genreEnum))
            {
                 return await _bookService.GetByGenre(genreEnum);
            }
            else
            {
                throw new ArgumentException("Invalid genre specified.");
            }
            
        }
    }
}
