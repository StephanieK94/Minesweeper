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
            var gameNumber = 1;

            var path = Directory.GetCurrentDirectory();

            var pathName = $"{path}\\InputField1.txt";

            List<string> inputFieldOne = new List<string>();

            using (StreamReader sr = new StreamReader(pathName))
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    inputFieldOne.Add(line);    // make it have the break down mine field here but make it take in a line and return a list of positions? 
                }
            }

            MineFieldReader mineReader = new MineFieldReader();

            Position gameBoardDimensions = new Position();
            gameBoardDimensions = mineReader.GetFieldDimensions(gameNumber, inputFieldOne[0]);

            List<Position> minefieldPositions = new List<Position>();
            minefieldPositions = mineReader.GetFieldCoordinatesForPositions(gameBoardDimensions, inputFieldOne);

            var rowLength = gameBoardDimensions.Row;
            var columnLength = gameBoardDimensions.Column;

            List<string> outputAll = new List<string>();

            outputAll.Add(gameBoardDimensions.Symbol);
            
            Locator mineLocator = new Locator();

            List<Position> mineLocations = new List<Position>();
            mineLocations = mineLocator.GetAllMineLocationsFrom(minefieldPositions);

            foreach(Position currentPosition in minefieldPositions)
            {
                if(currentPosition.Symbol == gameBoardDimensions.Symbol) continue;

                MineFieldReader symbolGenerator = new MineFieldReader();

                string symbol = symbolGenerator.ReturnPositionSymbol(currentPosition, mineLocations);
                
                outputAll.Add(symbol);

                if(currentPosition.Column == columnLength && currentPosition.Row != rowLength)
                {
                    outputAll.Add("\n");
                }                
            }

            string expectedSingleStringOfAll = String.Join("", outputAll);

            //Console.WriteLine(expectedSingleStringOfAll);
            var pathToName = $"{path}\\OutputField1.txt";

            using(StreamWriter sw = new StreamWriter(pathToName))
            {
                sw.Write(expectedSingleStringOfAll);
            }
        }
    }
}
