﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hanssens.Net
{
    /// <summary>
    /// Utilities for randomizing.
    /// </summary>
    public class Randomizer : IDisposable
    {
        protected Random randomizer { get; private set; }

        public Randomizer()
        {
            //var seed = new Random();
            //seed.Next(Int32.MinValue, Int32.MaxValue);
            //this.randomizer = new Random(seed.Next());
            this.randomizer = new Random();
            this.Kick();
        }

        /// <summary>
        /// "Kicks" the randomizer seed.
        /// </summary>
        protected void Kick()
        {
            var seed = new Random(randomizer.Next());
            randomizer.Next(seed.Next());

            //randomizer.Next(Int32.MinValue, Int32.MaxValue);
        }

        /// <summary>
        /// Retrieve a random item from the strong typed collection.
        /// </summary>
        public T Random<T>(IEnumerable<T> collection)
        {
            this.Kick();

            // Create a filtered list, containing only T-types
            List<T> filteredCollection = new List<T>();
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
            // should do something here... or not
        }
    }
}
