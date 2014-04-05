using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a n x n square with white(1) and black(0) cells,
// Design an algorithm to find the maximum subsquare such that 
// all four borders are filled with black pixels.
namespace MaximumSubSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] input = {
                               {1, 1, 1, 0},
                               {1, 0, 0, 0},
                               {1, 0, 1, 0},
                               {1, 0, 0, 0}
                           };


            int[,] result = FindMaximumSubSquare(input);

            if (result == null)
            {
                Console.WriteLine("No sqaure found");
            }
            else
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        Console.Write(result[i, j] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }

        static int[,] FindMaximumSubSquare(int[,] square)
        {
            int[,] maxSubSquare = null;
            int maxSize = 0;

            // For a given column and row, check the square with size
            // decreasing in value. Hence 3 for loops. one for the column,
            // one for row and one for size.
            for (int column = 0; column < square.GetLength(1); column++)
            {
                for (int row = 0; row < square.GetLength(0); row++)
                {
                    for (int size = square.GetLength(0) - Math.Max(row, column); size >= 0; size--)
                    {
                        if (IsValidSubSquare(square, row, column, size))
                        {
                            if (size > maxSize)
                            {
                                maxSubSquare = GetSubMatrix(square, row, column, size);
                                maxSize = size;
                            }
                        }
                    }
                }
            }

            return maxSubSquare;
        }

        static bool IsValidSubSquare(int[,] square, int row, int column, int size)
        {
            // Check top row 
            for(int i = column; i < column + size; i++)
            {
                if (square[row, i] == 1)
                {
                    return false;
                }
            }

            // check right most column
            for (int i = row; i < row + size; i++)
            {
                if (square[i, column] == 1)
                {
                    return false;
                }
            }

            // check bottom row
            for (int i = column + size - 1; i >= column; i--)
            {
                if (square[row + size - 1, i] == 1)
                {
                    return false;
                }
            }

            // check left most row
            for (int i = row + size - 1; i >= row; i--)
            {
                if (square[i, column] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        static int[,] GetSubMatrix(int[,] square, int row, int column, int size)
        {
            int[,] result = new int[size, size];

            for (int i = row, newRow = 0; i < row + size; i++, newRow++)
            {
                for (int j = column, newColumn = 0; j < column + size; j++, newColumn++)
                {
                    result[newRow, newColumn] = square[i, j];
                }
            }

            return result;
        }
    }
}
