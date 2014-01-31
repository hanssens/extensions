using System;

namespace Hanssens.Net.Logging
{
	/// <summary>
	/// Console logger; outputs the result to the Console window.
	/// </summary>
	public class ConsoleLogger : BaseLogger
	{
		/// <summary>
		/// Outputs the result to the Console Window
		/// </summary>
		public override void Flush()
		{
			foreach (var log in Lines)
			{
				switch (log.LogType)
				{
				case LogTypes.Debug:
					Console.ForegroundColor = ConsoleColor.White;
					break;
				case LogTypes.Error:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case LogTypes.Warning:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case LogTypes.Info:
				default:
					Console.ResetColor();
					break;
				}

				Console.WriteLine(log.ToString());
				Console.ResetColor();
			}


			Clear ();
		}
	}
}

