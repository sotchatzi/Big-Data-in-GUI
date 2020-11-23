using Generators;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace GeneratorTests
{
    public class GeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        static IEnumerable<TestCaseData> SizeGenerator()

        {

            yield return new TestCaseData(0);

            yield return new TestCaseData(1);

            yield return new TestCaseData(100000);


        }

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
        [Test]
        [TestCaseSource(nameof(SizeGenerator))]
        [Description("Tests that the Yield Generator works")]
        public void TestYieldGenerator(int size)
        {
            // arrange
            var generator = new YieldGenerator();
            // act
            var result = generator.Generate(size);
            int total = 0;
            foreach(ItemList item in result)
            {
                total += 1;
            }
            // assert
            Assert.AreEqual(size, total);
         
        }
        [Test]
        [TestCaseSource(nameof(SizeGenerator))]
        [Description("Tests that the Slow Generator works")]
        public void TestSlowGenerator(int size)
        {
            // arrange
            var generator = new SlowGenerator();
            // act
            if(size == 100000)
            {
                size = 100;
            }
            var result = generator.Generate(size);
            int total = 0;
            foreach (ItemList item in result)
            {
                total += 1;
            }
            // assert
            Assert.AreEqual(size, total);
        } 
    }
}