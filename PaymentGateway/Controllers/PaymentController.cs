using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Libs.Infrastructure;
using PaymentGateway.Libs.Models;
using PaymentGateway.Libs.Services;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Controllers
{
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IPaymentPublisher _paymentPublisher;
        //ToDo - add seriLog for simple application logging

        public PaymentController(IPaymentRepository paymentRepository, IMapper mapper, IPaymentPublisher paymentPublisher)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _paymentPublisher = paymentPublisher;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPayment([FromBody] MerchantPaymentRequest paymentRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //log - bad request
            }

            var payment = _mapper.Map<MerchantPayment>(paymentRequest);

            await _paymentRepository.Add(payment);
            //log payment added to db with {id}

            _paymentPublisher.PublishPaymentSubmitted(payment);
            //log payment submitted to bank with {id}

            return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, _mapper.Map<MerchantPaymentResponse>(payment));
        }

        [HttpGet]
        public async Task<IActionResult> GetPayment([FromRoute] Guid id)
        {
            var payment = await _paymentRepository.GetById(id);
            

            var paymentResponse = _mapper.Map<MerchantPaymentResponse>(payment);

            if (paymentResponse == null)
            {
                return NotFound();
                //log payment not found
            }

            return Ok(paymentResponse);
        }
    }
}