using Entities.DTOs;
using Validators.CustomExceptions;
using Validators.Validators;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateBookAuthorName_Invalid()
        {
            var book = new BookDTO();

            var exception = Assert.Throws<BookFieldsException>(() => BookValidator.ValidateBook(book));

            Assert.That(exception.Messages.Contains("Name author is invalid!"));
        }

        [Test]
        public void ValidateBookReleaseDate_Invalid()
        {
            var book = new BookDTO();

            var exception = Assert.Throws<BookFieldsException>(() => BookValidator.ValidateBook(book));

            Assert.That(exception.Messages.Contains("Release date is invalid!"));
        }

        [Test]
        public void ValidateBook_Valid()
        {
            var book = new BookDTO { Author = "Author", ReleaseDate = DateTime.Now.Date };

            Assert.DoesNotThrow(() => BookValidator.ValidateBook(book));
        }
    }
}