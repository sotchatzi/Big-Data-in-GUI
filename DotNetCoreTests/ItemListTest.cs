using Generators;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreTests
{
    public class ItemListTest
    {
        [Test, Description("Tests that the get() for AnIndex field works")]
        public void ItemListGetAnIndex([Random(1, 1000, 1)] int index)
        {
            ItemList anItemList = new ItemList() { AnIndex = index, AString = RandomUtil.GetRandomString() };
            Assert.That(anItemList.AnIndex, Is.Not.Null);
        }

        [Test, Description("Tests that the get() for AString field works")]
        public void ItemListGetAString([Random(1, 1000, 1)] int index)
        {
            ItemList anItemList = new ItemList() { AnIndex = index, AString = RandomUtil.GetRandomString() };
            Assert.That(anItemList.AString, Is.Not.Null);
        }

        [Test, Description("Tests that the set() for AnIndex field works")]
        public void ItemListSetAnIndex([Random(1, 1000, 1)] int index)
        {
            ItemList anItemList = new ItemList() { AnIndex = index, AString = RandomUtil.GetRandomString() };

            anItemList.AnIndex = 2;

            Assert.AreEqual(anItemList.AnIndex, 2);
        }

        [Test, Description("Tests that the set() for AStringworks")]
        public void ItemListSetAString([Random(1, 1000, 1)] int index)
        {
            ItemList anItemList = new ItemList() { AnIndex = index, AString = RandomUtil.GetRandomString() };

            anItemList.AString = "updated value";

            Assert.AreEqual(anItemList.AString, "updated value");
        }

    }
}
