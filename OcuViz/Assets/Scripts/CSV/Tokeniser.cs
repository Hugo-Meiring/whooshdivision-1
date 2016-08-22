using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityProvider
{
    abstract class Tokeniser
    {
        public abstract string[] tokenise(string line);

        protected char separatorCharacter;
    }
}
