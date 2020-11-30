using Generators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerformanceTests
{
    public class PerformanceTests
    {
        static IEnumerable<TestCaseData> SizeAndGenerator()
        {
            foreach (var size in Sizes())
            {
                foreach (var generator in Generators())
                {
                    yield return new TestCaseData(size, generator);
                }
            }
        }
        static IEnumerable<int> Sizes()
        {
            yield return 1;
            yield return 10;
            yield return 100;
            //yield return 1000;
            //yield return 10000;
            //yield return 100000;
            //yield return 1000000;
            //yield return 10000000;
        }
        static IEnumerable<IGenerator> Generators()
        {
            yield return new ForLoopGenerator();
            yield return new YieldGenerator();
            yield return new SlowGenerator();
            yield return new Slow20Generator();
            yield return new Fail20Generator();
            yield return new Fail20Slow10Generator();
            yield return new Normal70Fail20Slow10();
            //MUST BE ADDED LATER
            //yield return new FailSlowGenerator
            //yield return new UserDefinedFailSlowGenerator
        }
        [TestCaseSource(nameof(SizeAndGenerator))]
        public void PerformanceMeasurement(int size, IGenerator generator)
        {
            ReportPerformance(size, generator);
        }
        private void ReportPerformance(int size, IGenerator generator)
        {
            // 2. start timers
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // 3. perform the action
            var result = generator.Generate(size).ToList(); // the ToList forces the enumeration of the collection - and this is what takes time
            // 4. measure the elapsed time
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            // 5. report
            Console.Out.WriteLine(ts.ToString()); // Instead, write to a file
        }
    }
}