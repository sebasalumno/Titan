using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SusripcionesController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> CrearPago(ContratoDTO contratoDTO)
        {
            var options = new SessionCreateOptions
            {
                SuccessUrl = "success.html?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "/failure.html",
                PaymentMethodTypes = new List<string>
                  {
                    "card",
                  },
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
                  {
                    new SessionLineItemOptions
                    {
                      Price = contratoDTO.StripeId, //Tu priceID
                      // For metered billing, do not pass quantity
                      Quantity = 1,
                    },
                  },
                Customer = contratoDTO.Empresa.StripeId,
                SubscriptionData = new SessionSubscriptionDataOptions
                {
                    TrialEnd = DateTimeOffset.FromUnixTimeSeconds(long.Parse(Configuration["TrialLimitTimeStamp"])).UtcDateTime, //Esto es si queréis ponerles un tiempo de prueba         
                }
            };

            //Días sin poder registrar el TRIAL, le restamos 120 segundos para que no coincida con justo el límite
            if (DateTime.Now > DateTimeOffset.FromUnixTimeSeconds(long.Parse(Configuration["TrialLimitTimeStamp"]) - 120).UtcDateTime.AddDays(-2))
            {
                options.SubscriptionData = null;
            }

            var service = new SessionService();
            var session = service.Create(options);
            return Ok(new PaymentDTO { Url = session.Url });
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Webhook")]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ParseEvent(json);

                if (stripeEvent.Type == Events.InvoicePaid)
                {
                    var invoice = stripeEvent.Data.Object as Invoice;
                    paymentBL.PagoSuccess(invoice);
                }
                else if (stripeEvent.Type == Events.CustomerSubscriptionCreated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    paymentBL.SubscriptionCreated(subscription);
                }
                else if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    paymentBL.PosiblePagoCancelacion(paymentIntent);
                }
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}
