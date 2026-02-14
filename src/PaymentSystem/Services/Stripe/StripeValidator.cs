using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.Stripe
{
    public class StripeValidator : IValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("Stripe: Validando cartão...");
            return cardNumber.Length == 16 && cardNumber.StartsWith("4");
        }
    }
}
