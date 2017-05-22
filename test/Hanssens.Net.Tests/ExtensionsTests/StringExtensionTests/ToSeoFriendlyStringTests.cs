using System;
using FluentAssertions;
using Hanssens.Net.Extensions;
using Xunit;

namespace Hanssens.Net.Tests.StringExtensionTests
{
    public class ToSeoFriendlyStringTests
    {

        [Fact]
		public void ToSeoFriendlyString_Should_Strip_All_NonAlphaNumeric_Characters()
        {
			// arrange
            var sentence = "This: is something that should be +^~!@#$ _ clean";

			// act
			var target = sentence.ToSeoFriendlyString ();

			// assert
			target.Should ().NotBeNullOrEmpty ();
            target.Should().BeEquivalentTo("this-is-something-that-should-be-clean");

			foreach (var c in target.ToCharArray()) {
				// allow 'dashes'
				if (Char.Equals(c, '-'))
					continue;

				// iterate through the characters to prove that it's a letter, digit or seperator
				if (!Char.IsLetterOrDigit (c))
				    Assert.True(false, String.Format ("Non-compliant character '{0}' found in pharse '{1}'", c.ToString (), target));
			}
        }

		[Fact]
		public void ToSeoFriendlyString_Should_Only_Return_Lowercase_Characters()
		{
			// arrange
			var sentence = "This SHOULD All Be In Lowercase";

			// act
			var target = sentence.ToSeoFriendlyString ();

			// assert
			target.Should ().NotBeNullOrEmpty ();
			target.Should().BeEquivalentTo("this-should-all-be-in-lowercase");

			foreach (var c in target.ToCharArray()) {
				// skip any character that isn't a letter or digit
				if (!Char.IsLetterOrDigit (c)) 
					continue;

				// iterate through the characters to prove that it only contains lowercase characters
				if (!Char.IsLower(c))
				    Assert.True(false, String.Format ("Non-lowercase character '{0}' found in pharse '{1}'", c.ToString (), target));
			}
		}

		[Fact]
		public void ToSeoFriendlyString_Should_Strip_DotsAndHyphens_From_Beginning()
		{
			// arrange
			var sentence = "--.This is a sentence. with dots. and -hyphens--";

			// act
			var target = sentence.ToSeoFriendlyString ();

			// assert
			target.Should ().NotBeNullOrEmpty ();
			target.Should().BeEquivalentTo("this-is-a-sentence-with-dots-and-hyphens");
		}

		[Fact]
		public void ToSeoFriendlyString_Should_Allow_Starting_With_Numbers()
		{
			// arrange
			var sentence = "-2014-start-with-number-should-be-retained-";

			// act
			var target = sentence.ToSeoFriendlyString ();

			// assert
			target.Should ().NotBeNullOrEmpty ();
			target.Should().BeEquivalentTo("2014-start-with-number-should-be-retained");
		}
    }
}
