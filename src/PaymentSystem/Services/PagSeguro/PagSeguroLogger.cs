using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.PagSeguro
{
    public class PagSeguroLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[PagSeguro Log] {DateTime.Now}: {message}");
        }
    }
}
