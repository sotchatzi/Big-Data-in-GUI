using Generators;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorTests
{
    public class GeneratorNumTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// arrange the test cases 
        /// </summary>
        /// <returns></returns>
        static IEnumerable<TestCaseData> SizeGenerator()

        {

            yield return new TestCaseData(0);

            yield return new TestCaseData(1);

            yield return new TestCaseData(100000);


        }

        /// <summary>
        /// Test that whether the for loop generator would return the correct number of results 
        /// </summary>
        /// <param name="size"></param>
        [Test]
        [TestCaseSource("SizeGenerator")]
        [Description("Tests that the For Loop Generator works")]
        public void TestForLoopGenerator(int size)
        {
            // arrange
            IGenerator generator = new ForLoopGenerator();
            // act
            IEnumerable<ItemList> result = generator.Generate(size);
            ICollection collection = result as ICollection;
            // assert
            Assert.AreEqual(size, collection.Count);
        }
        
    }
    public class YieldGeneratorNumTest
    {
        [SetUp]
        public void Setup()
        { 
        }
        /// <summary>
        /// Arrange test cases and generator
        /// </summary>
        /// <returns></returns>
        static IEnumerable<TestCaseData> SizeAndGenerator()
        {
            foreach (var size in Sizes())
            {
                foreach (var generator in Generators())
                {
                    yield return new TestCaseData(size, generator);
                }
            }
        }
        static IEnumerable<int> Sizes()
        {
            yield return 1;
            yield return 10;
            yield return 100;
            yield return 1000;
            yield return 10000;
        }
        static IEnumerable<IGenerator> Generators()
        {
            yield return new ForLoopGenerator();
            yield return new YieldGenerator();
            yield return new SlowGenerator();
            yield return new Slow20Generator();
            yield return new Fail20Generator();
            yield return new Fail20Slow10Generator();
            yield return new Fail20Timesout10Generator();
        }

        /// <summary>
        /// Test that whether the yield return type generator would return the correct number of results 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="generator"></param>
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