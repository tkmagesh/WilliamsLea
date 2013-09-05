namespace LinqBasicsDemo
{
    public interface IBookComparer
    {
        int Compare(Book left, Book right);
    }

    public delegate int CompareBookDelegate(Book left, Book right);
}