using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.DAL.Repositories.Contracts;

namespace Titan.BL.Implementations
{
    public class ContratoBL : IContratoBL
    {
        public IConfiguration Configuration { get; set; }

        public ILoginRepository empresaRepository { get; set; }
        public ContratoBL(IConfiguration Configuration, ILoginRepository empresaRepository)
        {
            this.Configuration = Configuration;
            this.empresaRepository = empresaRepository;
        }

 /*       public async Task<ContratoDTO> Baja(int empresaId) {
            StripeConfiguration.ApiKey = Configuration["StripeSecretkey"];
            var empresa = empresaRepository.Obtain(empresaId);
            if (empresa != null)
            {
                var contrato = _ContratoRepository.Get(empresaId, true);
                contrato.ContratoEstadoID = _ContratoRepository.GetEstados().FirstorDefault(e => e.Codigo == "INACTIVO").Id;

                if (contrato != null)
                {
                    var service = new SubscriptionService();
                    service.Cancel(contrato.SubscriptionStripeId);
                }
                ContratoRepository.Update(contrato);

                return _mapper.Map<Contrato, ContratoDTO>(_ContratoRepository.Baja(empresaId));

            }
            
            return null;
        }*/

        private ContratoDTO Stripe(ContratoDTO contrato)
        {
            PriceCreateOptions optionsPrice;
            StripeConfiguration.ApiKey = Configuration["StripeSecretKey"];
            var empresa = empresaRepository.Obtain(contrato.EmpresaId);
            if (empresa.StripeId == null)
            {
                var optionsCustomer = new CustomerCreateOptions
                {
                    Email = empresa.Email
                };
                var ServiceCustomer = new CustomerService();
                var customer = ServiceCustomer.Create(optionsCustomer);
                empresa.StripeId = customer.Id;
                empresaRepository.Update(empresa);

            }
/*
            optionsPrice = new PriceCreateOptions
            {
                Product = Configuration["StripeProductId"],
                UnitAmount = (999),
                Currency = "eur",
                Recurring = new PriceRecurringOptions
                {
                    Interval = "month",
                },

            };
            var servicePrice = new PriceService();
            var price = servicePrice.Create(optionsPrice);
            contrato.StripeId = price.Id;
            //contrato.Empresa = mapper<>*/

            return contrato;
        }
    }
}
