using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.Visitor
{
    public class StatisticsVisitor : IVisitor
    {
        public int AuthorCount { get; private set; } = 0;
        public int BookCount { get; private set; } = 0;

        public void Visit(AuthorDto author)
        {
            AuthorCount++;
        }

        public void Visit(BookDto book)
        {
            BookCount++;
        }
    }
}
