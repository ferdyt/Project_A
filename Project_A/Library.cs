using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_A
{
    public class Library : IEntityWithBooks
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Librarian> Librarians { get; set; } = new List<Librarian>();

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            book.Status = Status.NotTaken;
            Books.Add(book);
            Console.WriteLine($"Книжка додана: {book.Title}");
        }

        public void AddLibrarian(Librarian librarian)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooks()
        {
            return Books;
        }

        public void AddReader(Reader reader)
        {
            throw new NotImplementedException();
        }
    }
}
