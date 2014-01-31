using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hanssens.Net.Web.Extensions
{
    public static class SelectListExtensions
    {
        /// <summary>
        /// A generic SelectList generator, for usage in DropDownLists, that works on any IEnumerable list.
        /// </summary>
        /// <typeparam name="T">Optionally explicit type</typeparam>
        /// <param name="enumerable">The enumarble list</param>
        /// <param name="text">The property value that is used for display</param>
        /// <param name="value">The property value used for the value</param>
        /// <param name="defaultOption">For example "--- make a choice ---"</param>
        /// <returns>Returns a </returns>
        /// <example>
        /// @Html.DropDownList("ListOfUsers", Model.ToSelectList(m => m.DisplayName, m => m.Id.ToString(), "--- kies een user---"))
        /// </example>
        /// <remarks>
        /// Thanks to: http://stackoverflow.com/questions/781987/how-can-i-get-this-asp-net-mvc-selectlist-to-work
        /// </remarks>
        public static List<SelectListItem> ToSelectList<T>(
          this IEnumerable<T> enumerable,
          Func<T, string> text,
          Func<T, string> value,
          string defaultOption)
        {

            var items = enumerable.Select(f => new SelectListItem()
            {
                Text = text(f),
                Value = value(f)
            }).ToList();
            items.Insert(0, new SelectListItem()
            {
                Text = defaultOption,
                Value = "-1"
            });
            return items;
        }
    }
}
