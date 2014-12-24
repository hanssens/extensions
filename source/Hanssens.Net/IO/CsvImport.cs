using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;

namespace Hanssens.Net.IO
{
	/// <summary>
	/// Helper for importing a CSV file, into a dynamic or strong-typed collection.
	/// </summary>
	public class CsvImport
	{
		public IEnumerable<dynamic> Import(string filePath, bool firstLineIsHeaderLine = true, char seperatorChar = ','){

			// read all lines
			var lines = _ReadAllLines (filePath);

			if (firstLineIsHeaderLine) {
				// TODO: Create new dynamic object, properties
			}

			foreach (var line in lines) {

				// split each line into fields, using the provided seperator
				var fields = line.Split (seperatorChar);

				// todo: finish up
			}

			throw new NotImplementedException ();
		}

		/// <summary>
		/// Imports the provided CSV file as a strong-typed collection.
		/// </summary>
		/// <param name="filePath">The full filepath to the CSV file.</param>
		/// <param name="firstLineIsHeaderLine">If set to <c>true</c> will map the properties of the first line to the properties of the provided <c>T class</c>.</param>
		/// <typeparam name="T">The type to (try) and cast to.</typeparam>
		public IEnumerable<T> Import<T>(string filePath, bool firstLineIsHeaderLine = true, char seperatorChar = ',') 
			where T : class {
			throw new NotImplementedException ();
		}

		private IEnumerable<string> _ReadAllLines(string filePath){

			if (String.IsNullOrEmpty (filePath)) throw new ArgumentNullException ("filePath");
			if (!File.Exists (filePath)) throw new FileNotFoundException ("CsvImport.Import could not find the file: " + filePath);

			string line;
			using(var reader = File.OpenText(filePath)) {
				while((line = reader.ReadLine()) != null) {
					yield return line;
				}
			}

			using (var stream = new FileStream (filePath, FileMode.Open, FileAccess.Read)) {

			}
		}
	}
}

