using Project_A;

namespace Project_A_MSTest
{
    [TestClass]
    public class UnitTest1 : PageTest
    {
        [TestMethod]
        void ReaderAddBook()
        {
            // Arrange
            Reader reader = new Reader();
            Library library = new Library();
            Book book = new Book("Test", "Test", Rating.Good, library);

            // Act
            reader.AddBook(book);

            // Assert
            Assert.IsNotNull(reader.Books);
        }

        [TestMethod]
        void LibraryAddBook()
        {
            // Arrange
            Library library = new Library();
            Book book = new Book("Test", "Test", Rating.Good, library);

            // Act
            library.AddBook(book);

            // Assert
            Assert.IsNotNull(library.Books);
        }

        [TestMethod]
        void LibraryAddReaders()
        {
            // Arrange
            Library library = new Library();
            Reader reader = new Reader();

            // Act
            library.AddReader(reader);

            // Assert
            Assert.IsNotNull(reader.Books);
        }

        [TestMethod]
        void LibraryAddLibrarians()
        {
            // Arrange
            Library library = new Library();
            Librarian librarian = new Librarian();

            // Act
            library.AddLibrarian(librarian);

            // Assert
            Assert.IsNotNull(library.Librarians);
        }
    }
}
