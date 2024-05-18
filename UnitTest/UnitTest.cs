using Entities.DTOs;
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

            var exception = Assert.Throws<Exception>(() => BookValidator.ValidateBook(book));

            Assert.That(string.Equals("Name author is invalid!", exception.Message));
        }

        [Test]
        public void ValidateBookReleaseDate_Invalid()
        {
            var book = new BookDTO();

            var exception = Assert.Throws<Exception>(() => BookValidator.ValidateBook(book));

            Assert.That(string.Equals("Release date is invalid!", exception.Message));
        }
    }
}