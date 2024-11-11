using LibraryWebAPI.Domain.Enums;

namespace LibraryWebAPI.Domain.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Title { get; set; }
        public Genre Genre { get; set; } 
        public DateTime PublishedDate { get; set; }
        public string AuthorId { get; set; }
    }
}
