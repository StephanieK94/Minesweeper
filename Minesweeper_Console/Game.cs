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
            //var path = Directory.GetCurrentDirectory();

            var pathName = "C:\\Users\\StephanieK\\source\\Minesweeper-kata\\Minesweeper_Console\\InputField1.txt";

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

            List<Position> minefieldPositions = new List<Position>();

            minefieldPositions = mineReader.BreakDownMineFieldFrom(inputFieldOne);

            var rowLength = minefieldPositions[0].Row;
            var columnLength = minefieldPositions[0].Column;
            var gameNumber = 1;

            List<string> outputAll = new List<string>();

            outputAll.Add($"Field #{gameNumber}\n");
            outputAll.Add($"{rowLength} {columnLength}\n"); // change to minefieldPositions.Symbol or then remove the minefieldPosition[0]?
            
            List<Position> mineLocations = new List<Position>();
            Locator mineLocator = new Locator();

            mineLocations = mineLocator.GetAllMineLocationsFrom(minefieldPositions);



            foreach(Position currentPosition in minefieldPositions)
            {
                if(currentPosition.Symbol == $"{rowLength} {columnLength}") continue;

                MineFieldReader symbolGenerator = new MineFieldReader();

                string symbol = symbolGenerator.ReturnPositionSymbol(currentPosition, mineLocations);
                
                outputAll.Add(symbol);

                if(currentPosition.Column == columnLength)
                {
                    outputAll.Add("\n");
                }                
            }
            
            string expectedSingleStringOfAll = String.Join("", outputAll);


            Console.WriteLine(expectedSingleStringOfAll);

            // TODO: Refactor this into methods that when read in, will automatically save these as the output
        }
    }
}
