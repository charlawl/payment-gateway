using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Libs;
using PaymentGateway.Libs.Infrastructure;
using PaymentGateway.Libs.Models;
using PaymentGateway.Libs.Services;

namespace PaymentGateway.Api.Controllers
{
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentService paymentService, IPaymentRepository paymentRepository)
        {
            _paymentService = paymentService;
            _paymentRepository = paymentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPayment([FromBody] MerchantPaymentRequest paymentRequest)
        {
            //Merchant request -> DB store request 

            /*
            await _paymentService.SubmitPaymentToBank(paymentRequest);
            */

            await _paymentRepository.Add(paymentRequest);

            return CreatedAtAction(nameof(GetPayment), new {id = paymentRequest.Id}, paymentRequest);
        }
        
        [HttpGet]
        public IActionResult GetPayment([FromRoute] Guid id)
        {

            var paymentItem = _paymentRepository.GetById(id);

            if (paymentItem == null)
            {
                return BadRequest();
            }

            return Ok(paymentItem);

        }
        
    }
}