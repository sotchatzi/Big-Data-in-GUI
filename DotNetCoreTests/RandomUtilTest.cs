using Generators;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreTests
{
    public class RandomUtilTest
    {
        [Test(ExpectedResult = 11), Description("It tests if the length of a string is the expected length of size 11")]
        public int TestLength()
        {
            string randomText = RandomUtil.GetRandomString();
            int lengthRandomText = randomText.Length;

            return lengthRandomText;
        }

        [Test(ExpectedResult = true), Description("It tests if two strings are the same")]
        public bool TestRandomness()
        {
            string randomText1 = RandomUtil.GetRandomString();
            string randomText2 = RandomUtil.GetRandomString();

            return randomText1 != randomText2;
        }

        [Test, Description("It tests if all strings in the list are unique")]
        //size parameter defined as a number between 1000 and 10000 and runs 5 times
        public void TestStringReproducedInList([Random(1000, 10000, 5)] int size)
        {
            List<string> stringList = new List<string>();
            for(int i = 1; i < size; i++)
            {
                stringList.Add(RandomUtil.GetRandomString());
            }
            Assert.AreEqual(stringList.Count, stringList.Distinct().Count());
        }

        [Test, Description("It tests if a random string exists inside of the list")]
        //size parameter defined as a number between 1000 and 10000 and runs 5 times
        public void TestStringExistInList([Random(1000, 10000, 5)] int size)
        {
            List<string> stringList = new List<string>();
            for(int i = 0; i < size; i++)
            {
                stringList.Add(RandomUtil.GetRandomString());
            }
            Assert.True(stringList.Exists(x => x != RandomUtil.GetRandomString()));
        }
    }
}
