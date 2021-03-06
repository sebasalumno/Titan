using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
   public class LoginRepository : ILoginRepository
    {

        public pitufoContext _context { get; set; }
        public LoginRepository(pitufoContext context)
        {
            this._context = context;

        }

        public Empresa Login(Empresa empresa)
        {
            
            var e = _context.Empresas.FirstOrDefault(u => u.Email == empresa.Email && u.Password == empresa.Password);
            if(e != null)
            {
            if (e.Confirmado == true)
            {
                return e;
            }
            else
            {
                return null;
            }
            }
            else
            {
                return e;
            }


           

        }

        public Empresa GetId(Empresa empresa)
        {
            var ids = _context.Empresas.FirstOrDefault(u => u.Email == empresa.Email);
            if(ids != null)
            {
                return ids;
            }
            else
            {
                return null;
            }
        }

        public Empresa Create(Empresa empresa,int codigo)
        {
            empresa.Confirmado = false;
            empresa.RolId = 1;
            
            var u = _context.Empresas.Add(empresa);
            _context.SaveChanges();

            ConfirmacionE conf = new ConfirmacionE
            {
                IdEmpresa = empresa.Id,
                Codigo = codigo
            };

            _context.ConfirmacionesE.Add(conf);

            _context.SaveChanges();
            return u.Entity;
        }
        /*
         * Este metodo comprueba que si existe una empresa en la base de datos
         */
        public bool Exist(Empresa empresa)
        {
            return _context.Empresas.Any(u => u.Email == empresa.Email );
        }

        public Empresa Obtain(int id)
        {
            return _context.Empresas.Include(u => u.Provincia).FirstOrDefault(e => e.Id == id);
        }

        public List<Empresa> ObtainAll()
        {
            return _context.Empresas.ToList();
        }

        public bool Delete(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            _context.SaveChanges();
            return true;
            
        }

        public Empresa Update(Empresa empresa)
        {
            var update = _context.Empresas.Update(empresa);
            _context.SaveChanges();
            return update.Entity;

        }

        public Usuario Send(int id)
        {
            var a = _context.Usuarios.FirstOrDefault(i => i.Id == id);
            if (a !=null)
            {
                return a;
            }
            else
            {
                return null;
            }
        }

        public bool Confirmar(string email, int codigo)
        {
            var u = _context.ConfirmacionesE.FirstOrDefault(c => c.Empresa.Email.Equals(email) && c.Codigo == codigo);

            if (u != null && u.Codigo !=0)
            {
                var us = _context.Empresas.FirstOrDefault(user => user.Id == u.IdEmpresa);

                us.Confirmado = true;
                u.Codigo = 0;
                _context.Empresas.Update(us);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }

        public Empresa Iniciar(int id, int codigo)
        {
            var u = _context.ConfirmacionesE.FirstOrDefault(c => c.IdEmpresa == id);

            if (u != null)
            {
                u.Codigo = codigo;
                _context.ConfirmacionesE.Update(u);
                var e = _context.Empresas.FirstOrDefault(d => d.Id == id);
                _context.SaveChanges();
                return e;
            }
            else
            {
                return null;
            }


        }

        public bool Cambiar(string password, int codigo)
        {
            var u = _context.ConfirmacionesE.FirstOrDefault(c => c.Codigo == codigo);
            if(u != null && u.Codigo != 0)
            {
                var emp = _context.Empresas.FirstOrDefault(e => e.Id == u.IdEmpresa);
                emp.Password = password;
                _context.Empresas.Update(emp);
                u.Codigo = 0;
                _context.ConfirmacionesE.Update(u);

                _context.SaveChanges();
                return true;
                
            }
            else { 

            return false; 


                 }
        }

        public string PagoSuccess(Invoice invoice)
        {
            var empresa = _context.Empresas.FirstOrDefault(e => e.StripeId.Equals(invoice.CustomerId));

            Contrato con = new Contrato
            {
                EmpresaId = empresa.Id,
                FechaAlta = DateTime.Now,
                FechaBaja = DateTime.Now.AddDays(30),
                ContratoEstadoId = 1,
                StripeId = invoice.CustomerId

            };
            _context.Contratos.Add(con);
            _context.SaveChanges();
            Factura fac = new Factura
            {
                FechaCreacion = DateTime.Now,
                FechaPago = DateTime.Now,
                EmpresaId = empresa.Id,
                StripePriceId = "price_1KZHVUDeoKxXT0FVZ1RFcWnG",
                ContratoId = con.Id,
            };
            _context.Facturas.Add(fac);
            _context.SaveChanges();
            empresa.RolId = 2;
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
            return "Se ha realizado la compra de manera correcta";
            
        }

        public Empresa Get(String stripeId)
        {
            var empresa = _context.Empresas.FirstOrDefault(p => p.StripeId == stripeId);
            return empresa;
        }

        public string PosiblePagoCancelacion(PaymentIntent paymentIntent)
        {
            var empresa = _context.Empresas.FirstOrDefault(e => e.StripeId.Equals(paymentIntent.CustomerId));

            Contrato con = new Contrato
            {
                EmpresaId = empresa.Id,
                FechaAlta = DateTime.Now,
                FechaBaja = DateTime.Now.AddDays(30),
                ContratoEstadoId = 1,
                StripeId = paymentIntent.CustomerId

            };
            _context.Contratos.Add(con);
            _context.SaveChanges();
            Factura fac = new Factura
            {
                FechaCreacion = DateTime.Now,
                FechaPago = DateTime.Now,
                EmpresaId = empresa.Id,
                StripePriceId = "price_1KZHVUDeoKxXT0FVZ1RFcWnG",
                ContratoId = con.Id,
            };
            _context.Facturas.Add(fac);
            _context.SaveChanges();
            empresa.RolId = 3;
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
            return "Se esta procesando";
        }


    }
}
