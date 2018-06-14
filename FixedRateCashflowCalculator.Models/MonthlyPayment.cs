using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator.Models
{
    public class MonthlyPayment
    {
        public int month;
        public decimal Interest { get; set; }
        public decimal Principal { get; set; }
        public decimal RemainingBalance { get; set; }

        public MonthlyPayment() { }
    }
}
