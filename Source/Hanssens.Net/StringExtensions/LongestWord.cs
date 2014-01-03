using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.Extensions
{
    public static class LongestWordExtensions
    {
        /// <summary>
        /// Extracts the longest word from a sentence.
        /// </summary>
        /// <param name="sentence">Sentence to extract the longest word from.</param>
        /// <returns>Returns null if imput is EmptyOrNull, otherwise returns the longest word without punctuations.</returns>
        public static string LongestWord(this string sentence)
        {
            if (String.IsNullOrEmpty(sentence)) return null;

            var words = new string(sentence.ToCharArray()
                // strip all punctuations
                .Where(c => !char.IsPunctuation(c))
                // reassemble to a single string
                .ToArray())
                // split by spaces, to get the words
                .Split(' ')
                // order by length, descending, to get the longest word first
                .OrderByDescending(w => w.Length)
                // and fetch the first (= longest) word
                .First();

            // Note: ignore punctuation would result in:
            // return sentence.Split(' ').OrderByDescending(w => w.Length).First();
            return words;
        }
    }


}
