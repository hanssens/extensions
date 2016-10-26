using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net.Calculations;
using NUnit.Framework;
using FluentAssertions;

namespace Hanssens.Net.Tests.CalculationsTests
{
    [TestFixture(Category = "Calculations")]
    public class UnitConverterTests
    {
        [Test]
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

        [Test]
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
