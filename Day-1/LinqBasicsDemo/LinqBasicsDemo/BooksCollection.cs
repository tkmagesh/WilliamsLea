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

        
        public void Dispose()
        {
            index = -1;
        }
    }

    /*public delegate int IntFieldSelectorDelegate<T>(T value);

    public delegate TResult DummyDelegate<in T, out TResult>(T value);

    public delegate decimal DecimalFieldSelectorDelegate<T>(T value);

    public delegate bool CrieteriaDelegate<T>(T value);*/
}