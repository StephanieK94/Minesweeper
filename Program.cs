using System;

namespace Minesweeper_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var m = 4;

            int[,] x = new int[n,m];

            var mine1 = new int[1,1];
            var mine2 = new int[3,2];

            for (int i =1; i<=n; i++)
            {
                for(int j=1; j<=m;j++)
                {
                    Console.Write(". ");
                }

                Console.Write("\n");
            }
        }
    }
}
