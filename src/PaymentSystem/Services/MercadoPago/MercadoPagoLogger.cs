using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.MercadoPago
{
    public class MercadoPagoLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[MercadoPago Log] {DateTime.Now}: {message}");
        }
    }
}
