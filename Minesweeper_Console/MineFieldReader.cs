using System;
using System.Collections.Generic;

public class MineFieldReader
{
    public List<Position> BreakDownMineFieldFrom(List<string> fieldLines)
    {
        List<Position> coordinatesForSymbols = new List<Position>();

        Position fieldDimensions = new Position();

        var header = fieldLines[0].Split(" ");

        fieldDimensions.Row = Convert.ToInt32(header[0]);
        fieldDimensions.Column = Convert.ToInt32(header[1]);
        fieldDimensions.Symbol = fieldLines[0];

        coordinatesForSymbols.Add(fieldDimensions);

        for(int x=1; x<=fieldDimensions.Row; x++)
        {
            for(int y =1; y<=fieldDimensions.Column; y++)
            {
                Position fieldPoint = new Position();

                var line = fieldLines[x].Split("");

                fieldPoint.Row = x;
                fieldPoint.Column = y;
                fieldPoint.Symbol = line[y-1];

                coordinatesForSymbols.Add(fieldPoint);
            }
        }
        return coordinatesForSymbols;
    }
}