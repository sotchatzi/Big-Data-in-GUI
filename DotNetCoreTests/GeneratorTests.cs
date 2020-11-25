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
        [TestCaseSource(nameof(SizeAndGenerator))]
        [Description("Tests that the yeild return Generator works")]
        public void TestYieldGeneratorNum(int size, IGenerator generator)
        {
            // arrange
            // act
            var result = generator.Generate(size).ToList(); ;

            // assert
            Assert.AreEqual(size, result.Count);
        }
    }

    public class YieldGeneratorScaleTest
    {
        static IEnumerable<TestCaseData> SizeGenerator()

        {
            yield return new TestCaseData(10);

            yield return new TestCaseData(1000);


        }

        [Test]
        [TestCaseSource(nameof(SizeGenerator))]
        [Description("Tests that the problematic yeild return Generator works")]
        public void TestFail20Generator(int size)
        {
            // arrange
            IGenerator generator = new Fail20Generator();
            int FailElement = (int)0.2 * size;
            int problematic_total = 0;
            // act
            var result = generator.Generate(size).ToList();
            int ProblematicCount = result.Count(t => t.AString == "InvalidString");
            // assert
            Assert.AreEqual(FailElement, problematic_total);

        }

        [Test]
        [TestCaseSource(nameof(SizeGenerator))]
        [Description("Tests that the problematic yeild return Generator works")]
        public void TestFail20Slow10Generator(int size)
        {
            // arrange
            IGenerator generator = new Fail20Slow10Generator();
            int FailElement = (int)(0.2 * size);
            // act
            var result = generator.Generate(size).ToList();
            int ProblematicCount = result.Count(t => t.AString == "InvalidString");
            // assert
            Assert.AreEqual(FailElement, ProblematicCount);

        }

        
        [Test]
        [TestCaseSource(nameof(SizeGenerator))]
        [Description("Tests that the problematic Fail20Timesout10 Generator works")]
        public void TestFail20Timesout10Generator(int size)
        {
            // arrange
            IGenerator generator = new Fail20Timesout10Generator();
            int FailElement = (int)(0.2 * size);
  //          int TimeoutElement = (int)(0.1 * size);
            // act
            var result = generator.Generate(size).ToList();
            int ProblematicFailCount = result.Count(t => t.AString == "InvalidString");
//            int ProblematicTimeoutCount = result.Count(t => t.AString == "Time out");
            // assert
            Assert.AreEqual(ProblematicFailCount, FailElement);
 //           Assert.AreEqual(ProblematicTimeoutCount, TimeoutElement);

        }
    }
}