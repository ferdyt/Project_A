using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Librarian> Librarians { get; set; } = new List<Librarian>();

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void AddLibrarian(Librarian librarian)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public void AddReader(Reader reader)
        {
            throw new NotImplementedException();
        }
    }
}
