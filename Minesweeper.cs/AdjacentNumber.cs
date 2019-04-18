using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class AdjacentNumber
    {
        public int GetNumberOfAdjacentMines(Position current, List<Position> mineLocations)
        {
            var numberAdjacentBombs =0;

            foreach(var mine in mineLocations)
            {
                List<Position> safeLocations = new List<Position>();
                
                AdjacentLocation location = new AdjacentLocation();

                safeLocations =  location.GetAdjacentLocations(mine);
                
                foreach(Position safeLocation in safeLocations)
                {
                    if(current.Row == safeLocation.Row && current.Column == safeLocation.Column)
                    {
                        numberAdjacentBombs++;
                    }
                }                
            }
            return numberAdjacentBombs;
        }
    }
}