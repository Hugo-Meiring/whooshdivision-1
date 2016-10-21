using System;

namespace EntityProvider
{
    /// <summary>
    /// Concrete implementation of Tokeniser using commas (,) as separators.
    /// </summary>
    public class CommaTokeniser: Tokeniser
    {
        /// <summary>
        /// Constructor. Defines the character to use as a separator.
        /// </summary>
        public CommaTokeniser()
        {
            separatorCharacter = ',';
        }

        /// <summary>
        /// Tokenise the string received based on the tokeniser, which was
        /// specified as a comma (,).
        /// </summary>
        /// <param name="line">String to be broken up.</param>
        /// <returns>Array of string tokens.</returns>
        public override string[] tokenise(string line)
        {
            if (line == null) throw new NullReferenceException();
            if (!line.Contains(separatorCharacter.ToString())) throw new ListSeparatorNotFoundException();

            string[] toBeReturned = line.Split(separatorCharacter);
            return toBeReturned;
        }
    }
}
