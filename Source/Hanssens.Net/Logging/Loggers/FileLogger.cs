using System;
using System.Text;
using System.IO;

namespace Hanssens.Net.Logging
{
	/// <summary>
	/// File logger; logs output to a sepcific plain-old textfile.
	/// </summary>
	public class FileLogger : BaseLogger
	{
		public string FileOutputPath { get; private set; }

		public FileLogger(string fileOutputPath)
		{
			FileOutputPath = fileOutputPath;
		}

		/// <summary>
		/// Outputs the result to file.
		/// </summary>
		public override void Flush()
		{
			var output = new StringBuilder();
			foreach (var log in Lines)
				output.Append(log.ToString() + "\r\n");

			using (var writer = new StreamWriter(FileOutputPath, true))
			{
				writer.Write(output.ToString());
			}

			Lines.Clear();
		}
	}
}

