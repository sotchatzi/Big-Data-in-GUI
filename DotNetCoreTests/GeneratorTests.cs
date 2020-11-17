using Generators;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Tests
{
    public class GeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestForGenerator()
        {
            IGenerator generator = new ForLoopGenerator();
            IEnumerable<ItemList> result = generator.Generate(10000);
            ICollection collection = result as ICollection;
            Assert.AreEqual(10000, collection.Count);
        }

        [Test]
        public void TestYieldGenerator()
        {
            var generator = new YieldGenerator();
            var result = generator.Generate(10000);
            int total = 0;
            foreach(ItemList item in result)
            {
                total += 1;
            }
            Assert.AreEqual(10000, total);
        }
    }
}