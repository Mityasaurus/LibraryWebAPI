namespace LibraryWebAPI.BusinessLogic.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
