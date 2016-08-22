using System;

namespace EntityProvider
{
    /// <summary>
    /// An exception raised by EntityPool when a store call is carried out on an entity already present in the pool.
    /// <seealso cref="EntityPool"/>
    /// </summary>
    public class DuplicateEntityException: Exception
    {
        public DuplicateEntityException()
        {
        }

        public DuplicateEntityException(string message)
            : base(message)
        {
        }

        public DuplicateEntityException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }    
}