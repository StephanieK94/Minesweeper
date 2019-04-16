﻿using System;
using System.Linq;

namespace Minesweeper_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var m = 4;

            int[] mine1 = new int[]{1,1};
            //int[] mine2 = new int[]{3,2};

            for (int i =1; i<=n; i++)
            {
                for(int j=1; j<=m;j++)
                {
                    int[] currentPosition = new int[]{i,j};

                    //Boolean boom = currentPosition == mine1; //|| currentPosition == mine2;

                    if(currentPosition.SequenceEqual(mine1))
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
    }
}
