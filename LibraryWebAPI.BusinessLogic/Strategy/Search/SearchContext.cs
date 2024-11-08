using LibraryWebAPI.BusinessLogic.Dtos;

namespace LibraryWebAPI.BusinessLogic.Strategy.Search
{
    public class SearchContext
    {
        private ISearchStrategy _searchStrategy;

        public void SetSearchStrategy(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }

        public async Task<IReadOnlyList<BookDto>> SearchAsync(string criteria)
        {
            return await _searchStrategy.SearchAsync(criteria);
        }
    }

}
