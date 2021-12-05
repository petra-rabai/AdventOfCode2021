using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AdventOfCode2021.Properties;

namespace AdventOfCode2021
{
    internal class DataReader
    {
        string filePath = Settings.Default.folderPath;
        string fileName;
        bool directoryExist;
        bool fileExist;

        public string[] InputData { get; set; }

        public void DirectoryCheck() 
        {
            directoryExist = Directory.Exists(filePath);
            if (!directoryExist)
            {
                Directory.CreateDirectory(filePath);
            }
        }


        public string[] ReadInputData(DayChooser dayChooser)
        {
            DirectoryCheck();
            FileCheck(dayChooser);

            string[] lines = File.ReadAllLines(filePath + fileName);
            InputData = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                InputData[i] = lines[i];
            }

            return InputData;
        }

        public void FileCheck(DayChooser dayChooser)
        {
            fileName = dayChooser.FileName;
            fileExist = File.Exists(filePath + fileName);
            if (!fileExist)
            {
                Console.WriteLine("Wrong file name!");
                dayChooser.ReadFilenameFromConsole();
            }
        }
    }
}
