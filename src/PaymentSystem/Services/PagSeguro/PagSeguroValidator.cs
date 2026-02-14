using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem.Services.PagSeguro
{
    public class PagSeguroValidator : IValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("PagSeguro: Validando cartão...");
            return cardNumber.Length == 16;
        }
    }
}
