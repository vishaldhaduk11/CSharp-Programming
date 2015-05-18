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
            PLINQOperations();
            Console.ReadKey();
        }

        public static void PLINQOperations()
        {
            //PLINQ basics
            PLINQBasics.CallBasicQuery();
        }

        /// <summary>
        /// Tasks basic operations
        /// </summary>
        public static void TaskOperation()
        {
            //Attaching child task with waitall method
            //TasksBasic.CallAttachChildWaitAll();

            //Attaching child task to parents
            //TasksBasic.CallAttachChildTask();

            //Tasks that runs on continue with
            //TasksBasic.CallTaskContinueWith();

            //Task that return a value
            //TasksBasic.CallTaskReturnValue();

            //Run task
            //TasksBasic.CallRunTask();
        }

        /// <summary>
        /// Thread basic opertions
        /// </summary>
        public static void ThreadOperations()
        {
            //Thread Local
            //ThreadBasic.CallThreadLocal();

            //Thread Static
            //ThreadBasic.CallThreadStatic();

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
        }
    }
}
