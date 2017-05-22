using FluentAssertions;
using Hanssens.Net.Cryptography;
using Xunit;

namespace Hanssens.Net.Tests.CryptographyTests
{
    public class Base64Tests
    {
        [Fact]
        public void Base64_Decode_Should_Decrypt_Text()
        {
            // arrange
            var input = "SSBmaW5kIHlvdXIgbGFjayBvZiBmYWl0aCBkaXN0dXJiaW5nLg==";
            var expectedOutput = "I find your lack of faith disturbing.";

            // act
            var target = Base64.Decode(input);

            // assert
            target.Should().NotBeNullOrEmpty();
            target.Should().Be(expectedOutput);
        }

        [Fact]
        public void Base64_Encode_Should_Encrypt_Text()
        {
            // arrange
            var input = "It was the best of times, it was the worst of times.";
            var expectedOutput = "SXQgd2FzIHRoZSBiZXN0IG9mIHRpbWVzLCBpdCB3YXMgdGhlIHdvcnN0IG9mIHRpbWVzLg==";

            // act
            var target = Base64.Encode(input);

            // assert
            target.Should().NotBeNullOrEmpty();
            target.Should().Be(expectedOutput);
        }

        [Fact]
        public void Base64_Encode_Should_Be_Decodable()
        {
            // arrange
            var input = "It’s a trap!";

            // act
            var encoded = Base64.Encode(input);
            var target = Base64.Decode(encoded);

            // assert
            target.Should().NotBeNullOrEmpty();
            target.Should().Be(input);
        }

        [Fact]
        public void Base64_Encode_Should_Have_No_Problem_With_Unicode_Characters()
        {
            // arrange
            var unicodeCharacters = "Hí thërø, !@#$%^&*()<>?/.,`~±§";

            // act
            var encoded = Base64.Encode(unicodeCharacters);
            var target = Base64.Decode(encoded);

            // assert
            target.Should().NotBeNullOrEmpty();
            target.Should().Be(unicodeCharacters);
        }
    }
}