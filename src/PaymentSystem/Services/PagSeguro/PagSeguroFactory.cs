using PaymentSystem.Interfaces;

namespace PaymentSystem.Services.PagSeguro
{
    public class PagSeguroFactory : IPaymentGatewayFactory
    {
        public IValidator CreateValidator() => new PagSeguroValidator();
        public IProcessor CreateProcessor() => new PagSeguroProcessor();
        public ILogger CreateLogger() => new PagSeguroLogger();
    }
}
