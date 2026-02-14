using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Interfaces
{
    public interface IProcessor { string ProcessTransaction(decimal amount, string cardNumber); }
}
