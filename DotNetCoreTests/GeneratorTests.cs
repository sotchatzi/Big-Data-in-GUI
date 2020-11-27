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
            int FailElement = (int)(0.2 * size);
            // act
            var result = generator.Generate(size).ToList();
            int ProblematicCount = result.Count(t => t.AFlag == 2);
            // assert
            Assert.AreEqual(FailElement, ProblematicCount);
        }
        [Test]
        [TestCaseSource(nameof(SizeGenerator))]
        [Description("Tests that the problematic yeild return Generator works")]
        public void TestFail20Slow10Generator(int size)
        {
            // arrange
            IGenerator generator = new Fail20Slow10Generator();
            int FailElement = (int)(0.2 * size);
            int SlowElement = (int)(0.1 * size);
            // act
            var result = generator.Generate(size).ToList();
            int ProblematicFailCount = result.Count(t => t.AFlag == 2 | t.AFlag == 4 );
            int ProblematicSlowCount = result.Count(t => t.AFlag == 1 | t.AFlag == 4 );
            // assert
            Assert.AreEqual(FailElement, ProblematicFailCount );
            Assert.AreEqual(SlowElement, ProblematicSlowCount );
        }
        [Test]
        [TestCaseSource(nameof(SizeGenerator))]
        [Description("Tests that the problematic yeild return Generator works")]
        public void TestNormal70Fail20Slow10(int size)
        {
            // arrange
            IGenerator generator = new Normal70Fail20Slow10();
            int FailElement = (int)(0.2 * size);
            int SlowElement = (int)(0.1 * size);
            // act
            var result = generator.Generate(size).ToList();
            int ProblematicFailCount = result.Count(t => t.AFlag == 2);
            int ProblematicSlowCount = result.Count(t => t.AFlag == 1);
            // assert
            Assert.AreEqual(FailElement, ProblematicFailCount);
            Assert.AreEqual(SlowElement, ProblematicSlowCount);
        }
        [Test]
        [TestCaseSource(nameof(SizeGenerator))]
        [Description("Tests that the problematic Fail20Timesout10 Generator works")]
        public void TestFail20Timesout10Generator(int size)
        {
            // arrange
            IGenerator generator = new Fail20Timesout10Generator();
            int FailElement = (int)(0.2 * size);
            int TimeoutElement = (int)(0.1 * size);
            // act
            var result = generator.Generate(size).ToList();
            int ProblematicFailCount = result.Count(t => t.AFlag == 2);
            int ProblematicTimeoutCount = result.Count(t => t.AFlag == 3);
            // assert
            Assert.AreEqual(FailElement, ProblematicFailCount );
            Assert.AreEqual(TimeoutElement, ProblematicTimeoutCount );
        }
    }

    public class UserDefinedGeneratorScaleTest
    {

        static IEnumerable<TestCaseData> UserInput()
        {
            foreach (var FailPercentage in FailPercentages())
            {
                foreach (var SlowPercentage in SlowPercentages())
                {
                    yield return new TestCaseData(FailPercentage, SlowPercentage);
                }
            }
        }
        static IEnumerable<int> FailPercentages()
        {
            yield return 10;
            yield return 30;
        }

        static IEnumerable<int> SlowPercentages()
        {
            yield return 10;
            yield return 30;
        }

        [Test]
        [TestCaseSource(nameof(UserInput))]
        [Description("Tests that the User Defined FailSlow Generator works")]
        public void TestFailSlowGenerator(int FailPercentage, int SlowPercentage)
        {
            // arrange
            int size = 100;
            int FailElement = (int)(FailPercentage * 0.01 * size);
            int TimeoutElement = (int)(SlowPercentage * 0.01 * size);
            IGenerator generator = new FailSlowGenerator(FailElement, TimeoutElement );
            // act
            var result = generator.Generate(size).ToList();
            int ProblematicFailCount = result.Count(t => t.AFlag == 2 | t.AFlag == 4);
            int ProblematicTimeoutCount = result.Count(t => t.AFlag == 1 | t.AFlag == 4);
            // assert
            Assert.AreEqual(FailElement, ProblematicFailCount);
            Assert.AreEqual(TimeoutElement, ProblematicTimeoutCount);
        }
    }
    }
