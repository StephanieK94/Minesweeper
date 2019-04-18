using System;
using System.Collections.Generic;
using System.Linq;
using Minesweeper;

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

    public class AdjacentLocation
    {
        public List<Position> GetAdjacentLocations(Position mine)
        {
            List<Position> adjacentToMine = new List<Position>();

            Position above = new Position(){ Row = mine.Row-1, Column = mine.Column };
            Position topLeft = new Position(){ Row = mine.Row-1, Column = mine.Column-1};
            Position topRight = new Position(){ Row = mine.Row-1, Column = mine.Column+1};
            Position left = new Position(){ Row = mine.Row, Column =  mine.Column-1};
            Position right = new Position(){ Row = mine.Row, Column =  mine.Column+1};
            Position below = new Position(){ Row = mine.Row+1, Column = mine.Column};
            Position lowerLeft  = new Position(){ Row = mine.Row+1, Column = mine.Column-1};
            Position lowerRight = new Position(){ Row = mine.Row+1, Column = mine.Column+1};

            adjacentToMine.Add(above);
            adjacentToMine.Add(topLeft);
            adjacentToMine.Add(topRight);
            adjacentToMine.Add(left);
            adjacentToMine.Add(right);
            adjacentToMine.Add(below);
            adjacentToMine.Add(lowerLeft);
            adjacentToMine.Add(lowerRight);

            return adjacentToMine;
        }
    }

      public class AdjacentNumber
    {
        public int GetNumberOfAdjacentMines(Position current, List<Position> mineLocations)
        {
            var numberAdjacentBombs =0;

            foreach(var mine in mineLocations)
            {
                List<Position> safeLocations = new List<Position>();
                
                AdjacentLocation location = new AdjacentLocation();

                safeLocations =  location.GetAdjacentLocations(mine);
                
                foreach(Position safeLocation in safeLocations)
                {
                    if(current.Row == safeLocation.Row && current.Column == safeLocation.Column)
                    {
                        numberAdjacentBombs++;
                    }
                }                
            }
            return numberAdjacentBombs;
        }
    }

    public class Position
    {
        public int Row {get; set;}
        public int Column {get; set;}
    }
}
