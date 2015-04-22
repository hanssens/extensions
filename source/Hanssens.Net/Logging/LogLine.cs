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
			this.LogDate = DateTime.Now;
			this.LogType = LogTypes.Info;
		}

		public override string ToString()
		{
			return String.Format("{0} [{1}] {2}", LogDate, LogType, Message);
		}
	}
}

