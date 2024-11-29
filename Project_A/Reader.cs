using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public class Reader
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
