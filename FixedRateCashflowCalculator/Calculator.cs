using CashflowCalculator.Models;
using FixedRateCashflowCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashflowCalculator
{
    public class Calculator
    {
        private static decimal MonthlyPayment(decimal amount, int duration, decimal r) 
        {
            double numerator = Convert.ToDouble(amount * (r / 1200));
            double denominator = (1 - Math.Pow(Convert.ToDouble(1 + r / 1200), -duration));
            return Convert.ToDecimal(numerator / denominator);
        }
        private static decimal InterestCalc(decimal r, decimal remainBal)
        {
            decimal InterestPayment = remainBal * r / 1200;
            return InterestPayment;
        }
        private static decimal PrincipalPay(decimal MonthlyPay, decimal InterestPayment)
        {
            decimal PrincipalPay = MonthlyPay - InterestPayment;
            return PrincipalPay;
        }

        public static List<CashflowRow> CalculateCashflow(Loan loan)
        {
            List<CashflowRow> flowList = new List<CashflowRow>();
            
            decimal monthlyPay = MonthlyPayment(loan.Amount, loan.Duration, loan.Rate);
            Console.WriteLine(monthlyPay);          
            decimal RemainingBalance = loan.Amount;

            for (int month = 1; month <= loan.Duration; month++)
            {
                CashflowRow flowRow = new CashflowRow();

                flowRow.RemainingBalance = RemainingBalance;

                flowRow.Month = month;
                flowRow.InterestPayment = InterestCalc(loan.Rate, flowRow.RemainingBalance);
                flowRow.PrincipalPayment = PrincipalPay(monthlyPay, flowRow.InterestPayment);
                flowRow.RemainingBalance = flowRow.RemainingBalance - flowRow.PrincipalPayment;
                flowList.Add(flowRow);

                RemainingBalance = flowRow.RemainingBalance;
            }
            return flowList; 
        }
        public static Cashflow CalculateLoanCashflow(Loan loan)
        {
            Cashflow cashflow = new Cashflow();

            if (loan.Duration <= 0 || loan.Rate <= 0 || loan.Amount <= 0)
                throw new ArgumentOutOfRangeException("please ensure that none of your entered values are zero or less");

            decimal totalMonthlyPayment = (loan.Amount * (loan.Rate / 1200)) / ((decimal)(1 - (Math.Pow(((double)(1 + loan.Rate / 1200)), -loan.Duration))));
            decimal remainingBalance = loan.Amount;

            for (int month = 1; month <= loan.Duration; month++)
            {
                decimal interest = remainingBalance * (loan.Rate / 1200);
                decimal principal = totalMonthlyPayment - interest;
                remainingBalance = remainingBalance - principal;
                cashflow.MonthlyPayments.Add(new MonthlyPayment()
                {
                    Interest = interest,
                    Principal = principal,
                    RemainingBalance = remainingBalance,
                    month = month
                });
            }

            return cashflow;
        }

        public static Cashflow CalculatePoolCashflow(List<Cashflow> cashflows)
        {
            List<MonthlyPayment> pool = new List<MonthlyPayment>();
            foreach (var cashflow in cashflows)
            {
                int x = 0;
                foreach (var monthlyPayment in cashflow.MonthlyPayments)
                {
                    if (x >= pool.Count)
                    {
                        pool.Add(new MonthlyPayment()
                        {
                            Interest = monthlyPayment.Interest,
                            Principal = monthlyPayment.Principal,
                            RemainingBalance = monthlyPayment.RemainingBalance,
                            month = monthlyPayment.month
                        });

                    }
                    else
                    {
                        pool[x].Interest += monthlyPayment.Interest;
                        pool[x].Principal += monthlyPayment.Principal;
                        pool[x].RemainingBalance += monthlyPayment.RemainingBalance;
                    }
                    x++;
                }
            }
            return new Cashflow() { MonthlyPayments = pool };
        }

    }
}
