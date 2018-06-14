using CashflowCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixedRateCashflowCalculator.Models;

namespace CashflowCalculator.DAL.Services
{
    public static class CashflowService
    {
        public static List<Cashflow> GetCashFlows()
        {
            try
            {
                using (var context = new FixedRateCashflowCalculator.DAL.LoanContext())
                {
                    var loans = context.Loans.ToList();
                    List<Cashflow> cashflows = new List<Cashflow>();
                    foreach (var loan in loans)
                    {
                        cashflows.Add(Calculator.CalculateLoanCashflow(loan));
                    }
                    cashflows.Add(Calculator.CalculatePoolCashflow(cashflows));
                    return cashflows;
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }
    }
}
