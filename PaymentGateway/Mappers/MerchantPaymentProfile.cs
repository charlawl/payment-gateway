using AutoMapper;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Api.Mappers
{
    public class MerchantPaymentProfile : Profile
    {
        public MerchantPaymentProfile()
        {
            CreateMap<MerchantPayment, MerchantPaymentRequest>().ReverseMap();
            CreateMap<MerchantPayment, MerchantPaymentResponse>().ReverseMap();
        }
    }
}
