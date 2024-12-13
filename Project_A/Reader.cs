using Project_A;

namespace Project_A
{
    public class Reader : Person, IBookHandler
    {
        public List<Book> Books { get; } = new List<Book>();
        public string Name { get; set; }
        public Age Age { get; set; }
        public string PhoneNumber { get; set; }
        public Library Library { get; set; }

        public event EventHandler<BookEventArgs> BookAdded;

        public event EventHandler<BookEventArgs> BookReturned;

        public void AddBook(Book book, Library library)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            if (book.Status == Status.Taken)
            {
                throw new ArgumentNullException(nameof(book));
            }
            library.ChangeStatus(book, Status.Taken);
            Books.Add(book);

            OnBookAdded(new BookEventArgs(book));
        }

        public void ReturnBook(Book book, Library library)
        {
            if (!Books.Contains(book))
            {
                throw new InvalidOperationException();
            }
            Books.Remove(book);

            library.ChangeStatus(book, Status.NotTaken);

            OnBookReturned(new BookEventArgs(book));
        }

        protected virtual void OnBookAdded(BookEventArgs e)
        {
            Console.WriteLine($"Книжка додана: {e.Book.Title}");
            BookAdded?.Invoke(this, e);
        }

        protected virtual void OnBookReturned(BookEventArgs e)
        {
            Console.WriteLine($"Книжка повернута: {e.Book.Title}");
            BookReturned?.Invoke(this, e);
        }

        public override void IntroduceYourself()
        {
            Console.WriteLine($"Привiт, я читач. Мене звати {Name}. Я {Age}. Мiй номер телефону: {PhoneNumber}.");
        }
    }
}