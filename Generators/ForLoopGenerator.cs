using System.Collections.Generic;

namespace Generators
{
    public class ForLoopGenerator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size, int slowSize, int failureSize)
        {
            var randomString = new RandomUtil();

            List<ItemList> items = new List<ItemList>();
            for (int i = 1; i <= size; i++)
            {
                items.Add(new ItemList() { AnIndex = i, AString = randomString.GetRandomString(size, slowSize, failureSize, i) });
            }
            return items;
        }
    }
}