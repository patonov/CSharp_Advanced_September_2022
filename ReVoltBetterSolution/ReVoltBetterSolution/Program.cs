using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
					
public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
        int numOfComms = int.Parse(Console.ReadLine());
		int firstRow = 0;
		int firstCol = 0;
		bool hasWon = false;
				
		char[,] matrix = new char[n, n];
					
		for (int row = 0; row < n; row++)
            {
               char[] curRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = curRow[col];
					if (matrix[row, col] == 'f')
					{
					firstRow = row;
					firstCol = col;
					}
                }
            }
		int currentRow = firstRow;
		int currentCol = firstCol;
		
		for (int i = 0; i < numOfComms; i++)
        {
        string command = Console.ReadLine();
		
		matrix[currentRow, currentCol] = '-';
			
		currentRow = MoveRow(currentRow, command);
		currentCol = MoveCol(currentCol, command);				
			if (!IsValid(currentRow, currentCol, n))
			{
				if (currentRow >= n)
				{
				currentRow = 0;
				}
				else if (currentRow < 0)
				{
				currentRow = n - 1;
				}
				if (currentCol >= n)
				{
				currentCol = 0;
				}
				else if (currentCol < 0)
				{
				currentCol = n - 1;
				}			
			}
			
			
			if (matrix[currentRow, currentCol] == 'B')
			{
			currentRow = MoveRow(currentRow, command);
			currentCol = MoveCol(currentCol, command);
				if (!IsValid(currentRow, currentCol, n))
				{
					if (currentRow >= n)
					{
					currentRow = 0;
					}
					else if (currentRow < 0)
					{
					currentRow = n - 1;
					}
					if (currentCol >= n)
					{
					currentCol = 0;
					}
					else if (currentCol < 0)
					{
					currentCol = n - 1;
					}			
				}
			}
			if (matrix[currentRow, currentCol] == 'T')
			{
				if (command == "down")
				{
				command = "up";
				}
				else if (command == "up")
				{
				command = "down";
				}
				else if (command == "right")
				{
				command = "left";
				}
				else if (command == "left")
				{
				command = "right";
				}
			currentRow = MoveRow(currentRow, command);
			currentCol = MoveCol(currentCol, command);
			}
			if (matrix[currentRow, currentCol] == 'F')
			{
				Console.WriteLine("Player won!");
				matrix[currentRow, currentCol] = 'f';
				hasWon = true;
				break;
			}
			
			if (i == numOfComms - 1)
			{
			matrix[currentRow, currentCol] = 'f';
			}
			
        }
		
		if (hasWon == false)
		{
		Console.WriteLine("Player lost!");
		}
		
		for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
            Console.Write(matrix[row, col]);
			}
			Console.WriteLine();
        }

     
	}
	public static bool IsValid(int row, int col, int n)
        {
            if (row < 0 || row >= n)
            {
                return false;
            }
            if (col < 0 || col >= n)
            {
                return false;
            }
            return true;
        }
	
	public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }

            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "right")
            {
                return col + 1;
            }

            if (movement == "left")
            {
                return col - 1;
            }

            return col;

        }
}
