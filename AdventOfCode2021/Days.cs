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
            int secondSumGroup;

            for (int i = 1; i < dataReader.InputData.Length; i++)
            {
                if (dataReader.InputData.ElementAt(i) > dataReader.InputData.ElementAt(i-1))
                {
                    countOfIncrase++;
                }
            }
            countOfIncrase = 0;
            
            for (int j = 1; j < dataReader.InputData.Length; j += 3)
            {
                if (j + 3 < dataReader.InputData.Length)
                {
                    firstSumGroup = dataReader.InputData.ElementAt(j) + dataReader.InputData.ElementAt(j - 1) + dataReader.InputData.ElementAt(j + 2);
                    secondSumGroup = dataReader.InputData.ElementAt(j + 1) + dataReader.InputData.ElementAt(j + 2) + dataReader.InputData.ElementAt(j + 3);
                    if (secondSumGroup > firstSumGroup)
                    {
                        countOfIncrase++;
                    }
                }
                
               
            }

            Console.WriteLine(countOfIncrase);
        }

        public void DayTwo()
        {
            //
        }
    }
}
