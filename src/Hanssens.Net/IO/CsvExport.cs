using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Hanssens.Net.Extensions;

namespace Hanssens.Net.IO
{

	/// <summary>
	/// Helper for exporting *any* collection to a CSV file.
	/// </summary>
	/// <example>
	///     var exporter = new CsvExport<Customer>(customers);
	///     exporter.ExportToFile(@"c:\temp\output.csv", includeHeaderLine: true, seperatorChar: ';');
	/// </example>
	public class CsvExport<T> where T : class
	{
		public IEnumerable<T> Collection { get; private set; }

		public CsvExport(IEnumerable<T> collection)
		{
			Collection = collection;
		}

		/// <summary>
		/// Renders a string based value.
		/// </summary>
		/// <param name="includeHeaderLine">Renders the first line as a header line, based on the property names (default is 'true').</param>
		/// <param name="seperatorChar">The seperator character, by default a comma (',').</param>
		public string Export(bool includeHeaderLine = true, char seperatorChar = ',')
		{
			var sb = new StringBuilder();

			var seperator = seperatorChar.ToString();


			//Get properties using reflection.
			var propertyInfos = typeof(T).GetRuntimeProperties();

			if (includeHeaderLine)
			{
				//add header line.
				foreach (PropertyInfo propertyInfo in propertyInfos)
				{
					sb.Append(propertyInfo.Name).Append(seperator);
				}
				sb.Remove(sb.Length - 1, 1).AppendLine();
			}

			//add value for each property.
			foreach (T obj in Collection)
			{
				foreach (PropertyInfo propertyInfo in propertyInfos)
				{
					sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(seperator);
				}
				sb.Remove(sb.Length - 1, 1).AppendLine();
			}

			return sb.ToString();
		}

		/// <summary>
		/// Exports the collection to a file.
		/// </summary>
		/// <param name="path">Full output file- and pathname.</param>
		public void ExportToFile(string path, bool includeHeaderLine = true, char seperatorChar = ',')
		{
			File.WriteAllText(path, Export(includeHeaderLine: includeHeaderLine, seperatorChar: seperatorChar));
		}

		/// <summary>
		/// Exports as binary data.
		/// </summary>
		public byte[] ExportToBytes(bool includeHeaderLine = true, char seperatorChar = ',')
		{
			return Encoding.UTF8.GetBytes(Export(includeHeaderLine: includeHeaderLine, seperatorChar: seperatorChar));
		}

		/// <summary>
		/// Get the csv value for the field.
		/// </summary>
		/// <param name="value"></param>
		private string MakeValueCsvFriendly(object value)
		{
		    if (Reflection.IsNull(value)) return string.Empty;

            if (value is DateTime)
			{
				if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
					return ((DateTime)value).ToString("yyyy-MM-dd");
				return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
			}

			string output = value.ToString();

			if (output.Contains(",") || output.Contains("\""))
				output = '"' + output.Replace("\"", "\"\"") + '"';

			return output;

		}
	}
}

