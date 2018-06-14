using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator.Models
{
    public class Cashflow
    {
        public virtual List<MonthlyPayment> MonthlyPayments { get; set; }


        public Cashflow()
        {
            MonthlyPayments = new List<MonthlyPayment>();
        }

    }
}
