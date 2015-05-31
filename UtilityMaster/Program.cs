using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityMaster.AppCore;

namespace UtilityMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            CallMoneyTypeConversion();
            Console.ReadKey();
        }

        public static void CallMoneyTypeConversion()
        {
            MoneyConversionExample m = new MoneyConversionExample(30.5m);
            decimal d = m;
            int truncatedVAlue = (int)m;

            Console.WriteLine("Decimal :" + d);
            Console.WriteLine("Int :" + truncatedVAlue);

            
        }
    }
}
