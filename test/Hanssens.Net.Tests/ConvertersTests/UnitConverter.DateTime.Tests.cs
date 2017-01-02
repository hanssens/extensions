using System;
using Hanssens.Net.Converters;
using NUnit.Framework;
using FluentAssertions;

namespace Hanssens.Net.Tests.ConvertersTests
{
    [TestFixture(Category = "Converters/UnitConverts-DateTime")]
    public partial class UnitConverterTests
    {
        [Test]
        public void ConvertFromUnixEpoch_Should_Have_Proper_StartDate()
        {
            // arrange
            var expected = new DateTime(1970, 1, 1, 0, 0, 0);
            var epoch = 0;

            // act
            var target = UnitConverter.ConvertFromUnixEpoch(epoch);

            // assert
            target.Should().Be(expected);
        }

        [Test]
        public void ConvertFromUnixEpoch_Should_Convert_Date_To_Epoch()
        {
            // arrange
            var expected = new DateTime(1981, 6, 15 , 20, 30, 00); // #easteregg: my birthday
            var epoch = 361485000;

            // act
            var target = UnitConverter.ConvertFromUnixEpoch(epoch);

            // assert
            target.Should().Be(expected);
        }

        [Test]
        public void ConvertFromUnixEpoch_Should_Convert_Historical_Date_To_Epoch()
        {
            // arrange
            var expected = new DateTime(1950, 1, 1 , 10, 30, 00);
            var epoch = -631114200;

            // act
            var target = UnitConverter.ConvertFromUnixEpoch(epoch);

            // assert
            target.Should().Be(expected);
        }

        [Test]
        public void DateTime_ToEpoch_Should_Have_Proper_StartDate()
        {
            // arrange
            var date = new DateTime(1970, 1, 1, 0, 0, 0);
            var expectedEpoch = 0;

            // act
            var target = date.ToEpoch();

            // assert
            target.Should().Be(expectedEpoch);
        }

        [Test]
        public void DateTime_ToEpoch_Should_Convert_Epoch_To_Date()
        {
            // arrange
            var date = new DateTime(1981, 6, 15 , 20, 30, 00);
            var expectedEpoch = 361485000;

            // act
            var target = date.ToEpoch();

            // assert
            target.Should().Be(expectedEpoch);
        }

        [Test]
        public void DateTime_ToEpoch_Should_Convert_Historical_Epoch_To_Date()
        {
            // arrange
            var pre_epoch_date = new DateTime(1950, 1, 1 , 10, 30, 00);
            var expectedEpoch = -631114200;

            // act
            var target = pre_epoch_date.ToEpoch();

            // assert
            target.Should().Be(expectedEpoch);
        }
    }
}
