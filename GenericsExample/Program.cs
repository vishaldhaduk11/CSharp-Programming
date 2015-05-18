using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsExample.Generics;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicGenerics.NonGenericPerfromance();
            BasicGenerics.GenericPerfromance();
            CloseWindow();
        }
        
        private static void CloseWindow()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}   