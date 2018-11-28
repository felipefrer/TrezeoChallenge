using System.Collections.Generic;
using System.Linq;

namespace TrezeoChallenge.Service
{
    public class FileReaderService
    {
        #region Constructors

        public FileReaderService(string filePath)
        {
            FilePath = filePath;
        }

        #endregion

        #region Properties

        private string FilePath { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Method responsable to return all .txt file lines.
        /// </summary>
        /// <param name="filePath"></param>
        public List<string> GetTxtFileLines()
        {
            string[] fileLines = System.IO.File.ReadAllLines(FilePath);

            return fileLines.ToList();

        }

        #endregion
    }
}
