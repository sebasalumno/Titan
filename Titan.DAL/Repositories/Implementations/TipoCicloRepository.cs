using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class TipoCicloRepository : ITipoCicloRepository
    {
        public pitufoContext _context { get; set; }
        public TipoCicloRepository(pitufoContext context)
        {
            this._context = context;

        }

        public List<TipoCiclo> GetAll()
        {
            return _context.TipoCiclos.ToList();
           
        }
    }
}
