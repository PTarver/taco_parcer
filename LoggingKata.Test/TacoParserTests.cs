using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("34.280205,-86.217115,Taco Bell Albertvill... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("34,-86,Taco Bell")]
        public void ShouldParse(string str)
        {
            // arrange
            TacoParser taco = new TacoParser();
            // act
            ITrackable chalupa = taco.Parse(str);
            // assert
            Assert.NotNull(chalupa);

            // TODO: Complete Should Parse
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("100")]
        [InlineData("burger king")]
        [InlineData("89,87,86, dairy queen")]
        [InlineData("97,sonic")]
        [InlineData("a,b,c")]
        public void ShouldFailParse(string str)
        {
            // arrange
            TacoParser taco = new TacoParser();
            // act
            ITrackable chalupa = taco.Parse(str);
            // assert
            Assert.Null(chalupa);
            // TODO: Complete Should Fail Parse
        }
    }
}
