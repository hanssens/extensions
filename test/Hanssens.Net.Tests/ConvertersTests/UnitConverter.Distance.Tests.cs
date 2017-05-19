using Hanssens.Net.Converters;
using FluentAssertions;
using Xunit;

namespace Hanssens.Net.Tests.ConvertersTests
{
    //[TestFixture(Category = "Converters/UnitConverts-Distance")]
    public partial class UnitConverterTests
    {
        [Fact]
        public void KilometersToMiles_Should_Provide_Exact_Result()
        {
            // arrange
            var amountOfKm = 5;
            var expected = 3.10685596;

            // act
            var target = UnitConverter.MilesToKilometers(amountOfKm);

            // assert
            target.Should().Be(expected);
        }

        [Fact]
        public void MilesToKilometers_Should_Provide_Exact_Result()
        {
            // arrange
            var amountOfMiles = 5;
            var expected = 8.04672;

            // act
            var target = UnitConverter.KilometersToMiles(amountOfMiles);

            // assert
            target.Should().Be(expected);
        }

    }
}
