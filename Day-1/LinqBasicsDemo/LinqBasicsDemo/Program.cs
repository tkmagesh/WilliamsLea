using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinqBasicsDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            var books = new MyCollection<Book>();
            var numbers = new List<int>(){1,2,3,4,5,6};
            numbers.LazyFilter(n => n%2 == 0);
            MyUtilities.LazyFilter(numbers, n => n%2 == 0);
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
            books.Sort((l,r) => Math.Sign(l.Id - r.Id));
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

            Console.WriteLine();
            /*var totalUnits = books.Sum(delegate(Book book)
                {
                    return book.Units;
                });*/

            var totalUnits = books.Sum(book => book.Units);
            Console.WriteLine("Sum of Units = {0}", totalUnits);

            var overStockedCount = books.CountFor(book => book.Units > 50);
            Console.WriteLine("Number of books that are over stocked (Units > 50) = {0}",overStockedCount);
            Console.WriteLine("Number of cheap books (Cost < 50) = {0}", books.CountFor(b => b.Cost < 50));
            Console.WriteLine("The below are the cheap books");
            var cheapBooks = books.Filter(b => b.Cost < 50);
            foreach (var cheapBook in cheapBooks)
            {
                Console.WriteLine(cheapBook);
            
            }

            Console.WriteLine();
            Console.WriteLine("Using Lazy Evaluation");

            var cheapBooks2 = books.LazyFilter(b => b.Cost < 50);
            foreach (var book in cheapBooks2)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("Are all the books cheap books ? {0}", books.All(b => b.Cost < 50));
            Console.WriteLine("Is there any C# book at all ? {0}",books.Any(b => b.Title == "C#"));
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