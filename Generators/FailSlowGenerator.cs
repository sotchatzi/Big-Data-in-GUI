﻿using System.Collections.Generic;
using System.Threading;

namespace Generators
{
    public class FailSlowGenerator : IGenerator
    {
        private int _failPercentage;
        private int _slowPercentage;

        public FailSlowGenerator(int failPercentage, int slowPercentage )
        {
            _failPercentage = failPercentage;
            _slowPercentage = slowPercentage;
        }

        public IEnumerable<ItemList> Generate(int size)
        {
            double percentSizeSlow = _slowPercentage * 0.01 * size;
            double percentSizeFail = _failPercentage * 0.01 * size;

            ProblematicElements problematicElements = new ProblematicElements();
            SortedSet<int> problematicSetSlow = problematicElements.CreateSetFromPercentage(size, (int)percentSizeSlow);
            SortedSet<int> problematicSetFail = problematicElements.CreateSetFromPercentage(size, (int)percentSizeFail);

            ItemList item;

            for (int i = 1; i <= size; i++)
            {
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
