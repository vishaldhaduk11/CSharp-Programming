using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadSamples.AppCore;
namespace ThreadSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread Static
            ThreadBasic.CallThreadStatic();

            //Stopping thread
            //ThreadBasic.CallStopThread();

            //Parameterized thread example
            //ThreadBasic.CallParameterizedThread();

            //Background thread example
            //ThreadBasic.CallBackgroundThread();

            //Call ThreadArray
            //ThreadBasic.CreateThreadArray();

            // Call CallThreadJoin.
            //ThreadBasic.CallThreadJoin();

            Console.ReadKey();
        }
    }
}
