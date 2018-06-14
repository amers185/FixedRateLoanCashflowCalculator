using CashflowCalculator.Models;
using FixedRateCashflowCalculator.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FixedRateCashflowCalculator.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CashflowCalculatorController : ApiController
    {

        

        [HttpPost]
        public IHttpActionResult AddLoan([FromBody] Loan loanInput)
        {
            var id = SaveFunction.AddLoan(loanInput);
            if (0 < id)
                return Ok(id);
            else
                return BadRequest("Unable to save loan");
        }

        [HttpPost]
        public IHttpActionResult DeleteLoans([FromBody] List<int> loans)
        {
            var id = SaveFunction.DeleteLoans(loans);
            if (0 < id)
                return Ok(id);
            else
                return BadRequest("Unable delete loans");
        }

        [HttpGet]
        public IHttpActionResult GetLoans()
        {
            var loans = SaveFunction.GetLoans();
            if (loans == null)
            {
                return BadRequest("Unable to retrieve loans");
            }

            return Ok(loans);
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