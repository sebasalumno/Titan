using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class CicloRepository : ICicloRepository
    {
        public pitufoContext _context { get; set; }
        public CicloRepository(pitufoContext context)
        {
            this._context = context;

        }
        public List<Ciclo> GetAll()
        {
            return _context.Ciclos.ToList();
        }
    }
}
