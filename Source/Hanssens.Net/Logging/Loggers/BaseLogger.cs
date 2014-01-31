using System;
using System.Collections.Generic;

namespace Hanssens.Net.Logging
{
	/// <summary>
	/// Base logger; provides basic functionality for each concrete implementation.
	/// </summary>
	public abstract class BaseLogger : ILogger, IDisposable
	{
		public List<LogLine> Lines { get; private set; }

		public BaseLogger()
		{
			Lines = new List<LogLine>();
		}

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

		public abstract void Flush();

		public void Dispose()
		{
			this.Lines.Clear();
		}
	}

}

