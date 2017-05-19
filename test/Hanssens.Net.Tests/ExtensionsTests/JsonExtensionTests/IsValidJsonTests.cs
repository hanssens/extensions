using FluentAssertions;
using Hanssens.Net.Extensions;
using Xunit;

namespace Hanssens.Net.Tests
{
	//[TestFixture(Category = "JsonExtensions")]
	public class IsValidJsonTests
	{

		[Fact]
		public void IsValidJson_Should_Validate_Single_Item_As_Correct_Json(){
			// arrange
			var input = @"{'ip': '87.236.6.162'}";

			// act
			var target = JsonExtensions.IsValidJson (input);

			// assert
			target.Should ().BeTrue ();
		}

		[Fact]
		public void IsValidJson_Should_Validate_Empty_Json_Structure_As_Correct_Json(){
			// arrange
			var input = "[{ }]";

			// act
			var target = JsonExtensions.IsValidJson (input);

			// assert
			target.Should ().BeTrue ();
		}

		[Fact]
		public void IsValidJson_ShouldNot_Validate_Incorrect_Json_Format(){
			// arrange
			var input = @"this.is.not.json";

			// act
			var target = JsonExtensions.IsValidJson (input);

			// assert
			target.Should ().BeFalse ();
		}

		[Fact]
		public void IsValidJson_Should_Validate_Collection_As_Valid_Json(){
			// arrange
			var input = "[{ 'name': 'harry potter' }, { 'name': 'hermoine granger' }, { 'name': 'albus dumbledore' }]";

			// act
			var target = JsonExtensions.IsValidJson (input);

			// assert
			target.Should ().BeTrue ();
		}
	}
}

