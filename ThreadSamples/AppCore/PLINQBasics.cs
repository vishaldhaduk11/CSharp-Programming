using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSamples.AppCore
{
    class PLINQBasics
    {
        #region Method

        internal static void CallBasicQuery()
        {
            var numbers = Enumerable.Range(0, 100);

            var result = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential()
                .ToArray();

            foreach(int i in result.Take(10))
                Console.WriteLine(i);
        }

        #endregion
    }
}
