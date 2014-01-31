using System;

namespace Hanssens.Net.Logging
{
	public enum LogTypes
	{
		/// <summary>
		/// The default message type.
		/// </summary>
		Info,
		Debug,
		Error,
		Warning
	}

	public interface ILogger
	{
		void Write(string message);
		void Write(string message, LogTypes logType);
		void Write(LogLine logLine);
		void Flush();
	}
}

