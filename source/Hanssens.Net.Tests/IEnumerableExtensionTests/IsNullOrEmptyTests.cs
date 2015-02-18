using System;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using Hanssens.Net.Extensions;

namespace Hanssens.Net.Tests
{
	[TestFixture]
	public class IsNullOrEmptyTests
	{
		[Test]
		public void IEnumerable_IsNullOrEmpty_Should_Return_False_If_Collection_Has_A_Single_Element()
		{
			// arrange - create array with a single item
			var collection = new int[] { 1 };

			// act
			var target = collection.IsNullOrEmpty();

			// assert
			target.Should ().BeFalse();
		}

		[Test]
		public void IEnumerable_IsNullOrEmpty_Should_Return_False_If_Collection_Has_Multiple_Elements()
		{
			// arrange - create strong typed collection, with multiple items
			var collection = new List<string> (){ "a", "b", "c" };

			// act
			var target = collection.IsNullOrEmpty();

			// assert
			target.Should ().BeFalse();
		}

		[Test]
		public void IEnumerable_IsNullOrEmpty_Should_Return_True_If_Collection_IsNull()
		{
			// arrange - create null collection
			List<string> collection = null;

			// act
			var target = collection.IsNullOrEmpty();

			// assert
			target.Should ().BeTrue ();
		}

		[Test]
		public void IEnumerable_IsNullOrEmpty_Should_Return_True_If_Collection_IsEmpty()
		{
			// arrange - create empty collection
			var collection = new List<string>();

			// act
			var target = collection.IsNullOrEmpty();

			// assert
			target.Should ().BeTrue ();
		}
	}
}

