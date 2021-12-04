using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class DayChooser
    {
        public string ChoosedDay { get; set; }
        public string FileName { get; set; }

        public string ReadDayFromConsole()
        {
            Console.WriteLine("Welcome to Advent of Code 2021\n" + "Choose the which day puzzle can you see (example: Day 1): \n" );
            ChoosedDay = Console.ReadLine();
            return ChoosedDay ; 
        }

        public string ReadFilenameFromConsole()
        {
            Console.WriteLine("Choose the Input data file for the puzzle can you see (example: Day1Input.txt): \n");
            FileName = Console.ReadLine();
            return FileName;
        }

        public void SelectDay(Days days, DataReader dataReader)
        {
            switch (ChoosedDay)
            {
                case "Day 1":
                    days.DayOne(dataReader);
                    break;
                case "Day 2":
                    days.DayTwo(dataReader);
                    break;
                case "Day 3":
                    days.DayThree(dataReader);
                    break;
                default:
                    break;
            }
        }
    }
}