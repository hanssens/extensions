using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Hanssens.Net.Tests
{
    [TestFixture]
    public class FooTests
    {
        [Test]
        public void ShouldBeInitializable()
        {
            var target = new Foo();
            target.Should().NotBeNull();
        }
    }
}
