using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public class Reader : Person, IEmployee, IEntityWithBooks
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }

        public void AddBook(Book book)
        {
            if (book == null || book.Status == Status.NotTaken)
            {
                throw new ArgumentNullException(nameof(book));
            }
            Books.Add(book);
            Console.WriteLine($"Книжка додана: {book.Title}");
        }

        public List<Book> GetBooks()
        {
            return Books;
        }

        public void GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
