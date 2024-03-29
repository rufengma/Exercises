﻿using System;

namespace Exercise4
{
    class MainClass
    {
        static void printSpiral(int[,] mat, int r, int c)
        {
            int i, a = 0, b = 2;
            int low_row = (0 > a) ? 0 : a;
            int low_column = (0 > b) ? 0 : b - 1;
            int high_row = ((a + 1) >= r) ? r - 1 : a + 1;
            int high_column = ((b + 1) >= c) ? c - 1 : b + 1;
            while ((low_row > 0 - r && low_column > 0 - c))
            {
                for (i = low_column + 1; i <= high_column &&
                                 i < c && low_row >= 0; ++i)
                    Console.Write(mat[low_row, i] + " ");
                low_row -= 1;

                for (i = low_row + 2; i <= high_row && i < r &&
                                          high_column < c; ++i)
                    Console.Write(mat[i, high_column] + " ");
                high_column += 1;

                for (i = high_column - 2; i >= low_column &&
                                i >= 0 && high_row < r; --i)
                    Console.Write(mat[high_row, i] + " ");
                high_row += 1;

                for (i = high_row - 2; i > low_row && i >= 0
                                    && low_column >= 0; --i)
                    Console.Write(mat[i, low_column] + " ");
                low_column -= 1;
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int[,] mat = {{1, 2, 3},
                          {4, 5, 6},
                          {7, 8, 9}};
            int r = 3, c = 3;
            printSpiral(mat, r, c);
        }
    }
}
