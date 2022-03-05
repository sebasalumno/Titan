using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;

namespace Titan.BL.Implementations
{
    public class PaymentBL : IPaymentBL
    {


        public string PagoSuccess(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public string PosiblePagoCancelacion(PaymentIntent paymentIntent)
        {
            throw new NotImplementedException();
        }

        public string SubscriptionCreated(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
