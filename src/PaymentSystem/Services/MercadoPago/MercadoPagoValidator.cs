using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.MercadoPago
{
    public class MercadoPagoValidator : IValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("MercadoPago: Validando cartão...");
            return cardNumber.Length == 16 && cardNumber.StartsWith("5");
        }
    }
}