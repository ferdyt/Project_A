using Project_A;
using System.Linq;

public class Program
{
    static void WithColor(ConsoleColor color, Action action)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        action();
        Console.ForegroundColor = originalColor;
    }

    static string CapitalizeFirstLetter(string input)
    {
        return char.ToUpper(input[0]) + input.Substring(1);
    }

    static void Main(string[] args)
    {
        Library library = new Library();
        char[] specialCharacters = { ';', '.', '@', '#', '%', '$', '\'', '\"', '*', '!', '(', ')', '&'};

        while (true)
        {
            Console.WriteLine("Оберiть дiю");
            Console.WriteLine("1 - Додати читача");
            Console.WriteLine("2 - Список читачiв");
            Console.WriteLine("");
            Console.WriteLine("3 - Додати книгу");
            Console.WriteLine("4 - Список книг");
            Console.WriteLine("");
            Console.WriteLine("5 - Додати бiблiотекара");
            Console.WriteLine("6 - Список бiблiотекарiв");
            Console.WriteLine("");
            Console.WriteLine("7 - Видати книгу читачевi");
            Console.WriteLine("8 - Повернути книгу");
            Console.WriteLine("9 - Список книг читача");
            Console.Write(">>>");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Reader reader = new Reader();

                    Console.WriteLine("Введiть iм'я читача");
                    while (true)
                    {
                        Console.Write(">>>");
                        string readerName = Console.ReadLine();

                        bool containsDigits = readerName.Any(char.IsDigit);
                        if (containsDigits)
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я мiстить меньше 3 букв");
                            });
                            continue;
                        }
                        else if (readerName.Contains(" "))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я мiстить пробiли");
                            });
                            continue;
                        }
                        else if (string.IsNullOrEmpty(readerName))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я пусте");
                            });
                            continue;
                        }
                        else if (readerName.Length < 3)
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я мiстить меньше 3 букв");
                            });
                            continue;
                        }
                        else if (specialCharacters.Any(readerName.Contains))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я мiстить забороненi символи");
                            });
                            continue;
                        }
                        reader.Name = CapitalizeFirstLetter(readerName);
                        break;
                    }

                    Console.WriteLine("Оберiть вiк:");
                    Console.WriteLine("0 - Child");
                    Console.WriteLine("1 - Adult");
                    Console.WriteLine("2 - Old");
                    while (true)
                    {
                        Console.Write(">>>");
                        string readerStrAge = Console.ReadLine();
                        int readerIntAge;
                        if (!int.TryParse(readerStrAge, out readerIntAge))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Некоректний ввiд");
                            });
                            continue;
                        }
                        else if (readerIntAge < 0 || readerIntAge > 2)
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Оберiть число вiд 0 до 2");
                            });
                            continue;
                        }
                        reader.Age = (Age)readerIntAge;
                        break;
                    }

                    Console.WriteLine("Введiть номер телефону (9 цифр):");
                    while (true)
                    {
                        Console.Write(">>>");
                        string readerStrPhoneNumber = Console.ReadLine();
                        int readerIntPhoneNumber;
                        if (!int.TryParse(readerStrPhoneNumber, out readerIntPhoneNumber))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Некоректний ввiд");
                            });
                            continue;
                        }
                        else if (readerStrPhoneNumber.Length != 9)
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Номер телефону не мiстить 9 цифр");
                            });
                            continue;
                        }
                        reader.PhoneNumber = readerIntPhoneNumber;
                        break;
                    }

                    WithColor(ConsoleColor.Green, () =>
                    {
                        library.AddReader(reader);
                    });
                    break;
                case "2":
                    if (library.Readers.Count == 0)
                    {
                        Console.WriteLine("Список порожнiй");
                        break;
                    }

                    Console.WriteLine("Список читачiв:");
                    foreach (var r in library.Readers)
                    {
                        Console.WriteLine($"Iм'я: {r.Name}");
                        Console.WriteLine($"Вiк: {r.Age}");
                        Console.WriteLine($"Номер телефону: {r.PhoneNumber}");
                        Console.WriteLine();
                    }
                    break;
                case "3":
                    string bookTitle, bookStrRating, bookAuthor;
                    int bookIntRating, bookIntAuthor, bookIntTitle;

                    Console.WriteLine("Введiть назву книги:");
                    while (true)
                    {
                        Console.Write(">>>");
                        bookTitle = Console.ReadLine();

                        if (string.IsNullOrEmpty(bookTitle))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Назва пуста");
                            });
                            continue;
                        }
                        else if (bookTitle.Contains(" "))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Назва мiстить пробiли (використовуйте '_' замiсть пробiлiв)");
                            });
                            continue;
                        }
                        else if (int.TryParse(bookTitle, out bookIntTitle))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Назва мiстить цифри");
                            });
                            continue;
                        }
                        else if (specialCharacters.Any(bookTitle.Contains))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Назва мiстить забороненi символи");
                            });
                            continue;
                        }

                        bookTitle = CapitalizeFirstLetter(bookTitle);
                        break;
                    }

                    Console.WriteLine("Введiть рейтинг книги:");
                    Console.WriteLine("0 - Bad");
                    Console.WriteLine("1 - Good");
                    Console.WriteLine("2 - Awesome");
                    while (true)
                    {
                        Console.Write(">>>");
                        bookStrRating = Console.ReadLine();

                        if(string.IsNullOrEmpty(bookStrRating))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Рейтинг пустий");
                            });
                            continue;
                        }
                        else if (!int.TryParse(bookStrRating, out bookIntRating))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Некоректний ввiд");
                            });
                            continue;
                        }
                        else if (bookIntRating < 0 || bookIntRating > 2)
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Оберiть число вiд 0 до 2");
                            });
                            continue;
                        }
                        break;
                    }

                    Console.WriteLine("Введiть автора книги:");
                    while (true)
                    {
                        Console.Write(">>>");
                        bookAuthor = Console.ReadLine();

                        if (string.IsNullOrEmpty(bookAuthor))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Рейтинг пустий");
                            });
                            continue;
                        }
                        else if (bookAuthor.Contains(" "))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Автор мiстить пробiли (використовуйте '_' замiсть пробiлiв)");
                            });
                            continue;
                        }
                        else if (int.TryParse(bookAuthor, out bookIntAuthor))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Автор мiстить цифри");
                            });
                        }
                        break;
                    }

                    WithColor(ConsoleColor.Green, () =>
                    {
                        Book book = new Book(bookTitle, bookAuthor, (Rating)bookIntRating, library, 0);
                    });
                    break;
                case "4":
                    if (library.Books.Count == 0)
                    {
                        Console.WriteLine("Список порожнiй");
                        break;
                    }

                    Console.WriteLine("Список:");
                    foreach (var b in library.Books)
                    {
                        Console.WriteLine($"Назва: {b.Title}");
                        Console.WriteLine($"Рейтинг: {b.Rating}");
                        Console.WriteLine($"Автор: {b.Author}");
                        Console.WriteLine($"Статус: {b.Status}");
                        Console.WriteLine("");
                    }
                    break;
                case "5":
                    Console.WriteLine("Введiть iм'я бiблiотекара");
                    string librarianName;
                    int librarianIntName;
                    Librarian librarian = new Librarian();

                    while (true)
                    {
                        Console.Write(">>>");
                        librarianName = Console.ReadLine();

                        if (string.IsNullOrEmpty(librarianName))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я пусте");
                            });
                            continue;
                        }
                        else if (int.TryParse(librarianName, out librarianIntName))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я мiстить цифри");
                            });
                            continue;
                        }
                        else if (librarianName.Contains(" "))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я мiстить пробiли");
                            });
                            continue;
                        }
                        else if (specialCharacters.Any(librarianName.Contains))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Iм'я мiстить забороненi символи");
                            });
                            continue;
                        }

                        librarian.Name = librarianName;
                        break;
                    }

                    Console.WriteLine("Введiть вiк:");
                    Console.WriteLine("1 - Adult");
                    Console.WriteLine("2 - Old");
                    while (true)
                    {
                        Console.Write(">>>");
                        string librarianAge = Console.ReadLine();
                        int librarianIntAge;

                        if (!int.TryParse(librarianAge, out librarianIntAge))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Некоректний ввiд");
                            });
                            continue;
                        }
                        else if (librarianIntAge < 0 || librarianIntAge > 2)
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Оберiть число вiд 0 до 2");
                            });
                            continue;
                        }

                        librarian.Age = (Age)librarianIntAge;
                        break;
                    }

                    Console.WriteLine("Введiть номер телефону:");
                    while (true)
                    {
                        Console.Write(">>>");
                        string librarianStrPhoneNumber = Console.ReadLine();
                        int librarianIntPhoneNumber;

                        if (librarianStrPhoneNumber.Length != 9)
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Номер телефону не мiстить 9 цифр");
                            });
                            continue;
                        }
                        else if (!int.TryParse(librarianStrPhoneNumber, out librarianIntPhoneNumber))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine("Помилка: Некоректний ввiд");
                            });
                            continue;
                        }

                        librarian.PhoneNumber = librarianIntPhoneNumber;
                        library.AddLibrarian(librarian);
                        break;
                    }
                    break;
                case "6":
                    if (library.Librarians.Count == 0)
                    {
                        Console.WriteLine("Список порожнiй");
                        break;
                    }

                    foreach (var l in library.Librarians)
                    {
                        Console.WriteLine($"Iм'я: {l.Name}");
                        Console.WriteLine($"Вiк: {l.Age}");
                        Console.WriteLine($"Номер телефону: {l.PhoneNumber}");
                        Console.WriteLine();
                    }
                    break;
                case "7":
                    if (library.Librarians.Count == 0)
                    {
                        Console.WriteLine("У бiблiотецi немає бiблiотекарiв");
                        break;
                    }
                    if (library.Readers.Count == 0)
                    {
                        Console.WriteLine("У бiблiотецi читачів немає");
                        break;
                    }

                    Console.WriteLine("Читачi:");
                    foreach (var r in library.Readers)
                    {
                        Console.WriteLine(r.Name);
                    }
                    Console.WriteLine("Введiть iм'я читача:");
                    Console.Write(">>>");
                    string nameToChoice = CapitalizeFirstLetter(Console.ReadLine());
                    Reader readerToChoice = null;

                    foreach (var r in library.Readers)
                    {
                        if (r.Name == nameToChoice)
                        {
                            readerToChoice = r;
                            break;
                        }
                    }

                    if (readerToChoice != null)
                    {
                        Console.WriteLine("Список книг");
                        foreach (var b in library.Books)
                        {
                            Console.WriteLine(b.Title);
                        }
                        Console.WriteLine($"Оберiть книгу яку видати читачєві \'{readerToChoice.Name}\'");
                        Console.Write(">>>");
                        string bookToChoice = Console.ReadLine();
                        Book searchBook = null;

                        foreach (var b in library.Books)
                        {
                            if (b.Title == bookToChoice)
                            {
                                searchBook = b;
                                break;
                            }
                        }

                        Console.WriteLine("На скiльки днiв дати читачу книгу");
                        Console.Write(">>>");
                        string daysStr = Console.ReadLine();
                        int days;
                        if (!int.TryParse(daysStr, out days))
                        {
                            WithColor(ConsoleColor.Red, () =>
                            {
                                Console.WriteLine($"Помилка: Некоректний ввод");
                            });
                        }

                        try
                        {
                            searchBook.TakenOnDays = days;
                            readerToChoice.AddBook(searchBook, library);
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Книжка не додана до читача");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Читача не існує");
                    }
                    break;
                case "8":
                    if (library.Librarians.Count == 0)
                    {
                        Console.WriteLine("У бiблiотецi немає бiблеотекарiв");
                        break;
                    }

                    if (library.Readers.Count == 0)
                    {
                        Console.WriteLine("У бiблiотецi читачів немає");
                        break;
                    }

                    Console.WriteLine("Читачi:");
                    foreach (var r in library.Readers)
                    {
                        Console.WriteLine(r.Name);
                    }
                    Console.WriteLine("Введiть iм'я читача:");
                    Console.Write(">>>");
                    string nameToChoice2 = CapitalizeFirstLetter(Console.ReadLine());
                    Reader readerToChoice2 = null;
                    foreach (var r in library.Readers)
                    {
                        if (r.Name == nameToChoice2)
                        {
                            readerToChoice2 = r;
                            break;
                        }
                    }

                    if (readerToChoice2 != null)
                    {
                        if (readerToChoice2.Books.Count == 0)
                        {
                            Console.WriteLine($"У читача {readerToChoice2.Name} немає книжок");
                            break;
                        }
                        Console.WriteLine("Список книг");
                        foreach (var b in readerToChoice2.Books)
                        {
                            Console.WriteLine(b.Title);
                        }
                        Console.WriteLine($"Оберiть книгу яку повернути до бiблiотеки \'{readerToChoice2.Name}\'");
                        Console.Write(">>>");
                        string bookToChoice = Console.ReadLine();
                        Book searchBook = null;

                        foreach (var b in readerToChoice2.Books)
                        {
                            if (b.Title == bookToChoice)
                            {
                                searchBook = b;
                                break;
                            }
                        }
                        try
                        {
                            searchBook.TakenOnDays = 0;
                            readerToChoice2.ReturnBook(searchBook, library);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Книжка не повернута до бiблiотеки");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Читача не існує");
                    }
                    break;
                case "9":
                    foreach (var r in library.Readers)
                    {
                        Console.WriteLine(r.Name);
                    }
                    Console.WriteLine("Введiть iм'я читача");
                    Console.Write(">>>");
                    string nameToList = CapitalizeFirstLetter(Console.ReadLine());
                    Reader reader1 = null;

                    foreach (var r in library.Readers)
                    {
                        if (nameToList == r.Name)
                        {
                            reader1 = r;
                            break;
                        }
                    }

                    if (reader1.Books.Count == 0)
                    {
                        Console.WriteLine($"У читача {reader1.Name} немає книжок");
                        break;
                    }

                    foreach (var b in reader1.Books)
                    {
                        Console.WriteLine($"Книга: {b.Title}");
                        Console.WriteLine($"Автор: {b.Author}");
                        Console.WriteLine($"Днiв до здачi: {b.TakenOnDays}");
                        Console.WriteLine();
                    }

                    break;
                default:
                    Console.WriteLine("Некоректна дiя");
                    break;
            }
        }
    }
}
