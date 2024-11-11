using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.Strategy.Search
{
    public class SearchByTitleStrategy : ISearchStrategy
    {
        private readonly IBookService _bookService;

        public SearchByTitleStrategy(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IReadOnlyList<BookDto>> SearchAsync(string criteria)
        {
            return await _bookService.GetByTitle(criteria);
        }
    }
}
