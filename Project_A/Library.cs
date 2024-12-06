namespace Project_A
{
    public class Library : IBookHandler
    {
        public List<Book> Books { get; } = new List<Book>();
        public List<Reader> Readers { get; } = new List<Reader>();
        public List<Librarian> Librarians { get; } = new List<Librarian>();

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            if (!Books.Contains(book) && book.Library == this) 
            {
                Books.Add(book);
            }
        }

        public void AddLibrarian(Librarian librarian)
        {
            if (librarian == null)
            {
                throw new ArgumentNullException(nameof(librarian));
            }
            Librarians.Add(librarian);
            Console.WriteLine($"Бiблiотекар доданий: {librarian.Name}");
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
            Console.WriteLine($"Читач доданий: {reader.Name}");
        }
    }
}
