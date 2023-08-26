using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = books.OrderBy(x =>x.Year).ThenBy(x=>x.Title).ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private int index;
            private readonly List<Book> books;
            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }
            public Book Current => this.books[this.index];
            object IEnumerator.Current => this.Current;
            public bool MoveNext() => ++this.index < this.books.Count;
            public void Reset() => this.index = -1;
            public void Dispose() { }

        }
    }
   
}
