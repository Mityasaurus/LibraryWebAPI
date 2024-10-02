using LibraryWebAPI.BusinessLogic.Dtos;
using LibraryWebAPI.Infrastructure.Enums;

namespace LibraryWebAPI.BusinessLogic.Builder
{
    public interface IBookBuilder
    {
        IBookBuilder SetId(string id);
        IBookBuilder SetTitle(string title);
        IBookBuilder SetGenre(Genre genre);
        IBookBuilder SetPublishedDate(DateTime date);
        IBookBuilder SetAuthorId(string id);
        BookDto Build();
    }
}
