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

        public int[] InputData { get; set; }

        public int[] ReadInputData(DayChooser dayChooser)
        {
            fileName = dayChooser.FileName;

            string[] lines = File.ReadAllLines(filePath+fileName);
            InputData = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                InputData[i] =Convert.ToInt32(lines[i]);
            }

            return InputData; 
        }
    }
}
