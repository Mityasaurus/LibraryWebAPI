using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models.Authors
{
    public class UpdateAuthorRequest
    {
        [Required]
        public string Id { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        public string Lastname { get; init; }
    }
}
