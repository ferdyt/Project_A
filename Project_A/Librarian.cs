using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public class Librarian : Person
    {
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }
        public Library Library { get; set; }

        public Book FindBook(string title)
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
                    return book;
                }
            }
            return null;
        }

        public override void IntroduceYourself()
        {
            Console.WriteLine($"Привiт, я бiблiотекар. Мене звати {Name}. Мiй номер телефону: {PhoneNumber}.");
        }
    }
}
