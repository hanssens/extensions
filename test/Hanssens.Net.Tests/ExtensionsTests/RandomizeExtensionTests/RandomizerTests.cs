using System;
using FluentAssertions;
using Hanssens.Net.Extensions;
using System.Collections.Generic;
using Xunit;

namespace Hanssens.Net.Tests
{
    public class RandomizeExtensionTests
    {

        [Fact]
        public void Randomizer_Should_Initialize()
        {
            var target = new Randomizer();
			target.Should ().NotBeNull ();
			target.Should ().BeOfType<Randomizer> ();
        }

        [Fact]
        public void Randomizer_Should_Initialize_And_Dispose()
        {
            using (var target = new Randomizer())
            {
				target.Should ().NotBeNull ();
				target.Should ().BeOfType<Randomizer> ();
            }
        }

        [Fact]
        public void Randomizer_Should_Return_Random_Entries_From_A_Collection()
        {
            var values = new List<string>();
            for (int i = 0; i < 99; i++)
                values.Add("UserNo" + i);

            using (var randomizer = new Randomizer())
            {
                var firstValue = randomizer.Random(values);
                var secondValue = randomizer.Random(values);

                // Assert that in the list of 100 values, two randomly choses will not be the same
                // Statitically, this is a rubbish test; there is always a slight probability the
                // two values are the same
                firstValue.Should().NotBeSameAs(secondValue);
            }
        }

        [Fact]
        public void Randomizer_Should_Give_Different_Results_Each_Time_Initialized()
        {
			// Arrange
            var values = new List<string>();
            for (int i = 0; i < 99; i++)
                values.Add("UserNo" + i);

            string firstValue = string.Empty, secondValue = string.Empty;

			// Act - initialize two Randomizer instances and fetch a random value
            using (var randomizer = new Randomizer()) {
                firstValue = randomizer.Random(values);
            }

            using (var randomizer = new Randomizer()) {
                secondValue = randomizer.Random(values);
            }

            // Assert - that in the list of lots of values, two randomly choses will not be the same
            // Statitically, this is a rubbish test; there is always a slight probability the
            // two values are the same
            firstValue.Should().NotBe(secondValue, "multiple randomizers should give different results");
        }
    }
}
