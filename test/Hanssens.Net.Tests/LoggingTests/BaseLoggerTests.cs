using Hanssens.Net.Logging;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace Hanssens.Net.Tests.LoggingTests
{
	public class BaseLoggerTests
	{
		[Fact]
		public void ConsoleLogger_Should_Be_OfType_ILogger ()
		{
			var target = new ConsoleLogger ();
			target.Should ().NotBeNull ();
			target.Should ().BeAssignableTo<ILogger> ();
			target.Should ().BeAssignableTo<BaseLogger> ();
		}

		[Fact]
		public void FileLogger_Should_Be_OfType_ILogger ()
		{
			var target = new FileLogger ("irrelevant");
			target.Should ().NotBeNull ();
			target.Should ().BeAssignableTo<ILogger> ();
			target.Should ().BeAssignableTo<BaseLogger> ();
		}

		[Fact]
		public void BaseLogger_Should_Create_LogLine()
		{
			ILogger logger = new ConsoleLogger ();
			logger.Lines.Should ().BeEmpty ();

			var line = "this is a single line, which will be added";
			logger.Write (line);

			logger.Lines.Count.Should ().Be (1, because: "exactly 1 LogLine should be added");
			logger.Lines.First ().Message.Should ().BeEquivalentTo(line);
		}

		[Fact]
		public void BaseLogger_Clear_Should_Erase_All_Lines()
		{
			ILogger logger = new ConsoleLogger ();
			logger.Lines.Should ().BeEmpty ();

			var line = "this is a single line, which will be added";
			logger.Write (line);

			logger.Lines.Count.Should ().Be (1, because: "exactly 1 LogLine should be added");
			logger.Clear ();

			logger.Lines.Should ().BeEmpty ();
		}
	}
}

