using System;
using System.Collections.Generic;
using System.Threading;

namespace Generators
{
    public class Fail20Timesout10Generator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            double percentSize = 0.3 * size;
            double percentSizeFail = 0.2 * size;

            ProblematicElements problematicElements = new ProblematicElements();
            SortedSet<int> problematicSet = problematicElements.CreateSetFromPercentage(size, (int)percentSize);
            SortedSet<int> problematicSetFail = problematicElements.CreateSetFromPercentage((int)percentSize, (int)percentSizeFail);
            ItemList item;
            int j = 0;
            for (int i = 1; i <= size; i++)
            {
                if (problematicSet.Contains(i))
                {
                    if (problematicSetFail.Contains(j))
                    {
                        item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomStringSpecialChar() };
                    }
                    else
                    {
                        item = new ItemList() { AnIndex = i, AString = "Time out" };
                        Thread.Sleep(2);
                    }
                    j += 1;
                    
                }
                else
                {
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() };
                }

                ExpectedString.StringWithNoSpecialChar(item);

                yield return item;
            }
        }
    }

}
