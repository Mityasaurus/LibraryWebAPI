using LibraryWebAPI.Domain.Entities;
using LibraryWebAPI.Domain.Enums;

namespace LibraryWebAPI.Infrastructure.Persistence
{
    public class LibraryContext
    {
        public ICollection<AuthorEntity> Authors { get; }
        public ICollection<BookEntity> Books { get; }

        public LibraryContext()
        {
            Authors =
            [
                new AuthorEntity
                {
                    Id = "1",
                    Name = "George",
                    Lastname = "Orwell"
                },
                new AuthorEntity
                {
                    Id = "2",
                    Name = "Dale",
                    Lastname = "Carnegie"
                },
                new AuthorEntity
                {
                    Id = "3",
                    Name = "Ernest",
                    Lastname = "Hemingway"
                }
            ];

            Books =
            [
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "1984",
                    Genre = Genre.Fiction,
                    PublishedDate = new DateTime(1949, 6, 8),
                    AuthorId = "1"
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Animal Farm",
                    Genre = Genre.Fiction,
                    PublishedDate = new DateTime(1945, 8, 17),
                    AuthorId = "1"
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "How to Win Friends and Influence People",
                    Genre = Genre.NonFiction,
                    PublishedDate = new DateTime(1936, 10, 1),
                    AuthorId = "2"
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "How to Stop Worrying and Start Living",
                    Genre = Genre.NonFiction,
                    PublishedDate = new DateTime(1948, 1, 1),
                    AuthorId = "2"
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "The Old Man and the Sea",
                    Genre = Genre.Fiction,
                    PublishedDate = new DateTime(1952, 9, 1),
                    AuthorId = "3"
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "For Whom the Bell Tolls",
                    Genre = Genre.Fiction,
                    PublishedDate = new DateTime(1940, 10, 21),
                    AuthorId = "3"
                }
            ];
        }
    }
}
