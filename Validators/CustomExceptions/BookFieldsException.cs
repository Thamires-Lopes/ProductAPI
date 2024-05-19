namespace Validators.CustomExceptions
{
    public class BookFieldsException : Exception
    {
        private List<BookFieldException> _bookFieldExceptions = [];

        public BookFieldsException(List<BookFieldException> bookFieldExceptions)
        {
            _bookFieldExceptions = bookFieldExceptions;
        }

        public List<string> Messages 
        {
            get
            {
                var messages = new List<string>();

                if (_bookFieldExceptions != null && _bookFieldExceptions.Count > 0)
                {
                    messages = _bookFieldExceptions.Select(x => x.Message).ToList();
                }

                return messages;
            }
        }
    }
}
