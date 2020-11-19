using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Generators
{
    class Slow20PercentGenerator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size, int slowSize, int failureSize)
        {

            var randomString = new RandomUtil();

            for (int i = 0; i <= size; i++)
            {
                yield return new ItemList() { AnIndex = i+1, AString =  randomString.GetRandomString(size, slowSize, failureSize, i) };
            }
        }

    }
}
