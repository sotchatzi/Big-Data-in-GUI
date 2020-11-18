using System.Collections.Generic;

namespace Generators
{
    public interface IGenerator
    {
        IEnumerable<ItemList> Generate(int size);
    }
}