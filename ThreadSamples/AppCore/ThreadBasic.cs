using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreadSamples.AppCore
{
    class ThreadBasic
    {
        #region Fields
        [ThreadStatic]
        public static int filed;
        #endregion

        #region WorkerThreads
        /// <summary>
        /// It simply print the integer from 0 to 10
        /// </summary>
        public static void PrintIntegers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        /// <summary>
        /// thread sleeps for 10 sec.
        /// </summary>
        public static void ThreadSleep()
        {
            Thread.Sleep(1000);
        }

        /// <summary>
        /// example of background thread
        /// </summary>
        public static void WorkerBackgoundThread()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Thread Proc {0}", i);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Example of parameterized thread
        /// </summary>
        private static void WorkerParameterizedThread(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("Thread Proc {0}", i);
                Thread.Sleep(0);
            }
        }

        /// <summary>
        ///Stopping thread
        /// </summary>
        private static void WorkerStopThread(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("Thread Proc {0}", i);
                Thread.Sleep(0);
            }
        }
        #endregion

        #region CallingThreads
        /// <summary>
        /// Call the thread named t to print the integers.
        /// later it will be joined with thread t. 
        /// </summary>
        public static void CallThreadJoin()
        {
            Thread t = new Thread(new ThreadStart(PrintIntegers));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }
            t.Join();
        }

        /// <summary>
        /// Example of thread array
        /// </summary>
        public static void CreateThreadArray()
        {
            var stopwatch = Stopwatch.StartNew();

            Thread[] threadArray = new Thread[4];

            for (int i = 0; i < threadArray.Length; i++)
            {
                threadArray[i] = new Thread(new ThreadStart(ThreadSleep));
                threadArray[i].Start();
            }

            for (int i = 0; i < threadArray.Length; i++)
            {
                threadArray[i].Join();
            }

            Console.WriteLine("Time elapsed : " + stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// This method is an example of background thread.
        /// IsBackgrund property is set to true.
        /// By setting value to false, makes it a foregound thread.
        /// </summary>
        public static void CallBackgroundThread()
        {
            Thread t = new Thread(new ThreadStart(WorkerBackgoundThread));
            t.IsBackground = false;
            t.Start();
        }

        /// <summary>
        /// Example of parameterized thread
        /// </summary>
        public static void CallParameterizedThread()
        {
            Thread t = new Thread(new ParameterizedThreadStart(WorkerParameterizedThread));
            t.Start(5);
            t.Join();
        }

        internal static void CallStopThread()
        {
            bool isStopped = false;

            Thread t = new Thread(new ThreadStart(() =>
                {
                    while (!isStopped)
                    {
                        Console.WriteLine("Running...");
                        Thread.Sleep(1000);
                    }
                }));

            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            isStopped = true;
            t.Join();
        }

        internal static void CallThreadStatic()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 4; i++)
                {
                    filed++;
                    Console.WriteLine("Thread 1 {0}", filed);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 4; i++)
                {
                    filed++;
                    Console.WriteLine("Thread 2 {0}", filed);
                }
            }).Start();

        }

        #endregion
    }
}
