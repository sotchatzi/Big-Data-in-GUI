using System;
using System.Collections.Generic;
using System.Threading;

namespace Generators
{
    public class UserDefinedFailSlowGenerator : IGenerator
    {
        private int _percentageFail;
        private int _percentageTimeout;

        public UserDefinedFailSlowGenerator(int percentageFail, int percentageTimeout)
        {
            _percentageFail = percentageFail;
            _percentageTimeout = percentageTimeout;
        }
        public IEnumerable<ItemList> Generate(int size)
        {
            int total_percentage = _percentageTimeout + _percentageFail;
            double percentSize = total_percentage * 0.01 * size;
            double percentSizeFail = _percentageFail * 0.01 * size;

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

                ExpectedString.StringWithNoSpecialChar(item);

                yield return item;
            }
        }
    }

}