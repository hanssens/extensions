using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hanssens.Net.Tests
{
    [TestClass]
    public class LinqExtensionTests
    {
        [TestMethod]
        public void WhereInTest()
        {
            var expectedValues = new int[] {1, 2, 3, 4, 5};
            var values = new List<int>();
            for (var i = 0; i < 99; i++)
                values.Add(i);

            var target = values.Where(v => v.In(expectedValues));
            Assert.IsTrue(target.Count() == expectedValues.Count());
            foreach (var i in target)
                Assert.IsTrue(expectedValues.Any(c => c == i));

        }
    }
}
