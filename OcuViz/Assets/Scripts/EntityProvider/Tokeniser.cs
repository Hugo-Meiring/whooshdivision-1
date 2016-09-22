using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityProvider
{
    /// <summary>
    /// This abstract class is used to tokenise a string based on a 
    /// character. Subclasses need to specify this character to be 
    /// used to separate the string input into an array of strings.
    /// </summary>
    abstract class Tokeniser
    {
        /// <summary>
        /// Method used to break up a string into an array based on
        /// the character predetermined.
        /// </summary>
        /// <param name="line">String to be tokenised.</param>
        /// <returns>An array of tokenised strings.</returns>
        public abstract string[] tokenise(string line);

        /// <summary>
        /// Character used to break up the string.
        /// </summary>
        protected char separatorCharacter;
    }
}
