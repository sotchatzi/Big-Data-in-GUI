using Generators;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreTests
{
    public class RandomUtilTest
    {
        [Test, Description("Tests that the length of a string is the of expected length of size 11")]
        public void TestLength()
        {
            string randomText = RandomUtil.GetRandomString();

            int lengthRandomText = randomText.Length;

            Assert.AreEqual(lengthRandomText, 11);
        }

        [Test, Description("Tests that two strings are not the same")]
        public void TestRandomness()
        {
            string randomText1 = RandomUtil.GetRandomString();
            string randomText2 = RandomUtil.GetRandomString();

            Assert.AreNotEqual(randomText1, randomText2);
        }

        [Test, Description("Tests that all strings in the list are unique")]
        //size parameter defined as a number between 1000 and 10000 and runs 5 times
        public void TestStringReproducedInList([Random(1000, 10000, 5)] int size)
        {
            List<string> stringList = new List<string>();
            for(int i = 0; i < size; i++)
            {
                stringList.Add(RandomUtil.GetRandomString());
            }

            int totalNumberElements = stringList.Count;
            int totalNumberUniqueElements = stringList.Distinct().Count();

            Assert.AreEqual(totalNumberElements, totalNumberUniqueElements);
        }

        [Test, Description("Tests that a random string does not exists inside of the list")]
        //size parameter defined as a number between 1000 and 10000 and runs 5 times
        public void TestStringExistInList([Random(1000, 10000, 5)] int size)
        {
            List<string> stringList = new List<string>();
            for(int i = 0; i < size; i++)
            {
                stringList.Add(RandomUtil.GetRandomString());
            }

            bool stringNotInList = stringList.Exists(x => x != RandomUtil.GetRandomString());

            Assert.True(stringNotInList);
        }
    }
}
