using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class FamiliaRepository : IFamiliaRepository
    {
        public pitufoContext _context { get; set; }
        public FamiliaRepository(pitufoContext context)
        {
            this._context = context;

        }

        public List<Familia> GetAll()
        {
            var lista = _context.Familias.ToList();
            return lista;
        }
    }
}
