using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public class Reader : Person, IEmployee
    {
        public List<Book> Books { get; } = new List<Book>();
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            if (book.Status == Status.Taken)
            {
                throw new ArgumentNullException(nameof(book));
            }
            Books.Add(book);
            Console.WriteLine($"Книжка додана: {book.Title}");
        }

        public void GetInfo()
        {
            Console.WriteLine($"Iм\'я: {Name}, вiк: {Age}, телефон: {PhoneNumber}");
        }
    }
}
