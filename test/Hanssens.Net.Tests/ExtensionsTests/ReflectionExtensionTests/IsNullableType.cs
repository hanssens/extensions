using System;
using System.ComponentModel;
using FluentAssertions;
using Hanssens.Net.Extensions;
using Xunit;

namespace Hanssens.Net.Tests.ExtensionsTests.ReflectionExtensionTests
{
    //[TestFixture, Category("Reflection/IsNullableType")]
    public class IsNullableTypeTests
    {
        [Fact]
        public void IsNullableTypeShouldValidateNullType()
        {
            // arrange
            object obj = null;

            // act
            var target = Reflection.IsNullableType(obj);

            // assert
            target.Should().BeTrue();
        }

        [Fact]
        public void IsNullableTypeShouldValidateNullableReferenceType()
        {
            // arrange
            int? obj = null;

            // act
            var target = Reflection.IsNullableType(obj);

            // assert
            target.Should().BeTrue();
        }

        [Fact]
        public void IsNullableTypeShouldInvalidateNonNullableReferenceType()
        {
            // arrange
            var obj = new DateTime();

            // act
            var target = Reflection.IsNullableType(obj);

            // assert
            target.Should().BeFalse();
        }
    }
}
