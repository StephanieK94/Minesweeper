using System;
using System.Collections.Generic;
using System.Linq;

public class MineFieldReader
{
    public List<Position> BreakDownMineFieldFrom(List<string> fieldRows)
    {
        List<Position> coordinatesForSymbols = new List<Position>();

        Position fieldDimensions = new Position();

        var header = fieldRows[0].Split(" ");

        fieldDimensions.Row = Convert.ToInt32(header[0]);
        fieldDimensions.Column = Convert.ToInt32(header[1]);
        fieldDimensions.Symbol = fieldRows[0];

        coordinatesForSymbols.Add(fieldDimensions);

        for(int x=1; x<=fieldDimensions.Row; x++)
        {
            for(int y = 1; y <= fieldDimensions.Column; y++)
            {
                Position fieldPoint = new Position();

                char[] line = fieldRows[x].ToCharArray();

                fieldPoint.Row = x;
                fieldPoint.Column = y;
                fieldPoint.Symbol = line[y-1].ToString();

                coordinatesForSymbols.Add(fieldPoint);
            }
        }
        return coordinatesForSymbols;
    }

    public string ReturnPositionSymbol(Position currentPosition, List<Position> mineLocations)
    {
        string answer;

        if(currentPosition.Symbol == "*") 
        {
            answer = currentPosition.Symbol.ToString();
        }
        else
        {
            AdjacentCalculator adjacentCalculator = new AdjacentCalculator();

            answer = adjacentCalculator.GetNumberOfAdjacentMines(currentPosition, mineLocations);
        }

        return answer;
    }
}