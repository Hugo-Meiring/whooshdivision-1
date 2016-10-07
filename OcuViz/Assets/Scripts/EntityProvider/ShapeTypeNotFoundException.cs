using System;

namespace EntityProvider
{
    /// <summary>
    /// An exception raised by Colour when an invalid colour hex value is supplied.
    /// </summary>
    public class ShapeTypeNotFoundException : Exception
    {
        public ShapeTypeNotFoundException()
        {
        }

        public ShapeTypeNotFoundException(string message)
            : base(message)
        {
        }

        public ShapeTypeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}