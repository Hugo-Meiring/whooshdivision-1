using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityProvider
{
    /// <summary>
    /// Class is used to read lines from an input file, mostly CSV format.
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FileReader()
        {

        }

        /// <summary>
        /// Creates a file reader that will read from a specific file.
        /// </summary>
        /// <param name="path">Input file's path.</param>
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

        /// <summary>
        /// Method reads the lines from the input file and returns a list of
        /// lines read from the file.
        /// </summary>
        /// <param name="fileName">Input file's path and name.</param>
        /// <returns>List of lines read.</returns>
        public List<string> getLines(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException("fileName", "The file name cannot be null.");

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
                if (currentLine != null && currentLine != "") toBeReturned.Add(currentLine);
            } while (currentLine != null);

            //file.Close();

            return toBeReturned;
        }

        /// <summary>
        /// The file being read.
        /// </summary>
        System.IO.StreamReader file;
    }
}
