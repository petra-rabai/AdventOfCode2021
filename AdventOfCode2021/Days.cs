using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Days
    {
        public void DayOne(DataReader dataReader)
        {
            int countOfIncrase = 0;
            int firstSumGroup;
            int firstitem;
            int seconditem;
            int thirditem;
            int secondSumGroup;
          
            for (int i = 1; i < dataReader.InputData.Length; i++)
            {
                if (Convert.ToInt32(dataReader.InputData.ElementAt(i)) > Convert.ToInt32( dataReader.InputData.ElementAt(i-1)))
                {
                    countOfIncrase++;
                }
            }

            Console.WriteLine(countOfIncrase);

            // Part Two
            
            countOfIncrase = 0;
            
            for (int j = 1; j < dataReader.InputData.Length-2; j++)
            {
                firstitem = Convert.ToInt32(dataReader.InputData[j-1]);
                seconditem = Convert.ToInt32(dataReader.InputData[j]);
                thirditem = Convert.ToInt32(dataReader.InputData[j + 1]);
                firstSumGroup = firstitem + seconditem + thirditem;

               
                firstitem = Convert.ToInt32(dataReader.InputData[j]);
                seconditem = Convert.ToInt32(dataReader.InputData[j + 1]);
                thirditem = Convert.ToInt32(dataReader.InputData[j + 2]);
                secondSumGroup = firstitem + seconditem + thirditem;

                if (secondSumGroup> firstSumGroup)
                {
                    countOfIncrase++;
                }

            }

            Console.WriteLine(countOfIncrase);

        }

        public void DayTwo(DataReader dataReader)
        {
            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;
            string[] way;
            string direction;
            foreach (var item in dataReader.InputData)
            {
                way = new string[dataReader.InputData.Length];
                string lineCoordinate = item;
                way = lineCoordinate.Split(' ');
                direction = way[0];
                int wayNumber = Convert.ToInt32(way[1]);
                switch (direction)
                {
                    case "forward":
                        horizontalPosition += wayNumber;  
                        break;
                    case "up":                       
                       depth -= wayNumber;
                        break;
                    case "down":                       
                        depth += wayNumber;
                        break;
                    default:
                        break;
                }
            }

            int finalplan = horizontalPosition * depth;

            Console.WriteLine(finalplan);
            
            // Part Two

            horizontalPosition = 0;
            depth = 0;
            finalplan = 0;

            foreach (var item in dataReader.InputData)
            {
                way = new string[2];
                string lineCoordinate = item;
                way = lineCoordinate.Split(' ');
                direction = way[0];
                int wayNumber = Convert.ToInt32(way[1]);
                switch (direction)
                {
                    case "forward":
                        horizontalPosition += wayNumber;
                        depth += wayNumber * aim;
                        break;
                    case "up":
                        aim -= wayNumber;
                        break;
                    case "down":
                        aim += wayNumber;
                        break;
                    default:
                        break;
                }
            }

            finalplan = horizontalPosition * depth;

            Console.WriteLine(finalplan);

        }

        public void DayThree(DataReader dataReader)
        {
            string gammaRate;
            string epsilonRate;
            int lineCount;
            string binaryReportLine;

            foreach (var item in dataReader.InputData)
            {
                binaryReportLine = item;
                lineCount = binaryReportLine.Length;
                
            }


        }
    }
}
