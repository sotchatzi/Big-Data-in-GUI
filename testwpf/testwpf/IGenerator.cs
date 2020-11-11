using System.Collections.Generic;

namespace MultiThreaded_GUI
{
    public interface IGenerator
    {
        IEnumerable<ItemList> Generate(int size);
    }
}


