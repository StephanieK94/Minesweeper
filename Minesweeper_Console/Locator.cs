using System;
using System.Collections.Generic;

public class Locator
{
    public List<Position> GetAllMineLocationsFrom(List<Position> pointCoordinates)
    {
        List<Position> mines = new List<Position>();

        foreach(Position point in pointCoordinates)
            {
                if(point.Symbol == "*")
                {
                    mines.Add(point);
                }
            }

        return mines;
    }

    public List<Position> GetAdjacentLocations(Position mine)
    {
        List<Position> adjacentToMine = new List<Position>();

        Position above = new Position(){ Row = mine.Row-1, Column = mine.Column };
        if(above.Row > 0 && above.Column > 0) adjacentToMine.Add(above);

        Position below = new Position(){ Row = mine.Row+1, Column = mine.Column};
        if(below.Row > 0 && below.Column > 0) adjacentToMine.Add(below);

        Position topLeft = new Position(){ Row = mine.Row-1, Column = mine.Column-1};
        if(topLeft.Row > 0 && topLeft.Column > 0) adjacentToMine.Add(topLeft);

        Position topRight = new Position(){ Row = mine.Row-1, Column = mine.Column+1};
        if(topRight.Row > 0 && topRight.Column > 0) adjacentToMine.Add(topRight);

        Position left = new Position(){ Row = mine.Row, Column =  mine.Column-1};
        if(left.Row > 0 && left.Column > 0) adjacentToMine.Add(left);

        Position right = new Position(){ Row = mine.Row, Column =  mine.Column+1};
        if(right.Row > 0 && right.Column > 0) adjacentToMine.Add(right);

        Position lowerLeft  = new Position(){ Row = mine.Row+1, Column = mine.Column-1};
        if(lowerLeft.Row > 0 && lowerLeft.Column > 0) adjacentToMine.Add(lowerLeft);

        Position lowerRight = new Position(){ Row = mine.Row+1, Column = mine.Column+1};
        if(lowerRight.Row > 0 && lowerRight.Column > 0) adjacentToMine.Add(lowerRight);

        return adjacentToMine;
    }
}
