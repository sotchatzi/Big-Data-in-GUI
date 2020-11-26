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
            IEnumerable<ItemList> result_zero_loop = generator.Generate(0);
            IEnumerable<ItemList> result_one_loop = generator.Generate(1);
            IEnumerable<ItemList> result_n_loop = generator.Generate(10000);
            ICollection collection_zero_loop = result_zero_loop as ICollection;
            Assert.AreEqual(0, collection_zero_loop.Count);
            ICollection collection_one_loop = result_one_loop as ICollection;
            Assert.AreEqual(1, collection_one_loop.Count);
            ICollection collection_n_loop = result_n_loop as ICollection;
            Assert.AreEqual(10000, collection_n_loop.Count);
        }

        [Test]
        public void TestYieldGenerator()
        {
            var generator = new YieldGenerator();
            var result_zero_loop = generator.Generate(0);
            int total_zero_loop = 0;
            foreach(ItemList item in result_zero_loop)
            {
                total_zero_loop += 1;
            }
            Assert.AreEqual(0, total_zero_loop);
            var result_one_loop = generator.Generate(1);
            int total_one_loop = 0;
            foreach (ItemList item in result_one_loop)
            {
                total_one_loop += 1;
            }
            Assert.AreEqual(1, total_one_loop);
            var result_n_loop = generator.Generate(10000);
            int total_n_loop = 0;
            foreach (ItemList item in result_n_loop)
            {
                total_n_loop += 1;
            }
            Assert.AreEqual(10000, total_n_loop);
        }

        [Test]
        public void TestSlowGenerator()
        {
            var generator = new SlowGenerator();
            var result_zero_loop = generator.Generate(0);
            int total_zero_loop = 0;
            foreach (ItemList item in result_zero_loop)
            {
                total_zero_loop += 1;
            }
            Assert.AreEqual(0, total_zero_loop);
            var result_one_loop = generator.Generate(1);
            int total_one_loop = 0;
            foreach (ItemList item in result_one_loop)
            {
                total_one_loop += 1;
            }
            Assert.AreEqual(1, total_one_loop);
            var result_n_loop = generator.Generate(10000);
            int total_n_loop = 0;
            foreach (ItemList item in result_n_loop)
            {
                total_n_loop += 1;
            }
            Assert.AreEqual(10000, total_n_loop);
        } 
    }
}