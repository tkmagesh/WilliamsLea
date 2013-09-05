using System;
using System.Collections.Generic;

namespace LinqBasicsDemo
{
    public static class MyUtilities
    {
        public static bool IsEven(this int number)
        {
            return number%2 == 0;
        }

        public static int Sum<T>(this IEnumerable<T> list, Func<T,int> fieldSelector)
        {
            var result = 0;
            foreach (var item in list)
            {
                var value = (T)item;
                result += fieldSelector(value);
            }
            return result;
        }

        public static decimal Sum<T>(this IEnumerable<T> list, Func<T,decimal> fieldSelector)
        {
            var result = 0m;
            foreach (var item in list)
            {
                var value = (T)item;
                result += fieldSelector(value);
            }
            return result;
        }

        public static int CountFor<T>(this IEnumerable<T> _list, Func<T,bool> crieteria)
        {
            var result = 0;
            foreach (var item in _list)
            {
                var value = (T)item;
                if (crieteria(value) == true)
                    result++;
            }
            return result;
        }

        public static MyCollection<T> Filter<T>(this IEnumerable<T> list, Func<T,bool> crieteria)
        {
            var result = new MyCollection<T>();
            foreach (var item in list)
            {
                var value = (T)item;
                if (crieteria(value) == true)
                    result.Add(value);
            }
            return result;
        }

        public static IEnumerable<T> LazyFilter<T>(this IEnumerable<T> list, 
            Func<T,bool> crieteria)
        {
            foreach (var item in list)
            {
                var value = (T)item;
                if (crieteria(value) == true)
                    yield return value;
            }
        }

        public static bool All<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (!predicate(item)) return false;
            }
            return true;
        }

        public static bool Any<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item)) return true;
            }
            return false;
        }

    }
}