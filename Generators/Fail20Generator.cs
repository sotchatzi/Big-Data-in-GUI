using System.Collections.Generic;
using System.Threading;

namespace Generators
{
    public class Fail20Generator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            double percent20Size = 0.2 * size;

            ProblematicElements problematicElements = new ProblematicElements();
            SortedSet<int> problematicSet = problematicElements.CreateSetFromPercentage(size, (int)percent20Size);
            ItemList item;

            for (int i = 1; i <= size; i++)
            {
                if (problematicSet.Contains(i))
                {
                    item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomStringSpecialChar() };
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
