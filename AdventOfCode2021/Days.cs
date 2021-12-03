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
                if (dataReader.InputData.ElementAt(i) > dataReader.InputData.ElementAt(i-1))
                {
                    countOfIncrase++;
                }
            }

            Console.WriteLine(countOfIncrase);

            countOfIncrase = 0;
            
            for (int j = 1; j < dataReader.InputData.Length-2; j++)
            {
                firstitem = dataReader.InputData[j-1];
                seconditem = dataReader.InputData[j];
                thirditem = dataReader.InputData[j + 1];
                firstSumGroup = firstitem + seconditem + thirditem;

               
                firstitem = dataReader.InputData[j];
                seconditem = dataReader.InputData[j + 1];
                thirditem = dataReader.InputData[j + 2];
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
            //
        }
    }
}
