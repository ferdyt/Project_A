using System;
namespace Project_A
{
    public class BookEventArgs : EventArgs
    {
        public Book Book { get; }

        public BookEventArgs(Book book)
        {
            Book = book;
        }
    }

    public class ReaderEventArgs : EventArgs
    {
        public Reader Reader { get; }

        public ReaderEventArgs(Reader reader)
        {
            Reader = reader;
        }
    }

    public class LibrarianEventArgs : EventArgs
    {
        public Librarian Librarian { get; }

        public LibrarianEventArgs(Librarian librarian)
        {
            Librarian = librarian;
        }
    }
}
