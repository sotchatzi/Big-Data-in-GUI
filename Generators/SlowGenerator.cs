using System.Collections.Generic;
using System.Threading;

namespace Generators
{
    public class SlowGenerator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size, int slowSize, int failureSize)
        {
            var randomString = new RandomUtil();

            for (int i = 1; i <= size; i++)
            {
//                Thread.Sleep(1);
                yield return new ItemList() { AnIndex = i, AString = randomString.GetRandomString(size, slowSize, failureSize, i) };
            }
        }
    }
}
