using LibraryWebAPI.Application.Dtos;
using LibraryWebAPI.Domain.Enums;

namespace LibraryWebAPI.Application.Builder
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
