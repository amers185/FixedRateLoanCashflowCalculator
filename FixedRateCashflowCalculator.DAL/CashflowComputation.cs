using CashflowCalculator;
using CashflowCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator.DAL
{
    public class CashflowComputation
    {

        public static List<CashflowRow> GetCashFlows()
        {
            try
            {
                using (var context = new LoanContext())
                {
                    var loans = context.Loans.ToList();
                    List<List<CashflowRow>> fullList = new List<List<CashflowRow>>();
                    foreach (var loan in loans)
                    {
                        List<CashflowRow> flowList = Calculator.CalculateCashflow(loan);
                        fullList.Add(flowList);
                    }

                    int maxMonth = fullList.Max(x => x.Count);
                    List<CashflowRow> pool = new List<CashflowRow>();
                    for (var i = 0; i < maxMonth; ++i)
                    {
                        CashflowRow cashflowRow = new CashflowRow();
                        cashflowRow.Month = i + 1;
                        foreach (var cashflow in fullList)
                        {
                            int cashflowMonths = cashflow.Count;
                            cashflowRow.InterestPayment += cashflowMonths > i ? cashflow[i].InterestPayment : 0;
                            cashflowRow.PrincipalPayment += cashflowMonths > i ? cashflow[i].PrincipalPayment : 0;
                            cashflowRow.RemainingBalance += cashflowMonths > i ? cashflow[i].RemainingBalance : 0;
                        }
                        pool.Add(cashflowRow);
                    }
                    return pool;
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
