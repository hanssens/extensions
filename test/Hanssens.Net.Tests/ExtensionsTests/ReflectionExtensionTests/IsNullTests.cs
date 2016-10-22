using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Hanssens.Net.Extensions;
using NUnit.Framework;

namespace Hanssens.Net.Tests.ExtensionsTests.ReflectionExtensionTests
{
    [TestFixture, Category("Reflection/IsNull")]
    public class IsNullTests
    {
        [Test]
        public void IsNullShouldValidateNullObject()
        {
            // arrange
            object obj = null;
            
            // act
            var target = Reflection.IsNull(obj);

            // assert
            target.Should().BeTrue();
        }

        [Test]
        public void IsNullShouldValidateNullableReferenceType()
        {
            // arrange
            int? obj = null;

            // act
            var target = Reflection.IsNull(obj);

            // assert
            target.Should().BeTrue();
        }

        [Test]
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
