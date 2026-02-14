using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Interfaces
{
    public interface IPaymentGatewayFactory
    {
        IValidator CreateValidator();
        IProcessor CreateProcessor();
        ILogger CreateLogger();
    }
}
