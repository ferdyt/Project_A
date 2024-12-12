namespace Project_A
{
    public class Book
    {
        public string Title { get;}
        public Library Library { get;}
        public Rating Rating { get;}
        public Status Status { get; set;}
        public string Author { get;}
        public int TakenOnDays { get; set; }

        public Book(string title, string author, Rating rating, Library library, int takenOnDays)
        {
            if (takenOnDays < 0)
            {
                throw new Exception(nameof(takenOnDays));
            }
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Rating = rating;
            Library = library ?? throw new ArgumentNullException(nameof(library));
            TakenOnDays = takenOnDays;

            library.AddBook(this, library);
            Status = Status.NotTaken;
            Console.WriteLine($"Книгу {Title} створено");
        }
    }
}
