using CashflowCalculator.Models;
using FixedRateCashflowCalculator.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator.DAL

{
    public class LoanContext : DbContext 
    {
        public LoanContext() : base("name=LoanContextString") { }
        

        

        public DbSet<Loan> Loans { get; set; }

      
    }
}
