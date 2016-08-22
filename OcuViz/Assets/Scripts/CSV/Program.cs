using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReaderTests tester = new FileReaderTests();
            tester.TestGetLines();
            Console.WriteLine("\nEnd of FileReader Test.\nBeginning Tokeniser Test\n\n");
            tester.TestTokenise();
            Console.ReadLine();
        }
    }
}
