using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int[,] grid = new int[5, 5];
            for (int r = 0; r < 5; ++r)
            {
                for (int c = 0; c < 5; ++c)
                {

                    grid[r, c] = rd.Next(1,25);
                }
            }


            ShowGrid(grid);
            Console.WriteLine(@"Ex. 7, 9, 20, 3, 12");
            Console.Write(@"Input :");
            string str = Console.ReadLine();
            int[] inputList = Array.ConvertAll(str.Split(','), s => int.Parse(s));

            var won = AnyVertical(grid, inputList) || AnyHorizontal(grid, inputList) || AnyDiagonal(grid, inputList);

            if (won)
                Console.WriteLine(@"Bingo");
            else
                Console.WriteLine(@"Not Bingo");
        }

        private static bool AnyVertical(int[,] grid, int[] inputList)
        {
            for (int row = 0; row < 5; row++)
            {
                int[] colList = Enumerable.Range(0, grid.GetLength(0))
                .Select(x => grid[row, x])
                .ToArray();
                if (inputList.All(x => colList.Contains(x)))
                {
                    return true;
                }
            };
            return false;
        }

        private static bool AnyDiagonal(int[,] grid, int[] inputList)
        {

            List<int> list = new List<int>()
            {
                grid[0, 0],
                grid[1, 1],
                grid[2, 2],
                grid[3, 3],
                grid[4, 4]
            };
            List<int> list2 = new List<int>()
            {
                grid[0, 4],
                grid[1, 3],
                grid[2, 2],
                grid[3, 1],
                grid[4, 0]
            };


            if (inputList.All(x => list.Contains(x)) ||
                inputList.All(x => list2.Contains(x)))
                return true;
            else
                return false;
        }


        private static bool AnyHorizontal(int[,] grid, int[] inputList)
        {

            for (int col = 0; col < 5; col++)
            {
                int[] colList = Enumerable.Range(0, grid.GetLength(0))
                .Select(x => grid[x, col])
                .ToArray();
                if (inputList.All(x => colList.Contains(x)))
                {
                    return true;
                }
            };
            return false;
        }
        static void ShowGrid(int[,] g)
        {
            for (int r = 0; r < 5; ++r)
            {
                for (int c = 0; c < 5; ++c)
                {
                    Console.Write(" [{0}] ", g[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
