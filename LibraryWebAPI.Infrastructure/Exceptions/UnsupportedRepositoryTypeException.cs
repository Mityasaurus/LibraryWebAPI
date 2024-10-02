namespace LibraryWebAPI.Infrastructure.Exceptions
{
    public sealed class UnsupportedRepositoryTypeException(string typeName) : Exception(typeName)
    {
    }
}
