using LibraryWebAPI.BusinessLogic.Dtos;

namespace LibraryWebAPI.BusinessLogic.Visitor
{
    public interface IVisitor
    {
        void Visit(AuthorDto author);
        void Visit(BookDto book);
    }
}
