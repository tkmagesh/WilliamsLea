using System.Collections;
using System.Collections.Generic;

namespace LinqBasicsDemo
{
    public class MyCollection<T> : IEnumerable<T>, IEnumerator<T>
    {
        private ArrayList _list = new ArrayList();
        public void Add(T value)
        {
            _list.Add(value);
        }

        public void Remove(int index)
        {
            _list.RemoveAt(index);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public T Get(int index)
        {
            return (T) _list[index];
        }

        /*public void Sort()
        {
            for(var i=0;i<_list.Count-1;i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Book) _list[i];
                    var right = (Book) _list[j];
                    if (left.Id > right.Id)
                    {
                        //Swap
                        var temp = left;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
        }*/

        public void Sort(IValueComparer<T> comparer)
        {
            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (T)_list[i];
                    var right = (T)_list[j];
                    var shouldSwap = comparer.Compare(left, right) == 1;    
                    if (shouldSwap)
                    {
                        var temp = _list[i];
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                   
                }
        }

        public void Sort(CompareValueDelegate<T> compare)
        {
            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (T)_list[i];
                    var right = (T)_list[j];
                    var shouldSwap = compare(left, right) == 1;
                    if (shouldSwap)
                    {
                        var temp = _list[i];
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }

                }
        }

        
        //IEnumerable
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        //IEnumerator
        private int index = -1;
        public bool MoveNext()
        { 
            index++;
            if (index >= _list.Count)
            {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        T IEnumerator<T>.Current { get { return (T) this.Current; } }

        public object Current { 
        get { return (T) _list[index]; }}

        public int Sum(IntFieldSelectorDelegate<T> fieldSelector)
        {
            var result = 0;
            foreach (var item in _list)
            {
                var value = (T) item;
                result += fieldSelector(value);
            }
            return result;
        }

        public decimal Sum(DecimalFieldSelectorDelegate<T> fieldSelector)
        {
            var result = 0m;
            foreach (var item in _list)
            {
                var value = (T)item;
                result += fieldSelector(value);
            }
            return result;
        }

        public int CountFor(CrieteriaDelegate<T> crieteria)
        {
            var result = 0;
            foreach (var item in _list)
            {
                var value = (T) item;
                if (crieteria(value) == true)
                    result++;
            }
            return result;
        }

        public MyCollection<T> Filter(CrieteriaDelegate<T> crieteria)
        {
            var result = new MyCollection<T>();
            foreach (var item in _list)
            {
                var value = (T)item;
                if (crieteria(value) == true)
                    result.Add(value);
            }
            return result;
        }

        public IEnumerable<T> LazyFilter(CrieteriaDelegate<T> crieteria)
        {
            foreach (var item in _list)
            {
                var value = (T)item;
                if (crieteria(value) == true)
                    yield return value;
            }
        }

        public void Dispose()
        {
            index = -1;
        }
    }

    public delegate int IntFieldSelectorDelegate<T>(T value);

    public delegate decimal DecimalFieldSelectorDelegate<T>(T value);

    public delegate bool CrieteriaDelegate<T>(T value);
}