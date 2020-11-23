using System;
using System.Collections.Generic;
using System.Text;

namespace Generators
{
    public interface IGeneratorSlowFail
    {
        IEnumerable<ItemList> Generate(int size, int percentageSlow, int percentageFail);
    }
}
