using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Generators
{

    //RandomUtil: random string generator
    public class RandomUtil
    {
        /// <summary>
        /// https://www.dotnetperls.com/random-string
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public string GetRandomString(int size, int slowSize, int failureSize, int flag)
        {
            var slowStringGenerator = CreateSetFromPercentage(size, slowSize);
            var failureStringGenerator = CreateSetFromPercentage(size, failureSize);

            if (slowStringGenerator.Contains(flag))
            {
                //Slow the selected random item
                Thread.Sleep(1);
                return GenerateRandomString();
            }
            else if (failureStringGenerator.Contains(flag))
            {
                //Manage failures UNDER PROCESS !!!!!!!!!!!!!
                return GenerateRandomString();
            }
            else
            {
                //Return strings without failures and slowness  
                return GenerateRandomString();
            }
        }

        private string GenerateRandomString()
        {
            string path = System.IO.Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }

        //Create set for failure/slow percentage
        private SortedSet<int> CreateSetFromPercentage(int size, int percentSize)
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