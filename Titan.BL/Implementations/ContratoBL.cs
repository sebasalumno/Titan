using AutoMapper;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.Core.DTO;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.BL.Implementations
{
    public class ContratoBL : IContratoBL
    {
        public IConfiguration Configuration { get; set; }
        public IMapper mapper { get; set; }

        public ILoginRepository empresaRepository { get; set; }
        public IContratoRepository contratoRepository { get; set; }
        public ContratoBL(IConfiguration Configuration, ILoginRepository empresaRepository, IMapper mapper)
        {
            this.Configuration = Configuration;
            this.empresaRepository = empresaRepository;
            this.mapper = mapper;
        }

        public async Task<ContratoDTO> Baja(int empresaId)
        {
            StripeConfiguration.ApiKey = Configuration["StripeSecretkey"];
            var empresa = empresaRepository.Obtain(empresaId);
            if (empresa != null)
            {
                var contrato = contratoRepository.Get(empresaId);
                

                if (contrato != null)
                {
                    
                    var service = new SubscriptionService();
                    service.Cancel(contrato.StripeId);
                }
                contratoRepository.Update(contrato);

                return mapper.Map<Contrato, ContratoDTO>(contratoRepository.Baja(empresaId));

            }

            return null;
        }

        public ContratoDTO Stripe(ContratoDTO contrato)
        {
            //PriceCreateOptions optionsPrice;
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
