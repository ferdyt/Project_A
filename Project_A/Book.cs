using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public class Book
    {
        public string Title { get; set; }
        public Library Library { get; set; }
        public Rating Rating { get; set; }
        public string Author { get; set; }

        public Book(string title, string author, Rating rating, Library library)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Rating = rating;
            Library = library ?? throw new ArgumentNullException(nameof(library));

            library.AddBook(this);
        }
    }
}
