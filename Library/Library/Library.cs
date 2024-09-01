using Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Library : IEnumerable
    {
        private readonly List<Book> _books;

        public Library(params Book[] books)
        {
            this._books = new List<Book>(books);
        }

        public IReadOnlyList<Book> Books => this._books;

        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this._books);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                return ++this.currentIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}

 