using System;

namespace EntityProvider
{
    /// <summary>
    /// An exception raised by Factories when a list of parameters is not the expected length.
    /// </summary>
    public class InvalidListLengthException : Exception
    {
        public InvalidListLengthException()
        {
        }

        public InvalidListLengthException(string message)
            : base(message)
        {
        }

        public InvalidListLengthException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}