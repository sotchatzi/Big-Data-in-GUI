using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Generators
{
    public class Slow20Generator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            double percent20Size = 0.2 * size;

            ProblematicElements problematicElements= new ProblematicElements();
            SortedSet<int> problematicSet = problematicElements.CreateSetFromPercentage(size, (int)percent20Size);

            for (int i = 1; i <= size; i++)
            {
                if (problematicSet.Contains(i))
                    Thread.Sleep(1);

                yield return new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() };
            }
        }
    }
}
