using System;
using System.Collections.Generic;
using System.Threading;

namespace Generators
{
    public class Normal70Fail20Slow10 : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            double percentSize = 0.3 * size;
            double percentSizeFail = 0.2 * size;

            ProblematicElements problematicElements = new ProblematicElements();
            SortedSet<int> problematicSet = problematicElements.CreateSetFromPercentage(size, (int)percentSize);
            SortedSet<int> problematicSetFail = problematicElements.CreateSetFromPercentage((int)percentSize, (int)percentSizeFail);
            ItemList item;
            int j = 1;
            for (int i = 1; i <= size; i++)
            {
                if (problematicSet.Contains(i))
                {
                    if (problematicSetFail.Contains(j))
                    {
                        item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomStringSpecialChar(), AFlag = 2 };
                    }
                    else
                    {
                        Thread.Sleep(1);
                        item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString(), AFlag = 1 };
                    }
                    j += 1;

                }
                else
                {
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString(), AFlag = 0 };
                }

                //ExpectedString.StringWithNoSpecialChar(item);
                ExpectedString.StringWithNoSpecialCharWithoutException(item);

                yield return item;
            }
        }
    }

}