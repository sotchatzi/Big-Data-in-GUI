using System;
using System.Collections.Generic;
using System.Text;

namespace Generators
{
    public class SpecialCharacterDetected: Exception
    {
        public SpecialCharacterDetected()
        {
        }
        public SpecialCharacterDetected(string message)
            : base(message)
        {
        }

        public SpecialCharacterDetected(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
