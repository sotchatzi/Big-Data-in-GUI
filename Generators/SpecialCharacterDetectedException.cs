using System;
using System.Collections.Generic;
using System.Text;

namespace Generators
{
    public class SpecialCharacterDetectedException: Exception
    {
        public SpecialCharacterDetectedException()
        {
        }
        public SpecialCharacterDetectedException(string message)
            : base(message)
        {
        }

        public SpecialCharacterDetectedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
