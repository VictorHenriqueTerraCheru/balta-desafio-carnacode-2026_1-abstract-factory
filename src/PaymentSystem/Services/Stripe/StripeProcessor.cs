using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.Stripe
{
    public class StripeProcessor : IProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"Stripe: Processando ${amount}...");
            return $"STRIPE-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
}
