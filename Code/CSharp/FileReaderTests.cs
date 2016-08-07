using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EntityProvider
{
    //[TestClass]
    public class FileReaderTests
    {
        //[TestMethod]
        public void TestGetLines()
        {
            FileReader reader = new FileReader();

            List<string> test = reader.getLines(
                "C:\\Users\\Vukile\\Documents\\COS301\\OcuViz\\Code\\EntityProvider\\FileReaderTest\\SceneDescriptor.csv"
                );
            
            for(int i = 0; i < test.Count; ++i)
            {
                Console.WriteLine(test[i]);
            }
        }

        public void TestTokenise()
        {
            FileReader reader = new FileReader();
            test = reader.getLines(
                "C:\\Users\\Vukile\\Documents\\COS301\\OcuViz\\Code\\EntityProvider\\FileReaderTest\\SceneDescriptor.csv"
                );

            Tokeniser tokeniser = new CommaTokeniser();
            for (int j = 0; j < test.Count; ++j)
            {
                string[] tokens = tokeniser.tokenise(test[j]);

                for (int i = 0; i < tokens.Length; ++i)
                {
                    Console.WriteLine(tokens[i]);
                }
                Console.WriteLine();
            }
        }
        List<string> test;
    }
}
