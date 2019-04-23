using System.Collections.Generic;
using Xunit;

namespace Minesweeper_Tests
{
    public class MineFieldReaderTests
    {
        [Fact]
        public void GivenInputReadAllLines()
        {
            List<string> input = new List<string>(){
                "4 4",
                "*...",
                "....",
                ".*..",
                "...."
            };

            Position expectedHeader = new Position()
            {
                Row=4, 
                Column=4, 
                Symbol= "4 4"
            };         

            List<Position> output = new List<Position>();

            MineFieldReader converter = new MineFieldReader();
        
            output = converter.BreakDownMineFieldFrom(input);        
        
            Assert.Equal(expectedHeader.Row, output[0].Row);
            Assert.Equal(expectedHeader.Column, output[0].Column);
            Assert.Equal(expectedHeader.Symbol, output[0].Symbol);
        }
    }
}
