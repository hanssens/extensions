using System;
using FluentAssertions;
using NUnit.Framework;
using Hanssens.Net.IO;

namespace Hanssens.Net.Tests.IO
{
	[TestFixture]
	public class JsonRequestTests
	{
		[Test]
		public void JsonRequest_Get_Should_Return_Json_String(){
			// arrange
			var endpoint = @"http://ip.jsontest.com/";

			// act
			var target = JsonRequest.Get (endpoint);

			// assert
			target.Should ().NotBeNullOrEmpty ();
		}

		[Test]
		public void JsonRequest_Post_Should_Return_Json_String(){
			// arrange
			var endpoint = @"http://ip.jsontest.com/";

			// act
			var target = JsonRequest.Post (endpoint);

			// assert
			target.Should ().NotBeNullOrEmpty ();
		}
	}
}

