using System.Collections.Generic;
using System.Threading;

namespace Create_List_WPF
{
    public class SlowGenerator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                Thread.Sleep(1);
                yield return new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() };
            }
        }
    }
}