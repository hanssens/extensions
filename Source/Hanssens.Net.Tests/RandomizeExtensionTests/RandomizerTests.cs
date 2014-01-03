using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hanssens.Net.Tests
{
    [TestClass]
    public class RandomizeExtensionTests
    {

        [TestMethod]
        public void ConstructorTest()
        {
            var target = new Randomizer();
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(target, typeof(Randomizer));
        }

        [TestMethod]
        public void DisposableConstructorTest()
        {
            using (var target = new Randomizer())
            {
                Assert.IsNotNull(target);
                Assert.IsInstanceOfType(target, typeof(Randomizer));
            }
        }

        [TestMethod]
        public void TwoRandomEntriesFromACollection()
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
        public void MultipleRandomizersShouldGiveDifferentResults()
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

            // Assert that in the list of 100 values, two randomly choses will not be the same
            // Statitically, this is a rubbish test; there is always a slight probability the
            // two values are the same
            Assert.AreNotEqual(firstValue, secondValue);
        }
    }
}
