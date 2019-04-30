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
                "44",
                "*...",
                "....",
                ".*..",
                "...."
            };

            Position expectedHeader = new Position()
            {
                Row=4, 
                Column=4, 
                Symbol= "Field `#1`"
            };        

            Position expectedLineOneColumnOne = new Position()
            {
                Row=1, 
                Column=1, 
                Symbol= "*"
            };         

            MineFieldReader gameboardReader = new MineFieldReader();

            Position dimensions = new Position();
            dimensions = gameboardReader.GetFieldDimensions(1, input[0]);

            List<Position> output = new List<Position>();
            output = gameboardReader.GetFieldCoordinatesForPositions(dimensions, input);        
        
            Assert.Equal(expectedHeader.Row, dimensions.Row);
            Assert.Equal(expectedHeader.Column, dimensions.Column);
            Assert.Equal(expectedHeader.Symbol, dimensions.Symbol);

            Assert.Equal(expectedLineOneColumnOne.Row, output[1].Row);
            Assert.Equal(expectedLineOneColumnOne.Column, output[1].Column);
            Assert.Equal(expectedLineOneColumnOne.Symbol, output[1].Symbol);
        }
    }
}
