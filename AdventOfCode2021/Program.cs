using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataReader dataReader = new DataReader();
            DayChooser dayChooser = new DayChooser();
            Days days = new Days();
            dayChooser.ReadDayFromConsole();
            dayChooser.ReadFilenameFromConsole();
            dataReader.ReadInputData(dayChooser);
            days.DayTwo(dataReader);
            dayChooser.SelectDay(days,dataReader);
        }
    }
}
