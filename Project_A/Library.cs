using System.Reflection.PortableExecutable;

namespace Project_A
{
    public class Library : IBookHandler
    {
        public List<Book> Books { get; } = new List<Book>();
        public List<Reader> Readers { get; } = new List<Reader>();
        public List<Librarian> Librarians { get; } = new List<Librarian>();

        public event EventHandler<ReaderEventArgs> ReaderAdd;
        public event EventHandler<LibrarianEventArgs> LibrarianAdd;

        public void AddBook(Book book, Library library)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            if (!Books.Contains(book)) 
            {
                library.Books.Add(book);
            }
        }

        public void AddLibrarian(Librarian librarian)
        {
            if (librarian == null)
            {
                throw new ArgumentNullException(nameof(librarian));
            }
            Librarians.Add(librarian);
            OnLibrarianAdd(new LibrarianEventArgs(librarian));
        }

        public void ChangeStatus(Book book, Status status)
        {
            if (!Books.Contains(book))
            {
                throw new InvalidOperationException();
            }

            book.Status = status;
        }

        public void AddReader(Reader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            Readers.Add(reader);
            OnReaderAdd(new ReaderEventArgs(reader));
        }
        protected virtual void OnReaderAdd(ReaderEventArgs e)
        {
            Console.WriteLine($"Читач доданий: {e.Reader.Name}");
            ReaderAdd?.Invoke(this, e);
        }
        protected virtual void OnLibrarianAdd(LibrarianEventArgs e)
        {
            Console.WriteLine($"Бiблiотекар доданий: {e.Librarian.Name}");
            LibrarianAdd?.Invoke(this, e);
        }
    }
}
