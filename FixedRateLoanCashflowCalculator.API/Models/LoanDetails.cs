﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixedRateLoanCashflowCalculator.API.Models
{
    public class LoanDetails
    {
        public int Id { get; set; }
        public int Duration { get; set; }

        public decimal Amount { get; set; }

        public decimal Rate { get; set; }
    }
}