using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2021
{
    internal class DataReader
    {
        string filePath = "C:\\source\\repos\\petra-rabai\\AdventOfCode2021\\AdventOfCode2021\\";
        string fileName;

        public string[] InputData { get; set; }

        public string[] ReadInputData(DayChooser dayChooser)
        {
            fileName = dayChooser.FileName;

            string[] lines = File.ReadAllLines(filePath+fileName);
            InputData = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                InputData[i] =lines[i];
            }

            return InputData; 
        }
    }
}
