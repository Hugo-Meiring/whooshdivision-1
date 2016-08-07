using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProvider
{
    abstract class FileReader
    {
        public FileReader()
        {
        }

        public FileReader(string path)
        {
            file = new System.IO.StreamReader(path);
        }

        public List<string> getLines(string fileName)
        {
            if (fileName == null) throw new NullReferenceException();

            List<string> toBeReturned = new List<string>();
            string currentLine = "";
            if (file == null) file = new System.IO.StreamReader(fileName);

            do
            {
                currentLine = file.ReadLine();
                if (currentLine != null) toBeReturned.Add(currentLine);
            } while (currentLine != null);

            file.Close();

            return toBeReturned;
        }

        System.IO.StreamReader file;
    }
}
