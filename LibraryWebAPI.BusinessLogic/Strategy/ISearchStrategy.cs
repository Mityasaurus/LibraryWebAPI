using LibraryWebAPI.BusinessLogic.Dtos;

namespace LibraryWebAPI.BusinessLogic.Strategy
{
    public interface ISearchStrategy
    {
        Task<IReadOnlyList<BookDto>> SearchAsync(string criteria);
    }
}
