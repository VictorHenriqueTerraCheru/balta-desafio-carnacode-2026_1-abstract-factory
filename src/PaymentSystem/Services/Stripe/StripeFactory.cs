using PaymentSystem.Interfaces;

namespace PaymentSystem.Services.Stripe
{
    public class StripeFactory : IPaymentGatewayFactory
    {
        public IValidator CreateValidator() => new StripeValidator();
        public IProcessor CreateProcessor() => new StripeProcessor();
        public ILogger CreateLogger() => new StripeLogger();
    }
}
