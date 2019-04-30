using System.Collections.Generic;

public class AdjacentCalculator
    {
        public string GetNumberOfAdjacentMines(Position current, List<Position> mineLocations)
        {
            var numberAdjacentBombs =0;

            foreach(var mine in mineLocations)
            {
                List<Position> safeLocations = new List<Position>();
                
                Locator location = new Locator();

                safeLocations =  location.GetAdjacentLocations(mine);
                
                foreach(Position safeLocation in safeLocations)
                {
                    if(current.Row == safeLocation.Row && current.Column == safeLocation.Column)
                    {
                        numberAdjacentBombs++;
                    }
                }                
            }
            return numberAdjacentBombs.ToString();
        }
    }