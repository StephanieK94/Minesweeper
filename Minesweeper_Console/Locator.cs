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

        // Make this a loop 1-8 which doesn't add that position if the row or column is 0?
        
        Position above = new Position(){ Row = mine.Row-1, Column = mine.Column };
        adjacentToMine.Add(above);

        Position topLeft = new Position(){ Row = mine.Row-1, Column = mine.Column-1};
        adjacentToMine.Add(topLeft);

        Position topRight = new Position(){ Row = mine.Row-1, Column = mine.Column+1};
        adjacentToMine.Add(topRight);

        Position left = new Position(){ Row = mine.Row, Column =  mine.Column-1};
        adjacentToMine.Add(left);

        Position right = new Position(){ Row = mine.Row, Column =  mine.Column+1};
        adjacentToMine.Add(right);

        Position below = new Position(){ Row = mine.Row+1, Column = mine.Column};
        adjacentToMine.Add(below);

        Position lowerLeft  = new Position(){ Row = mine.Row+1, Column = mine.Column-1};
        adjacentToMine.Add(lowerLeft);

        Position lowerRight = new Position(){ Row = mine.Row+1, Column = mine.Column+1};
        adjacentToMine.Add(lowerRight);

        // need to add a null check to ignore the Positions or add into the Adjacent Locations so not even added

        return adjacentToMine;
    }
}
