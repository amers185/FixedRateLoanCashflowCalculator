using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator.DAL
{
    public class UserLoanInput
    {
        public int Duration { get; set; }

        public decimal Amount { get; set; }

        public decimal Rate { get; set; }

        public AssociatedOutput AssociatedOutput { get; set; }
    }
}
