using System;
using System.Collections.Generic;
using System.Linq;

public class MineFieldReader
{    
    public Position GetFieldDimensions(int gameNumber, string fieldRowHeader)
    {
        Position fieldDimensions = new Position();

        char[] header = fieldRowHeader.ToCharArray();
        string row = $"{header[0]}";
        string col = $"{header[1]}";

        fieldDimensions.Row = Convert.ToInt32(row);
        fieldDimensions.Column = Convert.ToInt32(col);
        fieldDimensions.Symbol = $"Field `#{gameNumber}`:\n";

        return fieldDimensions;
    }
    public List<Position> GetFieldCoordinatesForPositions(Position fieldDimensions, List<string> fieldRows)
    {
        List<Position> positionCoordinates = new List<Position>();

        for(int x=1; x<=fieldDimensions.Row; x++)
        {
            for(int y = 1; y <= fieldDimensions.Column; y++)
            {
                Position currentPoint = new Position();

                char[] line = fieldRows[x].ToCharArray();

                currentPoint.Row = x;
                currentPoint.Column = y;
                currentPoint.Symbol = line[y-1].ToString();

                positionCoordinates.Add(currentPoint);
            }
        }
        return positionCoordinates;
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