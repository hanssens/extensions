using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Hanssens.Net.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hanssens.Net.Tests.InTests
{
    [TestClass]
    public class LinqExtensionTests
    {


        [TestMethod]
        public void In_Should_Fetch_Single_Value_From_Collection()
        {
            var expected = "Harry";
            var values = new string[] { "Barry", "Larry", "Harry" };

            var target = values.FirstOrDefault(name => name.In(expected));

            target.Should().NotBeNull("Harry should be found");
            target.Should().BeEquivalentTo(expected, "Harry should be found");
        }

        [TestMethod]
        public void In_Should_Fetch_Single_Object_From_Collection()
        {
            // Note: Requires object to implement IEquality (or override Equals/GetHashCode)

            var expected = new Customer(2, "Harry");
            var collection = new List<Customer>
            {
                new Customer(1, "Barry"),
                new Customer(2, "Harry"),
                new Customer(3, "Larry")
            };

            var target = collection.Where(c => c.In(expected));
            
            //var x = values.FirstOrDefault<Customer>(expected);
            target.Should().NotBeNull("result should not be null");
            target.Count().Should().Be(1);
            target.First().Id.Should().Be(expected.Id, "Wrong ID");
            target.First().Name.Should().Be(expected.Name, "Wrong Name");
        }



        [TestMethod]
        public void In_Should_Filter_Multiple_Values_From_Collection()
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

        internal class Customer : IEquatable<Customer>
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Customer(int id, string name)
            {
                Id = id;
                Name = name;
            }

            bool IEquatable<Customer>.Equals(Customer other)
            {
                return Equals(other);
            }

            public override bool Equals(object obj)
            {
                var other = (Customer) obj;
                if (this.Id != other.Id) return false;
                if (this.Name != other.Name) return false;
                return true;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}
