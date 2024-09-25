using LibraryWebAPI.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models.Books
{
    public class UpdateBookRequest
    {
        [Required]
        public string Id { get; init; }
        [Required]
        public string Title { get; init; }
        public Genre Genre { get; init; }
        [Required]
        public DateTime PublishedDate { get; init; }
        [Required]
        public string AuthorId { get; init; }
    }
}
