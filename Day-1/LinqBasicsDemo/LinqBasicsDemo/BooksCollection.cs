using System.Collections;

namespace LinqBasicsDemo
{
    public class BooksCollection : IEnumerable, IEnumerator
    {
        private ArrayList _list = new ArrayList();
        public void Add(Book book)
        {
            _list.Add(book);
        }

        public void Remove(int index)
        {
            _list.RemoveAt(index);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public Book Get(int index)
        {
            return (Book) _list[index];
        }

        public void Sort()
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
        }

        public void Sort(IBookComparer comparer)
        {
            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Book)_list[i];
                    var right = (Book)_list[j];
                    var shouldSwap = comparer.Compare(left, right) == 1;    
                    if (shouldSwap)
                    {
                        var temp = _list[i];
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                   
                }
        }

        public void Sort(CompareBookDelegate compare)
        {
            for (var i = 0; i < _list.Count - 1; i++)
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var left = (Book)_list[i];
                    var right = (Book)_list[j];
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

        public object Current { 
        get { return (Book) _list[index]; }}
    }
}