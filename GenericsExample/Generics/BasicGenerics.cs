using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample.Generics
{
    public class BasicGenerics
    {
        #region PerformanceExample
        public static void NonGenericPerfromance()
        {
            long operationTime = 0;
            ArrayList aryList = new ArrayList();
            Stopwatch stpWatch = new Stopwatch();
            stpWatch.Start();

            for (long i = 0; i < 1000000; i++)
            {
                aryList.Add(i);
            }
            operationTime = stpWatch.ElapsedMilliseconds;
            PrintMessage(operationTime.ToString());

            stpWatch.Restart();
            foreach (long i in aryList)
            {
                long value = i;
            }

            operationTime = stpWatch.ElapsedMilliseconds;
            PrintMessage(operationTime.ToString());
        }

        public static void GenericPerfromance()
        {
            PrintMessage("-------Generic Perfromance----------");

            long operationTime = 0;
            List<int> aryList = new List<int>();
            Stopwatch stpWatch = new Stopwatch();
            stpWatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                aryList.Add(i);
            }
            operationTime = stpWatch.ElapsedMilliseconds;
            PrintMessage(operationTime.ToString());

            stpWatch.Restart();
            foreach (int i in aryList)
            {
                int value = i;
            }

            operationTime = stpWatch.ElapsedMilliseconds;
            PrintMessage(operationTime.ToString());

        }

        private static void PerformBasicGenerics()
        {
            ArrayList aryList = new ArrayList();
            aryList.Add(5);
            aryList.Add(10);
            aryList.Add(15.5);
            aryList.Add(20);

            int result = 0;
            foreach (int value in aryList)
            {
                result += value;
            }
            PrintMessage(result.ToString());
        }

        private static void PerformTypeSafety()
        {
            List<int> listItems = new List<int>();
            listItems.Add(5);
            listItems.Add(10);
            listItems.Add(15);
            listItems.Add(20);

            int result = 0;
            foreach (int value in listItems)
            {
                result += value;
            }
            PrintMessage(result.ToString());
        }

        private static void PrintMessage(string result)
        {
            Console.WriteLine("Result :" + result);
        }
        #endregion
    }
}
