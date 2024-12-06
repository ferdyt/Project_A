using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public class Librarian : Person, IEmployee
    {
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }
        public Library Library { get; set; }

        public void FindBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Назва не коректна", nameof(title));
            }

            if (Library == null)
            {
                throw new InvalidOperationException("Бiблiотекар не працює у бiблiотецi");
            }

            foreach (var book in Library.Books)
            {
                if (string.Equals(book.Title, title, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Книга {book.Title} знайдена");
                    return;
                }
            }

            Console.WriteLine($"Книга {title} не знайдена");
            return;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Iм\'я: {Name}, вiк: {Age}, телефон: {PhoneNumber}");
        }
    }
}
