using Create_List_WPF;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace NUnitTestCreatList
{
    public class Tests
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

        //[Test]
        //wait for debug
        public void TestYieldGenerator()
        {
            var generator = new YieldGenerator();
            var result = generator.Generate(10000);
            ICollection collection = result as ICollection;
            Assert.AreEqual(10000, collection.Count);
        }
    }
}