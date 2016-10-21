using System;

namespace EntityProvider
{
    /// <summary>
    /// An exception raised by Colour when an invalid colour hex value is supplied.
    /// </summary>
    public class InvalidColourHexException : Exception
    {
        public InvalidColourHexException()
        {
        }

        public InvalidColourHexException(string message)
            : base(message)
        {
        }

        public InvalidColourHexException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}