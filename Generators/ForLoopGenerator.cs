using System.Collections.Generic;

namespace Generators
{
    public class ForLoopGenerator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            List<ItemList> items = new List<ItemList>();
            for (int i = 1; i <= size; i++)
            {
                items.Add(new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() });
            }
            return items;
        }
    }
}