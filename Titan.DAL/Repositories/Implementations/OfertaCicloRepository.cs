using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class OfertaCicloRepository : IOfertaCicloRepository
    {
        public pitufoContext _context { get; set; }
        public OfertaCicloRepository(pitufoContext context)
        {
            this._context = context;

        }

        public List<OfferEmpresa> GetCiclo(int id)
        {
            var lista = _context.OfferEmpresas.Include(i => i.ciclo ).Where(i => i.OfferId == id).ToList();
            return lista;
        }
    }
}
