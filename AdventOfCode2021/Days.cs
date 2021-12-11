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

            string gammaRate = "";
            string epsilonRate = "";            
            char riportBit;
            int powerConsuption = 0;
            int epsilonRate10;
            int gammaRate10;

            int lifeSupportRate;
            List<string> oxygenGenerator = new List<string>();
            List<string> co2Scrubber = new List<string>();
            char bitCriteria = ' ';
            int oxygenGeneratorRate10;
            int co2ScrubberRate10;
            string oxygenGeneratorRate = "";
            string co2ScrubberGeneratorRate = "";



            for (int j = 0; j < dataReader.InputData[0].Length; j++)
            {
                int countZero = 0;
                int countOne = 0;
                foreach (var item in dataReader.InputData)
                {
                    riportBit = item.ToCharArray()[j];
                    if (riportBit == '0')
                    {
                        countZero++;
                    }
                    if (riportBit == '1')
                    {
                        countOne++;
                    }
                }
                if (countOne > countZero)
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
               else
               {
                    gammaRate += "0";
                    epsilonRate += "1";
               }

            }

            epsilonRate10 = Convert.ToInt32(epsilonRate, 2);
            gammaRate10 = Convert.ToInt32(gammaRate, 2);

            powerConsuption = gammaRate10 * epsilonRate10;

            // Part Two
            oxygenGenerator = dataReader.InputData.ToList();
            co2Scrubber = dataReader.InputData.ToList();

            for (int i = 0; i < dataReader.InputData[0].Length; i++)
            {
                int countZero = 0;
                int countOne = 0;

                bitCriteria = oxygenGenerator.Count(c => c[i] == '1') >= oxygenGenerator.Count(c => c[i] == '0') ? '1' : '0';
                oxygenGenerator.RemoveAll(x => x[i] != bitCriteria);

                if (oxygenGenerator.Count == 1) break;



            }

            for (var i = 0; i < dataReader.InputData[0].Length; i++)
            {
                bitCriteria = co2Scrubber.Count(c => c[i] == '1') < co2Scrubber.Count(c => c[i] == '0') ? '1' : '0';

                co2Scrubber.RemoveAll(x => x[i] != bitCriteria);

                if (co2Scrubber.Count == 1) break;
            }


            oxygenGeneratorRate10 = Convert.ToInt32(oxygenGenerator.First(), 2);
            co2ScrubberRate10 = Convert.ToInt32(co2Scrubber.First(), 2);

            lifeSupportRate = oxygenGeneratorRate10 * co2ScrubberRate10;

            Console.WriteLine();
        }

       

    }
}
