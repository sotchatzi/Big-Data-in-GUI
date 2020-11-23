using System;
using System.Collections.Generic;
using System.Text;

namespace Generators
{
    public class ProblematicElements
    {
        //Create set for failure/slow percentage
        public SortedSet<int> CreateSetFromPercentage(int size, int percentSize)
        {
            Random rand = new Random();

            SortedSet<int> numbers = new SortedSet<int>();
            while (numbers.Count < percentSize)
            {
                numbers.Add(rand.Next(1, size));
            }

            return numbers;
        }
    }
}
