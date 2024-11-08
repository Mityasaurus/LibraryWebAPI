namespace LibraryWebAPI.BusinessLogic.Dtos
{
    public class StatisticsDto : IEquatable<StatisticsDto>
    {
        public static readonly StatisticsDto Default = new (0, 0);

        public int AuthorsCount { get; }
        public int BooksCount { get; }

        public StatisticsDto(int authorsCount, int booksCount) {
            AuthorsCount = authorsCount;
            BooksCount = booksCount;
        }

        public bool Equals(StatisticsDto? other)
        {
            if (other == null) return false;

            return AuthorsCount == other.AuthorsCount && BooksCount == other.BooksCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AuthorsCount, BooksCount);
        }
    }
}
