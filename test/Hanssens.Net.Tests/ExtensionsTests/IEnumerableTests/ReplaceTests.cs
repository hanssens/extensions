using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Hanssens.Net.Extensions;

namespace Hanssens.Net.Tests
{
    [TestFixture, Category("IEnumerableExtensions/Replace")]
    public class ReplaceTests
    {
        [Test]
        public void Replace_Should_Throw_Exception_If_IList_IsNull()
        {
            // arrange
            List<string> collection = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Throws<ArgumentNullException>(() => collection.Replace("foo", "bar"));
        }

        [Test]
        public void Replace_Should_Throw_Exception_If_IEnumerable_IsNull()
        {
            // arrange
            IEnumerable<string> collection = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.Throws<ArgumentNullException>(() => collection.Replace("foo", "bar"));
        }

        [Test]
        public void Replace_Should_Replace_Single_Value_In_IList()
        {
            // arrange
            var collection = new List<string>()
            {
                "foo",
                "bar",
                "haz"
            };

            var originalCollectionCount = collection.Count;

            // act
            collection.Replace("foo", "w00t");

            // assert
            collection.Should().NotContain("foo");
            collection.Should().Contain("haz");
            collection.Count.Should().Be(originalCollectionCount, because: "length of the collection should remain the same");
        }

        [Test]
        public void Replace_Should_Replace_Multiple_Values_In_IList()
        {
            // arrange
            var collection = new List<string>()
            {
                "foo",
                "foo",
                "bar",
                "haz",
                "foo"
            };

            var originalCollectionCount = collection.Count;
            var originalWordCount = collection.Count(c => c == "foo");

            // act
            collection.Replace("foo", "w00t");

            // assert
            collection.Should().NotContain("foo");
            collection.Should().Contain("haz");
            collection.Count.Should().Be(originalCollectionCount, because: "length of the collection should remain the same");
            collection.Count(c => c == "w00t").Should().Be(originalWordCount, because: "same amount of items should be replaced");
        }

        [Test]
        public void Replace_Should_Replace_Nothing_When_No_Matches_Are_Found()
        {
            // arrange
            var collection = new List<string>()
            {
                "a",
                "b",
                "c",
                "d",
                "e"
            };

            var originalCollectionCount = collection.Count;
            var nonExistingValue = "foo";
            var notExpectedValue = "this-should-not-occur";

            // act
            collection.Replace(nonExistingValue, notExpectedValue);

            // assert
            collection.Should().NotContain(notExpectedValue);
            collection.Should().BeSameAs(collection, because: "collection should be unmodified");
        }
    }
}
