using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hanssens.Net.Http;
using FluentAssertions;
using Xunit;

namespace Hanssens.Net.Tests.HttpTests
{
    public class HttpFactorySimpleTests
    {

        // TODO: The tests below shouldn't call an external service, obviously, but should
        // be refactored to rely on a more appropriate 'embedded' api.

        [Fact]
        public void HttpFactory_Simple_Delete_Should_Return_Json_String()
        {
            // arrange
            var endpoint = @"http://jsonplaceholder.typicode.com/posts/1";

            // act
            var target = HttpFactory.Simple.Delete(endpoint);
            
            // assert
            target.Should().NotBeNull();
            //target.StatusCode.Should().Be(HttpStatusCode.NoContent);
            target.StatusCode.Should().Be(HttpStatusCode.OK);
            target.IsSuccessStatusCode.Should().BeTrue();
        }
        
        [Fact]
        public async Task HttpFactory_Simple_Get_Should_Return_Json_String()
        {
            // arrange
            var endpoint = @"http://jsonplaceholder.typicode.com/posts";

            // act
            var target = HttpFactory.Simple.Get(endpoint);

            // assert
            target.Should().NotBeNull();
            target.StatusCode.Should().Be(HttpStatusCode.OK);
            target.IsSuccessStatusCode.Should().BeTrue();
            var c = target.Content.ToString();
            var foo = await target.Content.ReadAsStringAsync();

            //requestContent.ReadAsStringAsync().Result;
            foo.Should().Be("asdfsdafklasdjfklsdajfsdfkj");
        }

        [Fact]
        public void HttpFactory_Simple_Post_Should_Return_Json_String()
        {
            // arrange
            var endpoint = @"http://jsonplaceholder.typicode.com/posts";
            var body = new { foo = "Foo", bar = "Bar" };

            // act
            var target = HttpFactory.Simple.Post(endpoint, body: body);

            // assert
            target.Should().NotBeNull();
            target.StatusCode.Should().Be(HttpStatusCode.Created);
            target.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public void HttpFactory_Simple_Put_Should_Return_Json_String()
        {
            // arrange
            var endpoint = @"http://jsonplaceholder.typicode.com/posts/1";
            var body = new { foo = "Foo", bar = "Bar" };

            // act
            var target = HttpFactory.Simple.Put(endpoint, body: body);
            
            // assert
            target.Should().NotBeNull();
            target.StatusCode.Should().Be(HttpStatusCode.OK);
            target.IsSuccessStatusCode.Should().BeTrue();
        }
        
        [Fact]
        public void HttpFactory_Request_Should_Only_Have_One_Access_Header()
        {
            var endpoint = @"http://jsonplaceholder.typicode.com/posts";
            
            // execute same operation twice, see bug #41
            for (var i = 0; i < 2; i++)
            {
                var target = HttpFactory.Simple.Get(endpoint);

                // assert
                target.Should().NotBeNull();
                target.StatusCode.Should().Be(HttpStatusCode.OK);
                target.IsSuccessStatusCode.Should().BeTrue();    

                // assert - except an 'Accept' header, but exactly/only one
                target.RequestMessage.Headers.Accept.Any();
                target.RequestMessage.Headers.Accept.Count.Should().Be(1, because: "exactly 'one' Accept header is expected");
            }
        }
    }
}
