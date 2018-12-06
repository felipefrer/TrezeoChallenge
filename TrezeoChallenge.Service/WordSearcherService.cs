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
            DicUnknownWord = new Dictionary<string, string>();
            DicKnownWord = new Dictionary<string, string>();
        }

        #endregion

        #region Properties

        private List<string> LstKnownWord;
        private List<string> LstUnknownWord;

        private Dictionary<string, string> DicUnknownWord;
        private Dictionary<string, string> DicKnownWord;

        #endregion

        #region Methods

        /// <summary>
        /// Method responsable for read all file lines.
        /// </summary>
        /// <param name="lstFileLines"></param>
        public void WordsReaderLst(List<string> lstFileLines)
        {
            lstFileLines.ForEach(line => GetWordsUsingList(line));
        }

        public void WordsReaderDic(List<string> lstFileLines)
        {
            lstFileLines.ForEach(line => GetWordsUsingDictionary(line));
        }

        /// <summary>
        /// Method responsable for get UnknownWord and knownWord from the file lines.
        /// </summary>
        /// <param name="line"></param>
        private void GetWordsUsingList(string line)
        {
            var lineWords = line.Split(' ').ToList();

            lineWords.ForEach(word => 
            {
                word = Regex.Replace(word, "[^a-zA-Z]+", "").ToLower();
                
                if (!LstKnownWord.Contains(word) && !LstUnknownWord.Contains(word))
                {
                    LstUnknownWord.Add(word);
                }
                else
                {
                    if (!LstKnownWord.Contains(word))
                    {
                        LstKnownWord.Add(word);
                        LstUnknownWord.Remove(word);
                    }
                }
            });
        }

        /// <summary>
        /// Method responsable for get UnknownWord and knownWord from the file lines.
        /// </summary>
        /// <param name="line"></param>
        private void GetWordsUsingDictionary(string line)
        {
            var lineWords = line.Split(' ').ToList();

            lineWords.ForEach(word =>
            {
                word = Regex.Replace(word, "[^a-zA-Z]+", "");
                var keyWord = word.ToLower();

                if (!DicKnownWord.ContainsKey(keyWord) && !DicUnknownWord.ContainsKey(keyWord))
                {
                    DicUnknownWord.Add(keyWord, word);
                }
                else
                {
                    if (!DicKnownWord.ContainsKey(keyWord))
                    {
                        DicKnownWord.Add(keyWord, word);
                        DicUnknownWord.Remove(keyWord);
                    }
                }
            });
        }

        /// <summary>
        /// Method responsable for find the first unknown file word.
        /// </summary>
        /// <param name="lstFileLines"></param>
        /// <returns></returns>
        public string GetFirstUnknownWordByList(List<string> lstFileLines)
        {
            WordsReaderLst(lstFileLines);

            return LstUnknownWord.FirstOrDefault();
        }

        public string GetFirstUnknownWordByDictionary(List<string> lstFileLines)
        {
            WordsReaderDic(lstFileLines);

            return DicUnknownWord.FirstOrDefault().Value;
        }

        #endregion
    }
}
