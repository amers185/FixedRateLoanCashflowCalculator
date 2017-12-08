using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator
{
    class Calculator
    { 
        public double CalculateInterest(double AmountLoaned, double Rate, double NumberOfMonths, double IthMonth) {
        return IthMonth * (Rate / 1200);

    }
        public double CalculatePrincipal(double AmountLoaned, double Rate, double NumberOfMonths, double IthMonth) {
         
            return TotalMonthlyPayment(AmountLoaned, Rate, NumberOfMonths) - CalculateInterest(AmountLoaned, Rate, NumberOfMonths, IthMonth);
        }
        public double TotalMonthlyPayment(double AmountLoaned, double Rate, double NumberOfMonths)
        {
           double Base = (1 + (Rate / 1200));
          double Numerator = (AmountLoaned) * (Rate / 1200);
           return Numerator / (1 - Math.Pow(Base, (-NumberOfMonths)));
        }
  
    }
}
