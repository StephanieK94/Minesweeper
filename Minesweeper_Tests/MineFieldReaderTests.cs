using System;
using System.Collections.Generic;
using Minesweeper_kata;
using Xunit;

namespace Minesweeper_Tests
{
    public class MineFieldReaderTests
    {
        [Fact]
        public void GivenInputReadAllLines()
        {
            List<string> input = new List<string>
            (
                input[0] = "4 4",
                input[1] = "*...",
                input[2] = "....",
                input[3] = ".*..",
                input[4] = "...."
            );
            

            List<Position> output = new List<Position>();

            MineFieldReader converter = new MineFieldReader();
        
            output = converter.BreakDownMineFieldFrom(input);        
        
            Assert.Equals(4, output[0].row);
        }
    }
}
