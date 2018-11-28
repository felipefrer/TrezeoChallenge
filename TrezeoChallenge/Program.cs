using System;
using TrezeoChallenge.Service;

namespace TrezeoChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new FileReaderService(@"P:\Trezeo\TrezeoChallenge\file.txt");

            var searchWord = new WordSearcherService();
            var firstUnknownWord = searchWord.GetFirstUnknownWord(file.GetTxtFileLines());

            Console.WriteLine(firstUnknownWord);

            Console.ReadKey();
        }
    }
}
