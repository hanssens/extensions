using System;
using FluentAssertions;
using Hanssens.Net.Reflection;
using NUnit.Framework;
using Hanssens.Net.Tests.Entities;

namespace Hanssens.Net.Tests.ReflectionTests
{
	[TestFixture]
	public class ExtractPropertyValueTests
	{
		[Test]
		public void Extract_ExtractPropertyValue_Should_Extract_Id_And_Name()
		{
			// arrange
			var expected = new Customer() {Id = 1001, Name = "Harry Potter"};

			// act
			var targetId = Extract.ExtractPropertyValue<Customer>(expected, "Id");
			var targetName = Extract.ExtractPropertyValue<Customer>(expected, "Name");


			// assert
			targetId.Should().NotBeNull();
			targetId.Should ().Be (expected.Id);
			targetName.Should().NotBeNull();
			targetName.Should().Be(expected.Name);
		}

		[Test]
		public void Extract_ExtractPropertyValue_Should_Ignore_Other_Properties()
		{
			// arrange - note that this object has additional properties, which should be ignored
			var expected = new CustomerWithAdditionalProperties() { Id = 1001, Name = "Hermoine Granger", DateOfBirth = DateTime.Now, FavoriteColor = "black" };

			// act
			var target = Extract.ExtractPropertyValue<CustomerWithAdditionalProperties>(expected, "Name");

			// assert
			target.Should().NotBeNull();
			target.Should().Be(expected.Name);
		}

		[Test]
		public void Extract_ExtractPropertyValue_Should_Ignore_CaseSensitivity()
		{
			// arrange - note that this object has lowercase 'id' and 'name'
			var expected = new CustomerWithLowerCaseProperties() { id = 1001, name = "Albus Dumbledore"};

			// act
			var target = Extract.ExtractPropertyValue<CustomerWithLowerCaseProperties>(expected, "Name");

			// assert
			target.Should().NotBeNull();
			target.Should().Be(expected.name);
		}

		[Test]
		public void Extract_ExtractPropertyValue_Should_ThrowException_If_Id_Or_Name_IsNot_Found()
		{
			// arrange - note that this object has neither and Id, nor a Name and will result in exception
			var expected = new CustomerWithoutIdAndName() { DateOfBirth = DateTime.Now, FavoriteColor = "white" };

			// act
			var target = Extract.ExtractPropertyValue<CustomerWithoutIdAndName>(expected, "Id");

			// assert
			target.Should().BeNull();
			//Assert.Fail("Expected an exception");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Extract_ExtractPropertyValue_Should_ThrowException_If_Instance_IsNull()
		{
			// arrange - note that this object has neither and Id, nor a Name and will result in exception
			Customer expected = null;

			// act - should throw exception
			Extract.ExtractPropertyValue<Customer>(expected, "Id");

			// assert
			Assert.Fail("Expected an ArgumentNullException");
		}

		[ExpectedException(typeof(ArgumentNullException))]
		public void Extract_ExtractPropertyValue_Should_ThrowException_If_PropertyName_IsNullOrEmpty()
		{
			// arrange - note that this object has neither and Id, nor a Name and will result in exception
			Customer expected = null;

			// act - should throw exception
			Extract.ExtractPropertyValue<Customer>(expected, string.Empty);

			// assert
			Assert.Fail("Expected an ArgumentNullException");
		}
	}
}

