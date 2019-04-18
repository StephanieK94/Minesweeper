using System.Collections.Generic;

public class MineFieldReader
{
    public List<Position> BreakDownMineFieldFrom(List<string> fieldLines)
    {
        List<Position> mineCoordinates = new List<Position>();
        // first line will be split into strings of row and column to be passed into the length of the for loops,

        // for(int i = 1; i <= row; i++)
        // {
                // for(int j = 1; j <= column; j++)
                // {
                        // needs to then split every line string into the strings to get passed into the Column = the first split position???
                        
                        // while the Row = row
                        // these new Positions should be added to a List of Positions, or a list of strings which are a list of positions?
                // }
                
        // }

        return mineCoordinates;
        
    }
}