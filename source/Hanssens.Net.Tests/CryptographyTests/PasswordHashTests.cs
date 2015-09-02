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

		[Test]
		public void PasswordHash_CreateHash_Should_Create_Unique_Hashes()
		{
			// arrange - by defining the same password twice
			var password1 = "12345";
			var password2 = "12345";

			// act - by creating two seperate hashes
			var hash1 = PasswordHash.CreateHash (password1);
			var hash2 = PasswordHash.CreateHash (password2);

			// assert - that both hashes have a value and that the values are not the same
			hash1.Should ().NotBeNullOrEmpty ();
			hash2.Should ().NotBeNullOrEmpty ();
			hash1.Should ().NotBe (hash2);
		}

		[Test]
		public void PasswordHash_ValidatePassword_Should_Only_Match_Same_Password_Even_With_Different_Hashes()
		{
			// arrange - by creating two hashes with the same password
			var password1 = "12345";
			var password2 = "12345";
			var password3 = "something_completely_different";
			var hash1 = PasswordHash.CreateHash (password1);
			var hash2 = PasswordHash.CreateHash (password2);
			var hash3 = PasswordHash.CreateHash (password3);

			// act + assert - that the same passwords, with different hashes, are interchangable
			hash1.Should ().NotBe (hash2);
			PasswordHash.ValidatePassword (password1, hash1).Should ().BeTrue ();
			PasswordHash.ValidatePassword (password1, hash2).Should ().BeTrue ();
			PasswordHash.ValidatePassword (password2, hash1).Should ().BeTrue();
			PasswordHash.ValidatePassword (password2, hash2).Should ().BeTrue();

			// ... but a different password is not
			PasswordHash.ValidatePassword (password3, hash1).Should ().BeFalse();
			PasswordHash.ValidatePassword (password3, hash2).Should ().BeFalse ();
			PasswordHash.ValidatePassword (password3, hash3).Should ().BeTrue ();
		}
	}
}

