﻿using System.Text.RegularExpressions;
using AutoMapper;

namespace PaymentGateway.Api.Mappers
{
    public class CreditCardNumberFormatter : IValueConverter<string, string>
    {
        public string Convert(string source, ResolutionContext context)
        {
            var rgx = new Regex(@"^\d{12}");
            return rgx.Replace(source, "XXXXXXXXXXXX"); //not ideal...
        } 
    }
}
