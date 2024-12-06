using Project_A;
using System.Reflection.PortableExecutable;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateNewBook()
        {
            // Arrange
            Library library = new Library();
            Book book = new Book("Test", "Test", Rating.Good, library, 30);
            // Act + Assert
            Assert.IsNotNull(book);
        }

        [TestMethod]
        public void ReaderAddBook()
        {
            // Arrange
            Reader reader = new Reader();
            Library library = new Library();
            reader.Library = library;
            Book book = new Book("Test", "Test", Rating.Good, library, 30);

            // Act
            reader.AddBook(book);

            // Assert
            Assert.IsNotNull(reader.Books);
        }

        [TestMethod]
        public void LibraryAddBook()
        {
            // Arrange
            Library library = new Library();
            Book book = new Book("Test", "Test", Rating.Good, library, 30);

            // Act
            library.AddBook(book);

            // Assert
            Assert.IsNotNull(library.Books);
        }

        [TestMethod]
        public void LibraryAddReaders()
        {
            // Arrange
            Library library = new Library();
            Reader reader = new Reader();
            reader.Library = library;

            // Act
            library.AddReader(reader);

            // Assert
            Assert.IsNotNull(reader.Books);
        }

        [TestMethod]
        public void LibraryAddLibrarians()
        {
            // Arrange
            Library library = new Library();
            Librarian librarian = new Librarian();

            // Act
            library.AddLibrarian(librarian);

            // Assert
            Assert.IsNotNull(library.Librarians);
        }

        [TestMethod]
        public void LibrarianFindBook()
        {
            // Arrange
            Library library = new Library();
            Librarian librarian = new Librarian();
            Book book = new Book("Test", "Test", Rating.Good, library, 30);

            // Act
            library.AddLibrarian(librarian);
            librarian.Library = library;
            library.AddBook(book);
            Book searchBook = librarian.FindBook("Test");

            // Assert
            Assert.IsNotNull(searchBook);
        }

        [TestMethod]
        public void ReaderReturnBook()
        {
            // Arrange
            Library library = new Library();
            Reader reader = new Reader();
            reader.Library = library;
            Book book = new Book("Test", "Test", Rating.Good, library, 30);

            // Act
            reader.AddBook(book);
            reader.ReturnBook(book);

            // Assert
            Assert.IsFalse(reader.Books.Contains(book));
        }
    }
}
