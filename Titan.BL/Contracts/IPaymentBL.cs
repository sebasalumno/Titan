
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.BL.Contracts
{
   public interface IPaymentBL
    {
        string PagoSuccess(Invoice invoice);
        string SubscriptionCreated(Subscription subscription);

        string PosiblePagoCancelacion(PaymentIntent paymentIntent);
    }
}
