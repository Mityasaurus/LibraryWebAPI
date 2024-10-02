using LibraryWebAPI.Infrastructure.Enums;

namespace LibraryWebAPI.DataAccess.Entities
{
    public class BookEntity : BaseEntity
    {
        public string Title { get; set; }
        public Genre Genre { get; set; } 
        public DateTime PublishedDate { get; set; }
        public string AuthorId { get; set; }
    }
}
