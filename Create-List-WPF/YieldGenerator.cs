using System.Collections.Generic;

namespace Create_List_WPF
{
    public class YieldGenerator : IGenerator
    {
        public IEnumerable<ItemList> Generate(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                yield return new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() };
            }
        }
    }
}