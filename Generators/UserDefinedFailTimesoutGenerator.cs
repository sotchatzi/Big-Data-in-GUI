using System;
using System.Collections.Generic;
using System.Threading;

namespace Generators
{
    public class UserDefinedFailTimesoutGenerator : IGenerator
    {
        private int _percentageFail;
        private int _percentageTimeout;

        public UserDefinedFailTimesoutGenerator(int percentageFail, int percentageTimeout)
        {
            _percentageFail = percentageFail;
            _percentageTimeout = percentageTimeout;
        }
        public IEnumerable<ItemList> Generate(int size)
        {
            double percentSize = ((_percentageTimeout + _percentageFail )/ 100) * size;
            double percentSizeFail = (_percentageFail / 100) * size;

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
                        item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomStringSpecialChar(), AFlag = 2 };
                    }
                    else
                    {
                        Thread.Sleep(1); // Make sure the time out process is slower than fail
                        item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomStringSpecialChar(), AFlag = 3 };
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
