using System;
using System.Collections.Generic;
using System.Text;

namespace Generators
{
    class ExpectedString
    {
        public static void StringWithNoSpecialChar(ItemList item)
        {
            try
            {
                foreach (char j in RandomUtil.SpecialChar())
                    if (item.AString.Contains(j))
                        throw new SpecialCharacterDetectedException("String must contain only latin characters and numbers");
            }
            catch
            {
                item.AString = "InvalidString";
            }
        }


    }
}
