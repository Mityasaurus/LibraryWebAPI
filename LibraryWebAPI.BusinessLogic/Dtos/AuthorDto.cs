namespace LibraryWebAPI.BusinessLogic.Dtos
{
    public class AuthorDto : IEquatable<AuthorDto>
    {
        public static readonly AuthorDto Default =
            new (string.Empty, string.Empty, string.Empty);

        public string Id { get; }
        public string Name { get; }
        public string Lastname { get; }

        public AuthorDto(string id, string name, string lastname) 
        { 
            Id = id;
            Name = name;
            Lastname = lastname;
        }

        public bool Equals(AuthorDto? other)
        {
            if(other == null) return false;

            return Id == other.Id && Name == other.Name && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Lastname);
        }
    }
}
