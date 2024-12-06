namespace Project_A
{
    public class Reader : Person, IBookHandler
    {
        public List<Book> Books { get; } = new List<Book>();
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }
        public Library Library { get; set; }

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
            Library.ChangeStatus(book, Status.Taken);
            Books.Add(book);
            Console.WriteLine($"Книжка додана: {book.Title}");
        }

        public void ReturnBook(Book book)
        {
            if (!Books.Contains(book))
            {
                throw new InvalidOperationException();
            }
            Books.Remove(book);

            Library.ChangeStatus(book, Status.NotTaken);
        }

        public override void IntroduceYourself()
        {
            Console.WriteLine($"Привiт, я читач. Мене звати {Name}. Я {Age}. Мiй номер телефону: {PhoneNumber}.");
        }
    }
}
