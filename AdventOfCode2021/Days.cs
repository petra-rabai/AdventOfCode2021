﻿using System;
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

        public int DayThree(DataReader dataReader)
        {
            string[] gammaRate = new string[12];
            string[] epsilonRate = new string[12];
            int countZero = 0;
            int countOne = 0;
            string binaryReportLine;
            char riports;
            int powerConsuption = 0;
            int epsilonRate10;
            int gammaRate10;
            string epsilonString;
            string gammaString;

            for (int x = 0; x < dataReader.InputData[0].Length; x++)
            {
                foreach (var item in dataReader.InputData)
                {
                    binaryReportLine = item;
                    riports = binaryReportLine.ToCharArray()[x];

                        if (riports == '0')
                        {
                            countZero++;
                        }
                        if (riports == '1')
                        {
                            countOne++;
                        } 
                }

                gammaRate[x] += (countOne > countZero) ? "1" : "0";
                epsilonRate[x] += (countOne > countZero) ? "0" : "1";

            }
            epsilonString = epsilonRate[0].ToString();
            gammaString = gammaRate[0].ToString();

            for (int i = 0; i < epsilonRate.Length; i++)
            {
                epsilonString += epsilonRate[i].ToString();
                gammaString += gammaRate[i].ToString();

            }

            epsilonRate10 = Convert.ToInt32(epsilonString, 2);
            gammaRate10 = Convert.ToInt32(gammaString, 2);

            powerConsuption = gammaRate10 * epsilonRate10;

            return powerConsuption;
        }
    }
}
