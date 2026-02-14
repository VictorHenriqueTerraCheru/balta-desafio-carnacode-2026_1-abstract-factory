using PaymentSystem.Services.MercadoPago;
using PaymentSystem.Services.PagSeguro;
using PaymentSystem.Services.Stripe;
using System;

namespace PaymentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Pagamentos ===\n");

            var service = new PaymentService(new PagSeguroFactory());
            service.ProcessPayment(150.00m, "1234567890123456");

            Console.WriteLine();

            var mercadoPagoService = new PaymentService(new MercadoPagoFactory());
            mercadoPagoService.ProcessPayment(200.00m, "5234567890123456");

            Console.WriteLine();

            var stripeService = new PaymentService(new StripeFactory());
            stripeService.ProcessPayment(300.00m, "4234567890123456");

            Console.WriteLine();
        }
    }
}
