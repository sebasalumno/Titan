using AutoMapper;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;
using Titan.DAL.Repositories.Contracts;

namespace Titan.BL.Implementations
{
    public class PaymentBL : IPaymentBL
    {
        public IConfiguration Configuration { get; set; }
        public ILoginRepository loginRepository { get; set; }
        public IContratoRepository contratoRepository { get; set; }

        public IMapper mapper { get; set; }
        public PaymentBL(ILoginRepository loginRepository, IMapper mapper, IConfiguration Configuration, IContratoRepository contratoRepository)
        {
            this.Configuration = Configuration;
            this.loginRepository = loginRepository;
            this.mapper = mapper;
            this.contratoRepository = contratoRepository;

        }


        public string PagoSuccess(Invoice invoice)
        {
            return loginRepository.PagoSuccess(invoice);
        }

        public string PosiblePagoCancelacion(PaymentIntent paymentIntent)
        {


            return loginRepository.PosiblePagoCancelacion(paymentIntent);
        }

        public string SubscriptionCreated(Subscription subscription)
        {
            StripeConfiguration.ApiKey = Configuration["StripeSecretkey"];
            var empresa = loginRepository.Get(subscription.CustomerId);
            if (empresa != null)
            {
                var contrato = contratoRepository.Get(empresa.Id);


                if (contrato != null)
                {

                    var options = new SubscriptionCreateOptions
                    {
                        Customer = subscription.Customer.ToString(),
                        Items = new List<SubscriptionItemOptions>
                        {
                            new SubscriptionItemOptions
                            {
                                Price = Configuration["price_1KZHVUDeoKxXT0FVZ1RFcWnG"],
                            },
                        },

                    };
                    var service = new SubscriptionService();
                    service.Create(options);


                }
                return "all doned";

            }

            return "no existe el stripeid";
        }
    }
}
