﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator.DAL
{
    public class AssociatedOutput
    {
        public int Month { get; set; }

        public decimal InterestPayment { get; set; }

        public decimal PrincipalPayment { get; set; }

        public decimal RemainingBalance { get; set; }

        public ICollection<UserLoanInput> UserLoanInputs { get; set; }

    }
}