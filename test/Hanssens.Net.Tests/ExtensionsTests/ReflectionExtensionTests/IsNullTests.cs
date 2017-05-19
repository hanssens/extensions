using System;
using FluentAssertions;
using Hanssens.Net.Extensions;
using Xunit;

namespace Hanssens.Net.Tests.ExtensionsTests.ReflectionExtensionTests
{
    //[Category("Reflection/IsNull")]
    public class IsNullTests
    {
        [Fact]
        public void IsNullShouldValidateNullObject()
        {
            // arrange
            object obj = null;
            
            // act
            var target = Reflection.IsNull(obj);

            // assert
            target.Should().BeTrue();
        }

        [Fact]
        public void IsNullShouldValidateNullableReferenceType()
        {
            // arrange
            int? obj = null;

            // act
            var target = Reflection.IsNull(obj);

            // assert
            target.Should().BeTrue();
        }

        [Fact]
        public void IsNullShouldInvalidateNonNullableReferenceType()
        {
            // arrange
            var obj = new DateTime();

            // act
            var target = Reflection.IsNull(obj);

            // assert
            target.Should().BeFalse();
        }
    }
}
