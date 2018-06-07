using CashflowCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator.DAL
{
    public class SaveFunction
    {
        public static int AddLoan(Loan loan)
        {
            try
            {
                using (var context = new LoanContext())
                {
                    context.Loans.Add(loan);
                    context.SaveChanges();
                    return loan.Id;
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return -1;
            }
        }

    }

}
