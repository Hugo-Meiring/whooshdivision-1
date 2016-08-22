using System;

namespace EntityProvider
{
    /// <summary>
    /// An exception raised by EntityPool when a fetch call is carried out on an entity not present in the pool.
    /// <seealso cref="EntityPool"/>
    /// </summary>
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }    
}