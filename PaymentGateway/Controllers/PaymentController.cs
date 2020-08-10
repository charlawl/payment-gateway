using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PaymentGateway.Controllers
{
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public IActionResult MakePayment()
        {

            return NoContent();
        }
        
        [HttpGet]
        public IActionResult GetPayment()
        {
            
            return Ok("payment retrieved");
        }
        
    }
}