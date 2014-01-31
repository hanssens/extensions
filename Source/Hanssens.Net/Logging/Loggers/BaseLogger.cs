using System;
using System.Collections.Concurrent;

namespace Hanssens.Net.Logging
{
	/// <summary>
	/// Base logger; provides basic functionality for each concrete implementation.
	/// </summary>
	public abstract class BaseLogger : ILogger, IDisposable
	{
		public ConcurrentBag<LogLine> Lines { get; private set; }

		public BaseLogger()
		{
			Lines = new ConcurrentBag<LogLine>();
		}

		public void Clear()
		{
			// considering the ConcurrentBag is thread-safe, this requires a 
			// bit dirty workaround for clearing the bag...
			lock (Lines) {
				Lines = new ConcurrentBag<LogLine> ();
			}
		}

		public abstract void Flush();

		public virtual void Write(string message)
		{
			Write(message, LogTypes.Info);
		}

		public virtual void Write(string message, LogTypes logType)
		{
			Write(new LogLine()
				{
					Message = message,
					LogType = logType
				});
		}

		public virtual void Write(LogLine logLine)
		{
			Lines.Add(logLine);
		}

		public void Dispose()
		{
			this.Clear ();
		}
	}

}

