using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Minesweeper_kata
{
    public class Game
    {
        public static void Main(string[] args)
        {
            var games = 3;

            for(var x =1; x <= games; x++)
            {
                var pathName = $"C:\\Users\\StephanieK\\source\\Minesweeper-kata\\InputField{x}.txt";

                List<string> inputField = new List<string>();

                using (StreamReader sr = new StreamReader(pathName))
                {
                    string line;

                    while((line = sr.ReadLine()) != null)
                    {
                        inputField.Add(line);    // make it have the break down mine field here but make it take in a line and return a list of positions? 
                    }
                }
                MineFieldReader mineReader = new MineFieldReader();

                Position gameBoardDimensions = new Position();
                gameBoardDimensions = mineReader.GetFieldDimensions(x, inputField[0]);

                var rowLength = gameBoardDimensions.Row;
                var columnLength = gameBoardDimensions.Column;
                var title = gameBoardDimensions.Symbol;

                List<string> outputAll = new List<string>();

                outputAll.Add(gameBoardDimensions.Symbol);

                if(gameBoardDimensions.Row == 0 || gameBoardDimensions.Column == 0) continue;

                List<Position> minefieldPositions = new List<Position>();
                minefieldPositions = mineReader.GetFieldCoordinatesForPositions(gameBoardDimensions, inputField);
                
                Locator mineLocator = new Locator();
                List<Position> mineLocations = new List<Position>();
                mineLocations = mineLocator.GetAllMineLocationsFrom(minefieldPositions);

                foreach(Position currentPosition in minefieldPositions)
                {
                    if(currentPosition.Symbol == title) continue;

                    MineFieldReader symbolGenerator = new MineFieldReader();

                    string symbol = symbolGenerator.ReturnPositionSymbol(currentPosition, mineLocations);
                    
                    outputAll.Add(symbol);

                    if(currentPosition.Column == columnLength)
                    {
                        outputAll.Add("\n");
                    }                
                }

                string expectedSingleStringOfAll = String.Join("", outputAll);

                var pathToName = $"C:\\Users\\StephanieK\\source\\Minesweeper-kata\\OutputFields.txt";

                using(StreamWriter sw = new StreamWriter(pathToName, true))
                {
                    sw.WriteLine(expectedSingleStringOfAll);
                }
            }
        }    
    }
}
