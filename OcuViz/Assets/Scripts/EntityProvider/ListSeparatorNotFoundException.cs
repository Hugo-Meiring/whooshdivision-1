using System;

namespace EntityProvider
{
    /// <summary>
    /// An exception raised by Colour when an invalid colour hex value is supplied.
    /// </summary>
    public class ListSeparatorNotFoundException : Exception
    {
        public ListSeparatorNotFoundException()
        {
        }

        public ListSeparatorNotFoundException(string message)
            : base(message)
        {
        }

        public ListSeparatorNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}