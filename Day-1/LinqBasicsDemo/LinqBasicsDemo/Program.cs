using System;
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

            Console.WriteLine();
            Console.WriteLine("Sorted (Cost) List");
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", "Id", "Title", "Cost", "Units");
            books.Sort(new BookComparerByCost());
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
            
            Console.WriteLine();
            Console.WriteLine("Sorted (Units) List using delegates");
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", "Id", "Title", "Cost", "Units");

            //books.Sort(new CompareBookDelegate(CompareBooksByUnits));
            //books.Sort(CompareBooksByUnits);
            /*books.Sort(delegate (Book left, Book right)
                        {
                            if (left.Units > right.Units) return 1;
                            if (left.Units == right.Units) return 0;
                            return -1;
                        }
             );*/

            /*books.Sort((left,right) =>
                {
                    return Math.Sign(left.Units - right.Units);
                }
             );*/

            books.Sort((left, right) => Math.Sign(left.Units - right.Units));
            
            for (var i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books.Get(i));
            }

            

            Console.ReadLine();
        }

        public static int CompareBooksByUnits(Book left, Book right)
        {
            if (left.Units > right.Units) return 1;
            if (left.Units == right.Units) return 0;
            return -1;
        }

    }
}