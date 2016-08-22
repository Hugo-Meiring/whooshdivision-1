using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityProvider
{
    public class FileReader
    {
        public FileReader()
        {
        }

        public FileReader(string path)
        {
            try
            {
                file = new System.IO.StreamReader(path);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<string> getLines(string fileName)
        {
            if (fileName == null) throw new NullReferenceException();

            List<string> toBeReturned = new List<string>();
            string currentLine = "";
            try
            {
                if (file == null) file = new System.IO.StreamReader(fileName);
            }
            catch(Exception e)
            {
                throw e;
            }

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
