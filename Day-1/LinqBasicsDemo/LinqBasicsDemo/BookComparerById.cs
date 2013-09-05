namespace LinqBasicsDemo
{
    public class BookComparerById : IValueComparer<Book>
    {
        public int Compare(Book left, Book right)
        {
            if (left.Id < right.Id)
                return -1;
            if (left.Id == right.Id)
                return 0;
            return 1;
        }
    }
}