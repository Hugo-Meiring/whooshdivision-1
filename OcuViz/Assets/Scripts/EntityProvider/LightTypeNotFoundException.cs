using System;

namespace EntityProvider
{
    /// <summary>
    /// An exception raised by Factories when a list of parameters is not the expected length.
    /// </summary>
    public class LightTypeNotFoundException : Exception
    {
        public LightTypeNotFoundException()
        {
        }

        public LightTypeNotFoundException(string message)
            : base(message)
        {
        }

        public LightTypeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}