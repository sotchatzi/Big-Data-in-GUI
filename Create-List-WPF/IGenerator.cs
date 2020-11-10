using System.Collections.Generic;

namespace Create_List_WPF
{
    public interface IGenerator
    {
        IEnumerable<ItemList> Generate(int size);
    }
}