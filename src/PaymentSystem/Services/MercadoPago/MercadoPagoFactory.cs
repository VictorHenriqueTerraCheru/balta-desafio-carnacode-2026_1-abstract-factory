using PaymentSystem.Interfaces;

namespace PaymentSystem.Services.MercadoPago
{
    public class MercadoPagoFactory : IPaymentGatewayFactory
    {
        public IValidator CreateValidator() => new MercadoPagoValidator();
        public IProcessor CreateProcessor() => new MercadoPagoProcessor();
        public ILogger CreateLogger() => new MercadoPagoLogger();
    }
}
