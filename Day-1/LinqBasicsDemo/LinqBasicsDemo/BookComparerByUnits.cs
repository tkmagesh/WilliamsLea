namespace LinqBasicsDemo
{
    public class BookComparerByUnits : IValueComparer<Book>
    {
        public int Compare(Book left, Book right)
        {
            if (left.Units < right.Units) return -1;
            if (left.Units == right.Units) return 0;
            return 1;
        }
    }
}