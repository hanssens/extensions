using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hanssens.Net.Extensions
{
    public partial class ReflectionExtensions
    {
        /// <summary>
        /// Determines if the instance of an object is null, 
        /// regardsless if it is a value type or reference type.
        /// </summary>
        public static bool IsNull(object obj)
        {
            if (obj == null) return true;

            if (IsNullableType(obj))
            {
                // in case of a nullable type, either generic or non-generic,
                // inspect the value

                // if the object is a value type, we can get a new instance of it
                // this allows us to use that for a null comparison
                var compare = Activator.CreateInstance(obj.GetType());
                return compare.Equals(obj);
            }

            return false;
        }

    }
}
