using LibraryWebAPI.Application.Visitor;

namespace LibraryWebAPI.Application.Dtos
{
    public class AuthorDto : IEquatable<AuthorDto>, IVisitable
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

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
