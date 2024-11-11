using LibraryWebAPI.Application.Visitor;
using LibraryWebAPI.Domain.Enums;

namespace LibraryWebAPI.Application.Dtos
{
    public class BookDto : IEquatable<BookDto>, IVisitable
    {
        public static readonly BookDto Default =
            new(string.Empty, string.Empty, Genre.None, DateTime.MinValue, string.Empty);

        public string Id { get;  }
        public string Title { get;  }
        public Genre Genre { get; }
        public DateTime PublishedDate { get; }
        public string AuthorId { get; init; }

        public BookDto(string id, string title, Genre genre, DateTime publishedDate, string authorId)
        {
            Id = id;
            Title = title;
            Genre = genre;
            PublishedDate = publishedDate;
            AuthorId = authorId;
        }

        public bool Equals(BookDto? other)
        {
            if(other == null) return false;

            return Id == other.Id && Title == other.Title && Genre == other.Genre && 
                PublishedDate == other.PublishedDate && AuthorId == other.AuthorId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Genre, PublishedDate, AuthorId);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
