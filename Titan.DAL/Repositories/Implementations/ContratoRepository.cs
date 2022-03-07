using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    class ContratoRepository : IContratoRepository
    {

        public pitufoContext _context { get; set; }
        public ContratoRepository(pitufoContext context)
        {
            this._context = context;
        }
        public Contrato Get(int empresaid)
        {
            var con = _context.Contratos.FirstOrDefault(e => e.EmpresaId == empresaid);
            return con;
        }



        public void Update(Contrato contrato)
        {
            _context.Contratos.Update(contrato);
            _context.SaveChanges();
        }

        public Contrato Baja(int empresaid)
        {
            var b = _context.Contratos.FirstOrDefault(e => e.EmpresaId == empresaid);
            b.ContratoEstadoId = 2;
            _context.Update(b);
            return b;
        }


    }
}
