using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqBasicsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BooksCollection();
            books.Add(new Book { Id = 1, Title = "C#", Cost = 10, Units = 12 });
            books.Add(new Book { Id = 9, Title = "F#", Cost = 20, Units = 20 });
            books.Add(new Book { Id = 5, Title = "D#", Cost = 22, Units = 22 });
            books.Add(new Book { Id = 3, Title = "E#", Cost = 78, Units = 52 });
            books.Add(new Book { Id = 2, Title = "K#", Cost = 60, Units = 32 });
            books.Add(new Book { Id = 7, Title = "J#", Cost = 50, Units = 62 });
            Console.WriteLine("Default List");
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", "Id", "Title", "Cost", "Units");
            for (var i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books.Get(i));
            }
            Console.WriteLine();
            Console.WriteLine("Sorted (Id) List");
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", "Id", "Title", "Cost", "Units");
            books.Sort();
            for (var i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books.Get(i));
            }

            Console.ReadLine();
        }

    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int Units { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}", Id, Title, Cost, Units);
        }
    }

    public class BooksCollection
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
    }

}