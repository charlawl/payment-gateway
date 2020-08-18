using AutoMapper;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Api.Mappers
{
    public class MerchantPaymentProfile : Profile
    {
        public MerchantPaymentProfile()
        {
            CreateMap<MerchantPaymentRequest, MerchantPayment>();

            CreateMap<MerchantPayment, MerchantPaymentResponse>()
                .IncludeMembers(s => s.PaymentMethod)
                .ForMember(x => x.Number, 
                    opt => opt.ConvertUsing(new CreditCardNumberFormatter(), src => src.PaymentMethod.Number));

            CreateMap<PaymentMethod, MerchantPaymentResponse>();

            CreateMap<BankResponse, MerchantPayment>();
            CreateMap<MerchantPayment, BankResponse>();
        }
    }
}
