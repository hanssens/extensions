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
		public void JsonRequest_JsonGet_Should_Return_Json_String(){
			// arrange
			var endpoint = @"http://ip.jsontest.com/";

			// act
			var target = JsonRequest.JsonGet (endpoint);

			// assert
			target.Should ().NotBeNullOrEmpty ();
		}
	}
}

