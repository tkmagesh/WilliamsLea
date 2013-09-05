namespace LinqBasicsDemo
{
    public interface IValueComparer<T>
    {
        int Compare(T left, T right);
    }

    public delegate int CompareValueDelegate<T>(T left, T right);
}