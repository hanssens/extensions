using System;
using System.Collections.Concurrent;

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
		ConcurrentBag<LogLine> Lines { get; }

		void Clear();
		void Write(string message);
		void Write(string message, LogTypes logType);
		void Write(LogLine logLine);
		void Flush();
	}
}

