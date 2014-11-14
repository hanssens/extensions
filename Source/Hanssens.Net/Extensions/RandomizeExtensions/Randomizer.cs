using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net.Extensions
{
    /// <summary>
    /// Utilities for randomizing.
    /// </summary>
    public class Randomizer : IDisposable
    {
        protected Random randomizer { get; private set; }

        public Randomizer()
        {
			// initialize a semi-unique seed, based on a 
			// newly generated Guid's hashcode
			var uniqueSeed = Guid.NewGuid ().GetHashCode ();

			// initialize a new Random instance, based on the seed
			this.randomizer = new Random(uniqueSeed);

			// start kicking it
            this.Kick();
        }

        /// <summary>
        /// "Kicks" the randomizer seed.
        /// </summary>
        protected void Kick()
        {
            var seed = new Random(randomizer.Next());
            randomizer.Next(seed.Next());
        }

        /// <summary>
        /// Fetches a random item from the provided collection.
        /// </summary>
        public T Random<T>(IEnumerable<T> collection)
        {
            this.Kick();

            // Create a filtered list, containing only T-types
            var filteredCollection = new List<T>();
            foreach (T item in collection)
                filteredCollection.Add(item);

            // Get a random value from the list
            return filteredCollection[randomizer.Next(0, filteredCollection.Count)];
        }

        /// <summary>
        /// Retrieves a random (Int32) number, based on the RNGCryptoServiceProvider.
        /// </summary>
        /// <remarks>
        /// The return value can be both positive (+0) as well as negative (-0) and cannot
        /// be offset with a minimum or maximum value. 
        /// Use the Random(min, max) overload if this is required, but note that this 
        /// can provide less accurate 'random' results.
        /// </remarks>
        public int Random()
        {
            var bytes = new byte[sizeof(Int32)];
            var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        /// <remarks>
        /// Uses the crypto services, not the Random() class.
        /// </remarks>
        public int Random(int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            this.Kick();
            return randomizer.Next(min, max);
        }

        public void Dispose()
        {
            // Nothing to see here, move along...
        }
    }
}
