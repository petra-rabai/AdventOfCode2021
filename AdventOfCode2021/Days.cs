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

        public void DayFour(DataReader dataReader)
        {
            string[] bingoNumbers = dataReader.InputData[0].Split(',');
            int[] inputs = (Array.ConvertAll(bingoNumbers, bingonumber=> Convert.ToInt32(bingonumber)));
            List<string[][]> finalBingoBoard = GetBoards(dataReader.InputData);
            SolvePartOne(finalBingoBoard, inputs);
            SolvePartTwo(finalBingoBoard, inputs);
        }

        private static List<string[][]> GetBoards(string[] input)
        {
            List<List<string[]>> allBingoBoards = new List<List<string[]>>();
            List<string[]> currentBingoBoard = null;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == "")
                {
                    allBingoBoards.Add(currentBingoBoard);
                    currentBingoBoard = new List<string[]>();
                    continue;
                }

                List<string> row = input[i].Split(' ').ToList();
                row.RemoveAll(x => x == "");

                string[] generateRowToBoard = row.ToArray();
                currentBingoBoard.Add(generateRowToBoard);
            }

            allBingoBoards.Add(currentBingoBoard);
            allBingoBoards.RemoveAt(0);

            List<string[][]> boardsStructre = new List<string[][]>();
            foreach (var current in allBingoBoards)
            {
                boardsStructre.Add(current.ToArray());
            }

            return boardsStructre;
        }

        private static object SolvePartOne(List<string[][]> allBingoBoards, int[] combinations)
        {
            int result = 0;
            for (int number = 0; number < combinations.Length; number++)
            {
                int boardNumber = 0;
                foreach (string[][] currentBoard in allBingoBoards)
                {
                    for (int row = 0; row < currentBoard.Length; row++)
                    {
                        for (int column = 0; column < 5; column++)
                        {
                            if (currentBoard[row][column] != "X" && Int32.Parse(currentBoard[row][column]) == combinations[number])
                            {
                                currentBoard[row][column] = "X";
                            }
                        }
                    }

                    boardNumber++;
                }

                if (combinations[number] > 5)
                {
                    int others = CheckIfAnyWin(allBingoBoards);
                    if (others != -1)
                    {
                        result = others * combinations[number];
                        break;
                    }
                }
            }

            return result;
        }

        private static object SolvePartTwo(List<string[][]> boards, int[] combinations)
        {
            int largestWinRound = 0;
            int result = 0;
            foreach (string[][] board in boards)
            {
                int boardWinRound = 0;
                List<string[][]> ad = new List<string[][]>() { board };
                for (int number = 0; number < combinations.Length; number++)
                {
                    for (int row = 0; row < board.Length; row++)
                    {
                        for (int column = 0; column < 5; column++)
                        {
                            if (board[row][column] != "X" && Int32.Parse(board[row][column]) == combinations[number])
                            {
                                board[row][column] = "X";
                            }
                        }
                    }

                    if (combinations[number] > 5)
                    {
                        int others = CheckIfAnyWin(ad);
                        if (others != -1)
                        {
                            if (boardWinRound > largestWinRound)
                            {
                                largestWinRound = boardWinRound;

                                boardWinRound = 0;
                                result = others * combinations[number];
                            }

                            break;
                        }
                    }

                    boardWinRound++;
                }
            }

            return result;
        }

        private static int CheckIfAnyWin(List<string[][]> finalBingoBoard)
        {
            int found = -1;
            int result = -1;
            for (int boardNumber = 0; boardNumber < finalBingoBoard.Count; boardNumber++)
            {
                string[][] currentBingoBoard = finalBingoBoard[boardNumber];
                for (int index = 0; index < currentBingoBoard.Length; index++)
                {
                    if (currentBingoBoard[index].All(x => x == "X") || currentBingoBoard.Select(x => x[index]).All(x => x == "X"))
                    {
                        found = boardNumber;
                    }
                }
            }

            if (found != -1)
            {
                var otherNumbers = finalBingoBoard[found].SelectMany(x => x).Where(x => x != "X").ToArray();
                result = (Array.ConvertAll(otherNumbers, z => Int32.Parse(z))).Sum();
            }

            return result;
        }
    }
}
