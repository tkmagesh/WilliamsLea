﻿namespace LinqBasicsDemo
{
    public class BookComparerByCost : IBookComparer
    {
        public int Compare(Book left, Book right)
        {
            if (left.Cost < right.Cost)
                return -1;
            if (left.Cost == right.Cost)
                return 0;
            return 1;
        }
    }
}