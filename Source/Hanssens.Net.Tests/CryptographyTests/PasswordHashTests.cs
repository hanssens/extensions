using FluentAssertions;
using Hanssens.Net.Cryptography;
using NUnit.Framework;
using System;

namespace Hanssens.Net.Tests
{
	[TestFixture]
	public class PasswordHashTests
	{
		[Test]
		public void PasswordHash_CreateHash_Target_Should_Differ_From_Source()
		{
			// arrange
			var password = "iamroot";

			// act
			var target = PasswordHash.CreateHash (password);

			// assert
			target.Should ().NotBeNullOrEmpty ();
			target.Should ().NotBe (password);
		}

		[Test]
		public void PasswordHash_CreateHash_Should_Provide_Validatable_Combination()
		{
			// arrange
			var password = "abc123";
			var hash = PasswordHash.CreateHash (password);

			// act
			var target = PasswordHash.ValidatePassword (password, hash);

			// assert
			target.Should ().BeTrue ();
		}
	}
}

