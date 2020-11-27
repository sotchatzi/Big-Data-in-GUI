using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Generators
{
    public class Fail20Slow10Generator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            double percent20SizeFail = 0.2 * size;
            double percent10SizeSlow = 0.1 * size;

            ProblematicElements problematicElements = new ProblematicElements();
            SortedSet<int> problematicSetFail = problematicElements.CreateSetFromPercentage(size, (int)percent20SizeFail);
            SortedSet<int> problematicSetSlow = problematicElements.CreateSetFromPercentage(size, (int)percent10SizeSlow);

            ItemList item;

            for (int i = 1; i <= size; i++)
            {
                // The percentage of the elements that are both slow and fail is random, means we cannot test that
                if (problematicSetFail.Contains(i) && problematicSetSlow.Contains(i))
                {
                    Thread.Sleep(1);
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomStringSpecialChar(), AFlag = 3 };
                }
                else if (problematicSetFail.Contains(i))
                {
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomStringSpecialChar(), AFlag = 2 };
                }
                else if (problematicSetSlow.Contains(i))
                {
                    Thread.Sleep(1);
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString(), AFlag = 1 };
                }
                else
                {
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString(), AFlag = 0 };
                }

                ExpectedString.StringWithNoSpecialChar(item);

                yield return item;
            }
        }
    }

}
