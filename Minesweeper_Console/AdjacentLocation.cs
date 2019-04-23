using System.Collections.Generic;
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