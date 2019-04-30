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
        string col = $"{header[0]}";

        fieldDimensions.Row = Convert.ToInt32(row);
        fieldDimensions.Column = Convert.ToInt32(col);
        fieldDimensions.Symbol = $"Field `#{gameNumber}`\n";

        return fieldDimensions;
    }
    public List<Position> GetFieldCoordinatesForPositions(Position fieldDimensions, List<string> fieldRows)
    {
        List<Position> coordinatesForSymbols = new List<Position>();

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