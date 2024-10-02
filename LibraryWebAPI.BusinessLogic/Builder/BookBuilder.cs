using LibraryWebAPI.BusinessLogic.Dtos;
using LibraryWebAPI.Infrastructure.Enums;

namespace LibraryWebAPI.BusinessLogic.Builder
{
    public class BookBuilder : IBookBuilder{
        private string? _id;
        private string? _title;
        private Genre _genre;
        private DateTime _publishedDate;
        private string? _authorId;

        public IBookBuilder SetId(string id)
        {
            _id = id;
            return this;
        }

        public IBookBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }
        public IBookBuilder SetGenre(Genre genre)
        {
            _genre = genre;
            return this;
        }
        public IBookBuilder SetPublishedDate(DateTime date)
        {
            _publishedDate = date;
            return this;
        }
        public IBookBuilder SetAuthorId(string id)
        {
            _authorId = id;
            return this;
        }

        public BookDto Build()
        {
            return new BookDto(
                id: _id ?? Guid.NewGuid().ToString(),
                title: _title ?? string.Empty,
                genre: _genre,
                publishedDate: _publishedDate,
                authorId: _authorId ?? string.Empty);
        }
    }
}
