using System;
using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Hanssens.Net.IO;

namespace Hanssens.Net.Tests.IO
{
	[TestFixture]
	public class JsonRequestTests
	{

		// TODO: The tests below shouldn't call an external service, obviously, but should
		// be refactored to rely on a more appropriate 'embedded' api.

		[Test]
		public void JsonRequest_Delete_Should_Return_Json_String(){
			// arrange
			var endpoint = @"http://jsonplaceholder.typicode.com/posts/1";

			// act
			var target = JsonRequest.Delete (endpoint);

			// assert
			target.Should ().NotBeNull ();
			target.StatusCode.Should ().Be (HttpStatusCode.OK);
			target.Success.Should ().BeTrue (because: target.ErrorMessage);
			target.ErrorMessage.Should ().BeNull ();
		}

		[Test]
		public void JsonRequest_Get_Should_Return_Json_String(){
			// arrange
			var endpoint = @"http://jsonplaceholder.typicode.com/posts";

			// act
			var target = JsonRequest.Get (endpoint);

			// assert
			target.Should ().NotBeNull ();
			target.StatusCode.Should ().Be (HttpStatusCode.OK);
			target.Success.Should ().BeTrue (because: target.ErrorMessage);
			target.Value.Should ().NotBeNullOrEmpty ();
			target.ErrorMessage.Should ().BeNull ();
		}

		[Test]
		public void JsonRequest_Post_Should_Return_Json_String(){
			// arrange
			var endpoint = @"http://jsonplaceholder.typicode.com/posts";
			var body = new { foo = "Foo", bar = "Bar" };

			// act
			var target = JsonRequest.Post (endpoint, args: body);

			// assert
			target.Should ().NotBeNull ();
			target.StatusCode.Should ().Be (HttpStatusCode.Created);
			target.Success.Should ().BeTrue (because: target.ErrorMessage);
			target.Value.Should ().NotBeNullOrEmpty ();
			target.ErrorMessage.Should ().BeNull ();
		}

		[Test]
		public void JsonRequest_Put_Should_Return_Json_String(){
			// arrange
			var endpoint = @"http://jsonplaceholder.typicode.com/posts/1";
			var body = new { foo = "Foo", bar = "Bar" };

			// act
			var target = JsonRequest.Put (endpoint, args: body);

			// assert
			target.Should ().NotBeNull ();
			target.StatusCode.Should ().Be (HttpStatusCode.OK);
			target.Success.Should ().BeTrue (because: target.ErrorMessage);
			target.Value.Should ().NotBeNullOrEmpty ();
			target.ErrorMessage.Should ().BeNull ();
		}
			
	}
}

