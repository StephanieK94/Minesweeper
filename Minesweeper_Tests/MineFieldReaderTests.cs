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

            List<Position> output = new List<Position>();

            MineFieldReader converter = new MineFieldReader();
        
            output = converter.BreakDownMineFieldFrom(input);        
        
            Assert.Equal(4, output[0].Row);
        }
    }
}
