using System;
using TrezeoChallenge.Service;

namespace TrezeoChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Environment.CurrentDirectory + @"\file.txt";

            var file = new FileReaderService(filePath);

            var searchWord = new WordSearcherService();
            var firstUnknownWord = searchWord.GetFirstUnknownWord(file.GetTxtFileLines());

            Console.WriteLine("The first non-repeated word is: " + firstUnknownWord);

            Console.ReadKey();
        }
    }
}
