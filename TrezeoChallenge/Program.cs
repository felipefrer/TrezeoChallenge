using System;
using System.Collections.Generic;
using TrezeoChallenge.Service;

namespace TrezeoChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Environment.CurrentDirectory + @"\file.txt";

            var file = new FileReaderService(filePath);


            Console.WriteLine("Processing file using list");
            ProcessFile(file.GetTxtFileLines(), true);

            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Processing file using dictionary");
            ProcessFile(file.GetTxtFileLines(), false);

            Console.ReadKey();
        }

        public static void ProcessFile(List<string> files, bool IsLst)
        {
            var searchWord = new WordSearcherService();

            var startTime = DateTime.Now;
            Console.WriteLine("Start time: " + startTime.TimeOfDay);
            var firstNonRepeated = IsLst ? searchWord.GetFirstUnknownWordByList(files) : searchWord.GetFirstUnknownWordByDictionary(files);
            var finishTime = DateTime.Now;
            Console.WriteLine("Finish time: " + finishTime.TimeOfDay);
            Console.WriteLine("The first non-repeated word is: " + firstNonRepeated);
            Console.WriteLine("Total time: " + GetTotalTime(startTime, finishTime));
        }

        public static double GetTotalTime(DateTime startDate, DateTime finishDate)
        {
            long totalTicks = finishDate.Ticks - startDate.Ticks;
            TimeSpan totalTime = new TimeSpan(totalTicks);
            return totalTime.TotalSeconds;
        }
    }
}
