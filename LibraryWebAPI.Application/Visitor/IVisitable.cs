namespace LibraryWebAPI.Application.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
