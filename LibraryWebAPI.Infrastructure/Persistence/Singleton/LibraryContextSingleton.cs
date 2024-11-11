using LibraryWebAPI.Domain.Entities;
using LibraryWebAPI.Domain.Enums;

namespace LibraryWebAPI.Infrastructure.Persistence.Singleton
{
    public class LibraryContextSingleton
    {
        private static readonly Lazy<LibraryContext> _instance = new(() => new LibraryContext());

        public static LibraryContext Instance => _instance.Value;

        public ICollection<AuthorEntity> Authors { get; }
        public ICollection<BookEntity> Books { get; }

        private LibraryContextSingleton()
        {
            Authors =
            [
                new AuthorEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "George",
                    Lastname = "Orwell"
                },
                new AuthorEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Dale",
                    Lastname = "Carnegie"
                },
                new AuthorEntity
                {
                    Id = Guid.NewGuid().ToString(),
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
                    AuthorId = Authors.First(a => a.Lastname == "Orwell").Id
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Animal Farm",
                    Genre = Genre.Fiction,
                    PublishedDate = new DateTime(1945, 8, 17),
                    AuthorId = Authors.First(a => a.Lastname == "Orwell").Id
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "How to Win Friends and Influence People",
                    Genre = Genre.NonFiction,
                    PublishedDate = new DateTime(1936, 10, 1),
                    AuthorId = Authors.First(a => a.Lastname == "Carnegie").Id
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "How to Stop Worrying and Start Living",
                    Genre = Genre.NonFiction,
                    PublishedDate = new DateTime(1948, 1, 1),
                    AuthorId = Authors.First(a => a.Lastname == "Carnegie").Id
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "The Old Man and the Sea",
                    Genre = Genre.Fiction,
                    PublishedDate = new DateTime(1952, 9, 1),
                    AuthorId = Authors.First(a => a.Lastname == "Hemingway").Id
                },
                new BookEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "For Whom the Bell Tolls",
                    Genre = Genre.Fiction,
                    PublishedDate = new DateTime(1940, 10, 21),
                    AuthorId = Authors.First(a => a.Lastname == "Hemingway").Id
                }
            ];
        }
    }
}
