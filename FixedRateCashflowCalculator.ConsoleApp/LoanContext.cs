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

        public DbSet<UserLoanInput> UserLoanInputs { get; set; }

        public DbSet<AssociatedOutput> AssociatedOutputs { get; set; }
    }
}
