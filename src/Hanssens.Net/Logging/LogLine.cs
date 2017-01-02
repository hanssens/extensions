using System;

namespace Hanssens.Net.Logging
{
	public class LogLine
	{
		public string Message { get; set; }
		public DateTime LogDate { get; set; }
		public LogTypes LogType { get; set; }

		public LogLine()
		{
			LogDate = DateTime.Now;
			LogType = LogTypes.Info;
		}

		public override string ToString()
		{
			return string.Format("{0} [{1}] {2}", LogDate, LogType, Message);
		}
	}
}

