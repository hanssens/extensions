using System;
using System.Reflection;

namespace Hanssens.Net.Reflection
{
	/// <summary>
	/// Provide utilities for inspecting and extracting information from object instances.
	/// </summary>
	public static class Extract
	{

		/// <summary>
		/// Extracts the property value from an object instance, by it's property name.
		/// </summary>
		/// <typeparam name="T">Type to extract the property from.</typeparam>
		/// <param name="instance"></param>
		/// <param name="propertyToExtract">Name of the property to extract the value from.</param>
		/// <returns>Returns the value of the property, or 'null' if the property is not found.</returns>
		/// <remarks>
		/// Handy for extracting values when no contract, or interface, is defined. For example,
		/// I've used this frequently when I needed an ID + Name from an object that was retrieve
		/// by an external webservice callback.
		/// </remarks>
		public static object ExtractPropertyValue<T>(T instance, string propertyToExtract) where T : class
		{
			if (instance == null) throw new ArgumentNullException("instance");
			if (String.IsNullOrEmpty(propertyToExtract)) throw new ArgumentNullException("propertyToExtract");

			var t = typeof (T);

			// lookup the property, notice the flags (e.g. ignoring case, public properties etc.)
			var property = t.GetProperty(propertyToExtract, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

			// return the value or null if not found
			return (property == null) ? null : property.GetValue(instance);
		}

	}
}

