using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        List<string> Authors { get; set; }

    }
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            Books = books.ToList();
        }

        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryEnumerator(Books);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
    public class LibraryEnumerator : IEnumerator<Book>
    {
        private int index = -1;
        private List<Book> books;
        public LibraryEnumerator(List<Book> books)
        {
            this.books = books;
        }
        public Book Current => books[index];

        object IEnumerator.Current => Current;


        public bool MoveNext()
        {
            index++;
            return index < books.Count;
        }

        public void Reset() => index = -1;
        
        public void Dispose()
        {
        }
    }
}
