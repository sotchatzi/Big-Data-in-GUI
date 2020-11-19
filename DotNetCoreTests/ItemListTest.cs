using Generators;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreTests
{
    public class ItemListTest
    {
        [Test, Description("Tests that the get() works")]
        public void ItemListGet([Random(1, 1000, 1)] int index)
        {
            var randomString = new RandomUtil();
            ItemList anItemList = new ItemList() { AnIndex = index, AString = randomString.GetRandomString(1, 0, 0, index) };
            Assert.That(anItemList.AnIndex, Is.Not.Null);
            Assert.That(anItemList.AString, Is.Not.Null);
        }

        [Test, Description("Tests that the set() works")]
        public void ItemListSet([Random(1, 1000, 1)] int index)
        {
            var randomString = new RandomUtil();
            ItemList anItemList = new ItemList() { AnIndex = index, AString = randomString.GetRandomString(1, 0, 0, index) };

            anItemList.AnIndex = 2;
            anItemList.AString = "updated value";

            Assert.AreEqual(anItemList.AnIndex, 2);
            Assert.AreEqual(anItemList.AString, "updated value");
        }

    }
}
