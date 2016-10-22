using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hanssens.Net.Extensions
{
    public partial class Reflection
    {
        /// <summary>
        /// Determines if the *Type* of an object instance is nullable, 
        /// regardless if it is a value type or reference type.
        /// </summary>
        public static bool IsNullableType<T>(T obj)
        {
            // the obvious and simplest, perhaps even cheapest, comparison
            // is simply inspecting the value
            if (obj == null) return true;

            var type = typeof(T);
            if (type.IsGenericParameter)
            {
                // determine for a generic type Nullable<T>
                return (type.IsGenericParameter && type.GetGenericTypeDefinition() == typeof(Nullable<>));
            }
            else
            {
                // determine for a non-generic type
                return (Nullable.GetUnderlyingType(type) != null);
            }
        }

    }
}
