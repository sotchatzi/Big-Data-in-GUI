using System.Collections.Generic;
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
            ItemList item;

            for (int i = 1; i <= size; i++)
            {
                if (problematicSet.Contains(i))
                {
                    Thread.Sleep(1);
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString(), AFlag = 1 };
                }
                else
                {
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString(), AFlag = 0 };
                }
                yield return item;
            }
        }
    }
}
