// DESAFIO: Sistema de Pagamentos Multi-Gateway
// PROBLEMA: Uma plataforma de e-commerce precisa integrar com múltiplos gateways de pagamento
// (PagSeguro, MercadoPago, Stripe) e cada gateway tem componentes específicos (Processador, Validador, Logger)
// O código atual está muito acoplado e dificulta a adição de novos gateways

using System;
using static DesignPatternChallenge.PaymentService;

namespace DesignPatternChallenge
{
    // Contexto: Sistema de pagamentos que precisa trabalhar com diferentes gateways
    // Cada gateway tem sua própria forma de processar, validar e logar transações

    public class PaymentService
    {
        private readonly IPaymentGatewayFactory _gateway;

        public PaymentService(IPaymentGatewayFactory gateway) => _gateway = gateway;

        public interface IValidator { bool ValidateCard(string cardNumber); }
        public interface IProcessor { string ProcessTransaction(decimal amount, string cardNumber); }
        public interface ILogger { void Log(string message); }

        public interface IPaymentGatewayFactory
        {
            IValidator CreateValidator();
            IProcessor CreateProcessor();
            ILogger CreateLogger();
        }

        public class PagSeguroFactory : IPaymentGatewayFactory
        {
            public IValidator CreateValidator() => new PagSeguroValidator();
            public IProcessor CreateProcessor() => new PagSeguroProcessor();
            public ILogger CreateLogger() => new PagSeguroLogger();
        }

        public class MercadoPagoFactory : IPaymentGatewayFactory
        {
            public IValidator CreateValidator() => new MercadoPagoValidator();
            public IProcessor CreateProcessor() => new MercadoPagoProcessor();
            public ILogger CreateLogger() => new MercadoPagoLogger();
        }

        public class StripeFactory : IPaymentGatewayFactory
        {
            public IValidator CreateValidator() => new StripeValidator();
            public IProcessor CreateProcessor() => new StripeProcessor();
            public ILogger CreateLogger() => new StripeLogger();
        }

        public void ProcessPayment(decimal amount, string cardNumber)
        {
            // Problema: Switch case gigante para cada gateway
            // Quando adicionar novo gateway, precisa modificar este método
            var validador = _gateway.CreateValidator();
            var processor = _gateway.CreateProcessor();
            var logger = _gateway.CreateLogger();
            if (!validador.ValidateCard(cardNumber))
            {
                Console.WriteLine($"{_gateway.GetType().Name.Replace("Factory", "")}: Cartão inválido");
                return;
            }
            var result = processor.ProcessTransaction(amount, cardNumber);
            logger.Log($"Transação processada: {result}");
        }
    }

    #region Componentes do PagSeguro
    public class PagSeguroValidator : IValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("PagSeguro: Validando cartão...");
            return cardNumber.Length == 16;
        }
    }
    public class PagSeguroProcessor : IProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"PagSeguro: Processando R$ {amount}...");
            return $"PAGSEG-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
    public class PagSeguroLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[PagSeguro Log] {DateTime.Now}: {message}");
        }
    }
    #endregion

    #region Componentes do MercadoPago
    public class MercadoPagoValidator : IValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("MercadoPago: Validando cartão...");
            return cardNumber.Length == 16 && cardNumber.StartsWith("5");
        }
    }
    public class MercadoPagoProcessor : IProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"MercadoPago: Processando R$ {amount}...");
            return $"MP-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
    public class MercadoPagoLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[MercadoPago Log] {DateTime.Now}: {message}");
        }
    }
    #endregion

    #region Componentes do Stripe
    public class StripeValidator : IValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("Stripe: Validando cartão...");
            return cardNumber.Length == 16 && cardNumber.StartsWith("4");
        }
    }
    public class StripeProcessor : IProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"Stripe: Processando ${amount}...");
            return $"STRIPE-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
    public class StripeLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Stripe Log] {DateTime.Now}: {message}");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Pagamentos ===\n");

            // Problema: Cliente precisa saber qual gateway está usando
            // e o código de processamento está todo acoplado

            var service = new PaymentService(new PaymentService.PagSeguroFactory());
            service.ProcessPayment(150.00m, "1234567890123456");

            Console.WriteLine();

            var mercadoPagoService = new PaymentService(new PaymentService.MercadoPagoFactory());
            mercadoPagoService.ProcessPayment(200.00m, "5234567890123456");

            Console.WriteLine();

            // Pergunta para reflexão:
            // - Como adicionar um novo gateway sem modificar PaymentService?
            // - Como garantir que todos os componentes de um gateway sejam compatíveis entre si?
            // - Como evitar criar componentes de gateways diferentes acidentalmente?
        }
    }
}