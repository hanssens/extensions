using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Hanssens.Net.Cryptography;
using NUnit.Framework;

namespace Hanssens.Net.Tests.CryptographyTests
{
    [TestFixture]
    public class EncodeTests
    {
        [Test]
        public void Encode_Base64_Simple_String()
        {
            // arrange
            var input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed molestie lacus condimentum, viverra metus cursus, varius elit. Vestibulum pellentesque nibh non justo aliquam dignissim. Mauris auctor ipsum quam, ut cursus ipsum pharetra quis. Donec non nisi dapibus, sollicitudin libero at, pretium massa.";

            // act
            var target = Encode.Base64Encode(input);

            // assert
            target.Should().NotBeNullOrEmpty();
            target.Should().NotBe(input);
        }

        [Test]
        public void Decode_Base64_Simple_String()
        {
            // arrange - encode an original string
            var original = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed molestie lacus condimentum, viverra metus cursus, varius elit. Vestibulum pellentesque nibh non justo aliquam dignissim. Mauris auctor ipsum quam, ut cursus ipsum pharetra quis. Donec non nisi dapibus, sollicitudin libero at, pretium massa.";
            var encoded = Encode.Base64Encode(original);

            // act - decode it
            var decoded = Encode.Base64Decode(encoded);

            // assert
            decoded.Should().NotBeNullOrEmpty();
            decoded.Should().NotBe(encoded);
            decoded.Should().Be(original);
        }

        [Test]
        public void Encode_Base64_Should_Throw_Exception_With_NullOrEmpty_Parameter()
        {
            var nullparameter = "";
            Assert.Throws<ArgumentNullException>(() => { Encode.Base64Encode(nullparameter); });
        }

        [Test]
        public void Decode_Base64_Should_Throw_Exception_With_NullOrEmpty_Parameter()
        {
            var nullparameter = "";
            Assert.Throws<ArgumentNullException>(() => { Encode.Base64Decode(nullparameter); });
        }
    }
}
