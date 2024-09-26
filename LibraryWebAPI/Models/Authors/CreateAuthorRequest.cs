using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models.Authors
{
    public class CreateAuthorRequest
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Lastname { get; init; }
    }
}
