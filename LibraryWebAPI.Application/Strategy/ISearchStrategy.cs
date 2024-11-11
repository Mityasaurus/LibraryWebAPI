using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.Strategy
{
    public interface ISearchStrategy
    {
        Task<IReadOnlyList<BookDto>> SearchAsync(string criteria);
    }
}
