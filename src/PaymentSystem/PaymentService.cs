using PaymentSystem.Interfaces;
using System;

namespace PaymentSystem
{
    public class PaymentService
    {
        private readonly IPaymentGatewayFactory _gateway;

        public PaymentService(IPaymentGatewayFactory gateway) => _gateway = gateway;

        public void ProcessPayment(decimal amount, string cardNumber)
        {
            var validador = _gateway.CreateValidator();
            if (!validador.ValidateCard(cardNumber))
            {
                Console.WriteLine($"{_gateway.GetType().Name.Replace("Factory", "")}: Cartão inválido");
                return;
            }
            var processor = _gateway.CreateProcessor();
            var logger = _gateway.CreateLogger();
            var result = processor.ProcessTransaction(amount, cardNumber);
            logger.Log($"Transação processada: {result}");
        }
    }
}
