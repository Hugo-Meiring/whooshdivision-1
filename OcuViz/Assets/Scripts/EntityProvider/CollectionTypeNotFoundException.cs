using System;

namespace EntityProvider
{
    /// <summary>
    /// An exception raised by Collection when a type required is not found.
    /// </summary>
    public class CollectionTypeNotFoundException : Exception
    {
        public CollectionTypeNotFoundException()
        {
        }

        public CollectionTypeNotFoundException(string message)
            : base(message)
        {
        }

        public CollectionTypeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}