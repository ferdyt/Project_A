using Project_A;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReaderAddBook()
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
        public void LibraryAddBook()
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
        public void LibraryAddReaders()
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
    }
}