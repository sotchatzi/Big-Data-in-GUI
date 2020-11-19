using System.Collections.Generic;

namespace Generators
{
    public class YieldGenerator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size, int slowSize, int failureSize)
        {
            var randomString = new RandomUtil();

            for (int i = 1; i <= size; i++)
            {
                yield return new ItemList() { AnIndex = i, AString = randomString.GetRandomString(size, slowSize, failureSize, i) };
            }
        }
    }
}