using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityMaster.AppCore
{
    class MoneyConversionExample
    {
        public MoneyConversionExample(decimal amount)
        {
            Amount = amount;
        }
        public decimal Amount { get; set; }

        public static implicit operator decimal(MoneyConversionExample m)
        {
            return m.Amount;
        }

        public static explicit operator int(MoneyConversionExample m)
        {
            return (int)m.Amount;
        }
    }
}
