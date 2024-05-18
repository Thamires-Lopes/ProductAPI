namespace Validators.CustomExceptions
{
    public class BookFieldException : Exception
    {
        public BookFieldException() { }

        public BookFieldException(string? message) : base(message)
        {
        }
    }
}
