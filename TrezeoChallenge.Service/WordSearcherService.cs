using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrezeoChallenge.Service
{
    public class WordSearcherService
    {
        #region Constructors

        public WordSearcherService()
        {
            LstKnownWord = new List<string>();
            LstUnknownWord = new List<string>();
        }

        #endregion

        #region Properties

        private List<string> LstKnownWord;
        private List<string> LstUnknownWord;

        #endregion

        #region Methods

        /// <summary>
        /// Method responsable for read all file lines.
        /// </summary>
        /// <param name="lstFileLines"></param>
        public void WordsReader(List<string> lstFileLines)
        {
            lstFileLines.ForEach(line => GetWords(line));
        }

        /// <summary>
        /// Method responsable for get UnknownWord and knownWord from the file lines.
        /// </summary>
        /// <param name="line"></param>
        private void GetWords(string line)
        {
            var lineWords = line.Split(' ').ToList();

            lineWords.ForEach(word => 
            {
                word = Regex.Replace(word, "[^a-zA-Z]+", "");
                
                if (!LstUnknownWord.Contains(word.ToLower()))
                {
                    LstUnknownWord.Add(word.ToLower());
                }
                else
                {
                    if (!LstKnownWord.Contains(word))
                    {
                        LstKnownWord.Add(word);
                    }
                }
            });
        }

        /// <summary>
        /// Method responsable for find the first unknown file word.
        /// </summary>
        /// <param name="lstFileLines"></param>
        /// <returns></returns>
        public string GetFirstUnknownWord(List<string> lstFileLines)
        {
            WordsReader(lstFileLines);

            var lstResult = LstUnknownWord.Except(LstKnownWord).ToList(); ;

            return lstResult.FirstOrDefault();
        }

        #endregion
    }
}
