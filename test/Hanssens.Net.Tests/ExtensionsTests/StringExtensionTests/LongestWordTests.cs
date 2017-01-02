using System;
using FluentAssertions;
using Hanssens.Net.Extensions;
using NUnit.Framework;

namespace Hanssens.Net.Tests.StringExtensionTests
{
    [TestFixture]
    public class LongestWordTests
    {

        [Test]
        public void LongestWord_Should_Return_Longest_Word_In_Sentence()
        {
            var sentence = "The longest word in this sentence is ASDLKFJSLFJSDKFJ by far";

            var target = sentence.LongestWord();
            target.Should().BeEquivalentTo("ASDLKFJSLFJSDKFJ");
        }

        [Test]
        public void LongestWord_Should_Ignore_Punctuations_As_Words()
        {
            var sentence = "The longest word is YOURBROTHERISYOURMOTHER, but, you - as the user - should realize the function (should) ignore punctuations.";

            var target = sentence.LongestWord();
            target.Should().BeEquivalentTo("YOURBROTHERISYOURMOTHER");
        }

        [Test]
        public void LongestWord_Should_Return_Value_If_Input_Is_Only_One_Word()
        {
            var sentence = "oneword";

            var target = sentence.LongestWord();
            target.Should().BeEquivalentTo(sentence);
        }

        [Test]
        public void LongestWord_Should_Return_Null_With_Empty_Input()
        {
            string sentence = "";

            var target = sentence.LongestWord();
            target.Should().BeNull("Should return null with empty or null input.");
        }

        [Test]
        public void LongestWord_Should_Return_Null_With_Null_Input()
        {
            string sentence = null;

            var target = sentence.LongestWord();
            target.Should().BeNull("Should return null with empty or null input.");
        }

    }
}
