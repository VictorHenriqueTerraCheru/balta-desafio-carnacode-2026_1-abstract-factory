using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.Stripe
{
    public class StripeLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Stripe Log] {DateTime.Now}: {message}");
        }
    }
}
