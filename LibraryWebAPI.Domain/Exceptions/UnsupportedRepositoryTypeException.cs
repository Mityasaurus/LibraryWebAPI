namespace LibraryWebAPI.Domain.Exceptions
{
    public sealed class UnsupportedRepositoryTypeException(string typeName) : Exception(typeName)
    {
    }
}
