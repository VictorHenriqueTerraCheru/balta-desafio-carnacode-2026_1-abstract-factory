using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.MercadoPago
{
    public class MercadoPagoProcessor : IProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"MercadoPago: Processando R$ {amount}...");
            return $"MP-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
}
