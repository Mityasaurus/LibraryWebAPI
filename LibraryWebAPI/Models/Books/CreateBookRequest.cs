using LibraryWebAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models.Books
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; init; }
        public Genre Genre { get; init; }
        [Required]
        public DateTime PublishedDate { get; init; }
        [Required]
        public string AuthorId { get; init; }
    }
}
