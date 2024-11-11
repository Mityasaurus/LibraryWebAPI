using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.Visitor
{
    public interface IVisitor
    {
        void Visit(AuthorDto author);
        void Visit(BookDto book);
    }
}
