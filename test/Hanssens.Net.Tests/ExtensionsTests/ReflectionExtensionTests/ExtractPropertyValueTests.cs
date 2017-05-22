using System;
using System.ComponentModel;
using Hanssens.Net.Extensions;
using Hanssens.Net.Tests.InTests;
using FluentAssertions;
using Hanssens.Net.Tests.Stubs;
using Xunit;

namespace Hanssens.Net.Tests.ExtensionsTests.ReflectionExtensionTests
{
    public class ExtractPropertyValueTests
    {
        [Fact]
        public void ExtractPropertyValue_Should_Id_And_Name()
        {
            // arrange
            var expected = new Customer() { Id = 1001, Name = "Harry Potter" };

            // act
            var targetId = Reflection.ExtractPropertyValue(expected, "Id");
            var targetName = Reflection.ExtractPropertyValue(expected, "Name");


            // assert
            targetId.Should().NotBeNull();
            targetId.Should().Be(expected.Id);
            targetName.Should().NotBeNull();
            targetName.Should().Be(expected.Name);
        }

        [Fact]
        public void ExtractPropertyValue_Should_Ignore_Other_Properties()
        {
            // arrange - note that this object has additional properties, which should be ignored
            var expected = new CustomerWithAdditionalProperties() { Id = 1001, Name = "Hermoine Granger", DateOfBirth = DateTime.Now, FavoriteColor = "black" };

            // act
            var target = Reflection.ExtractPropertyValue(expected, "Name");

            // assert
            target.Should().NotBeNull();
            target.Should().Be(expected.Name);
        }

        [Fact]
        public void ExtractPropertyValue_Should_Ignore_CaseSensitivity()
        {
            // arrange - note that this object has lowercase 'id' and 'name'
            var expected = new CustomerWithLowerCaseProperties() { id = 1001, name = "Albus Dumbledore" };

            // act
            var target = Reflection.ExtractPropertyValue(expected, "Name");

            // assert
            target.Should().NotBeNull();
            target.Should().Be(expected.name);
        }

        [Fact]
        public void ExtractPropertyValue_Should_ThrowException_If_Id_Or_Name_IsNot_Found()
        {
            // arrange - note that this object has neither and Id, nor a Name and will result in exception
            var expected = new CustomerWithoutIdAndName() { DateOfBirth = DateTime.Now, FavoriteColor = "white" };

            // act
            var target = Reflection.ExtractPropertyValue(expected, "Id");

            // assert
            target.Should().BeNull();
            //Assert.Fail("Expected an exception");
        }

        [Fact]
        public void ExtractPropertyValue_Should_ThrowException_If_Instance_IsNull()
        {
            // arrange - note that this object has neither and Id, nor a Name and will result in exception
            LinqExtensionTests.Customer expected = null;

            // act - should throw exception
            Assert.Throws<ArgumentNullException>(() => Reflection.ExtractPropertyValue(expected, "Id"));
        }

        public void ExtractPropertyValue_Should_ThrowException_If_PropertyName_IsNullOrEmpty()
        {
            // arrange - note that this object has neither and Id, nor a Name and will result in exception
            LinqExtensionTests.Customer expected = null;

            // act - should throw exception
            Assert.Throws<ArgumentException>(() => Reflection.ExtractPropertyValue(expected, string.Empty));
        }
    }
}
