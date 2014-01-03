using System;
using FluentAssertions;
using Hanssens.Net.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hanssens.Net.Tests
{
    [TestClass]
    public class RandomizeExtensionTests
    {

        [TestMethod]
        public void Randomizer_Should_Initialize()
        {
            var target = new Randomizer();
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(target, typeof(Randomizer));
        }

        [TestMethod]
        public void Randomizer_Should_Initialize_And_Dispose()
        {
            using (var target = new Randomizer())
            {
                Assert.IsNotNull(target);
                Assert.IsInstanceOfType(target, typeof(Randomizer));
            }
        }

        [TestMethod]
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
                Assert.AreNotEqual(firstValue, secondValue);
            }
        }

        [TestMethod]
        public void Randomizer_Should_Give_Different_Results_Each_Time_Initialized()
        {
            var values = new List<string>();
            for (int i = 0; i < 99; i++)
                values.Add("UserNo" + i);

            string firstValue = string.Empty, secondValue = string.Empty;

            using (var randomizer = new Randomizer()) {
                firstValue = randomizer.Random(values);
            }

            using (var randomizer = new Randomizer()) {
                secondValue = randomizer.Random(values);
            }

            // Assert that in the list of lots of values, two randomly choses will not be the same
            // Statitically, this is a rubbish test; there is always a slight probability the
            // two values are the same
            firstValue.Should().NotBe(secondValue, "multiple randomizers should give different results");
        }
    }
}
