using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace MultiThreaded_GUI
{
    public class BadGenerator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            Random interval = new Random();
            for (int i = 0; i < size; i++)
            {
                Thread.Sleep(interval.Next(0, 2));
                yield return new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() };
            }

        }
    }
}
