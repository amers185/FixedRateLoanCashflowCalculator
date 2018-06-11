using CashflowCalculator.Models;
using FixedRateCashflowCalculator.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FixedRateCashflowCalculator.API.Controllers
{
    public class CashflowCalculatorController : ApiController
    {
        Loan loan1 = new Loan { Amount = 4511, Duration = 12, Rate = 2.3M };
        Loan loan2 = new Loan { Amount = 1244, Duration = 6, Rate = 1.2M };
        Loan loan3 = new Loan { Amount = 45641, Duration = 12, Rate = 6.5M };

        [HttpPost]
        public IHttpActionResult AddLoan([FromBody] Loan loanInput)
        {
            var id = SaveFunction.AddLoan(loanInput);
            if (0 < id)
                return Ok(id);
            else
                return BadRequest("Unable to save loan");
        }

        [HttpGet]
        public IHttpActionResult GetCashflows()
        {
            var cashflows = CashflowComputation.GetCashFlows();
            if (cashflows == null)
            {
                return BadRequest("Unable to retrieve cashflows");
            }

            return Ok(cashflows);
        }

    }
}
