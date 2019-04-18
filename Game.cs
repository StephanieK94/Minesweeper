using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper_kata
{
    public class Game
    {
        public static void Main(string[] args)
        {
            var x = 1;

            var mineField = new Position()
            {
                Row = 4,
                Column = 4,
            };

            List<Position> mines = new List<Position>();

            Position mine1 = new Position()
            {
                Row = 1,
                Column = 1
            };

            Position mine2 = new Position()
            {
                Row = 3,
                Column = 2
            };
            
            mines.Add(mine1);
            mines.Add(mine2);

            List<string> outputField = new List<string>();

            outputField.Add($"Field #{x}");
            outputField.Add($"{mineField.Row} {mineField.Column}");
            

            for (int row =1; row<=mineField.Row; row++)
            {
                List<string> outputRows = new List<string>();

                for(int column=1; column<=mineField.Column;column++)
                {
                    var currentPosition = new Position()
                    {
                        Row = row,
                        Column = column,
                    };

                    bool bomb = (currentPosition.Row == mines[0].Row && currentPosition.Column == mines[0].Column) || 
                                (currentPosition.Row == mines[1].Row && currentPosition.Column == mines[1].Column);

                    if(bomb == true)
                    {
                        outputRows.Add("*");  
                    }
                    else
                    {
                        AdjacentNumber mineAdj = new AdjacentNumber();

                        int number = mineAdj.GetNumberOfAdjacentMines(currentPosition, mines);

                        outputRows.Add(number.ToString());  
                    }                
                }
                string singleRow = String.Join(" ", outputRows);
                outputField.Add(singleRow);
            }

            string expectedOutput = String.Join("\n", outputField);

            Console.WriteLine(expectedOutput);
        }
    }
}
