using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.PagSeguro
{
    public class PagSeguroProcessor : IProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"PagSeguro: Processando R$ {amount}...");
            return $"PAGSEG-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
}
