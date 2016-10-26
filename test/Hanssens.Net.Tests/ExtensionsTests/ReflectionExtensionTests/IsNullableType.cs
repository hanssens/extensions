using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Hanssens.Net.Extensions;
using NUnit.Framework;

namespace Hanssens.Net.Tests.ExtensionsTests.ReflectionExtensionTests
{
    [TestFixture, Category("Reflection/IsNullableType")]
    public class IsNullableTypeTests
    {
        [Test]
        public void IsNullableTypeShouldValidateNullType()
        {
            // arrange
            object obj = null;

            // act
            var target = Reflection.IsNullableType(obj);

            // assert
            target.Should().BeTrue();
        }

        [Test]
        public void IsNullableTypeShouldValidateNullableReferenceType()
        {
            // arrange
            int? obj = null;

            // act
            var target = Reflection.IsNullableType(obj);

            // assert
            target.Should().BeTrue();
        }

        [Test]
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
