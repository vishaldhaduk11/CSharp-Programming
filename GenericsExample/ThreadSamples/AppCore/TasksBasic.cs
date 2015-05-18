using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSamples.AppCore
{
    public class TasksBasic
    {
        #region Field
        #endregion

        #region Property
        #endregion

        #region Method

        /// <summary>
        /// This method indicates how to run task and wait untill it completes execution.
        /// </summary>
        internal static void CallRunTask()
        {
            Task t = Task.Run(() =>
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        Console.WriteLine("*");
                    }
                });

            t.Wait();
        }

        /// <summary>
        /// This method indicates how task can return the value to calling method.
        /// </summary>
        internal static void CallTaskReturnValue()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
                {
                    return i.Result * 2;
                });

            Console.WriteLine(t.Result);
        }

        /// <summary>
        /// This method indicates how ContinueWith works with the task in allocated scenarios.
        /// </summary>
        internal static void CallTaskContinueWith()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Falulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var taskContinue = t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            taskContinue.Wait();
            Console.WriteLine(t.Result);
        }

        /// <summary>
        /// This method attaches the child task to the parent task using wait method
        /// </summary>
        internal static void CallAttachChildTask()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var finalTask = parent.ContinueWith(
            parentTask =>
            {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });
            finalTask.Wait();
        }

        internal static void CallAttachChildWaitAll()
        {
            Task[] task = new Task[3];

            task[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            task[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            task[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(task);
        }
        #endregion
    }
}
