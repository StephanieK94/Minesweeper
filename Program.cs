using System;
using System.Linq;
using System.Collections.Generic;

namespace Minesweeper_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var m = 4;

            int[] mine1 = new int[]{1,1};
            int[] mine2 = new int[]{3,2};

            for (int row =1; row<=n; row++)
            {
                for(int column=1; column<=m;column++)
                {
                    int[] currentPosition = new int[]{row,column};

                    bool bomb = currentPosition.SequenceEqual(mine1) || currentPosition.SequenceEqual(mine2);

                    if(bomb == true)
                    {
                        Console.Write("* ");  
                    }
                    else
                    {
                        Console.Write(". ");  
                    }                
                }
                Console.Write("\n");
            }
        }

        public void AdjacentMines(List<int[,]> mineLocations)
        {
            int mineRow = 1;
            int mineColumn = 1;
            int[,] mine1 = new int[mineRow,mineColumn];

            int[,] topLeft = new int[mineRow+1,mineColumn-1];
            int[,] top = new int[mineRow+1,mineColumn];
            int[,] topRight = new int[mineRow+1,mineColumn+1];

            int[,] left = new int[mineRow, mineColumn-1];
            int[,] right = new int[mineRow, mineColumn+1];

            int[,] lowerLeft = new int[mineRow-1,mineColumn-1];
            int[,] below = new int[mineRow-1,mineColumn];
            int[,] lowerRight = new int[mineRow-1,mineColumn+1];

            // change this to an object
            // if the current position is at one of these locations, then will need to add to the number
            // so therefore starts at 0 and does a loop for each mine location, adds +1 if near that mine, 
            // and returns the number once gone through each mine location

            // TODO: create an object of Rows and Columns
            // TODO: rewrite this method so it reads in the mine locations and outputs a number to the variable to then be written to console

        }
    }

    
}
