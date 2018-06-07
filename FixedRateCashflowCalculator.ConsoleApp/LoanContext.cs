using FixedRateCashflowCalculator.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator.ConsoleApp
{
    class LoanContext : DbContext 
    {
        public LoanContext() : base()
        {

        }

        public DbSet<UserLoanInput> LoanInputs { get; set; }

        public DbSet<AssociatedOutput> Grades { get; set; }
    }
}
