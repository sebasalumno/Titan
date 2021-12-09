using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        public pitufoContext _context { get; set; }
        public ProvinciaRepository(pitufoContext context)
        {
            this._context = context;

        }

        public Provincia Get(int id)
        {
            return _context.Provincias.FirstOrDefault(e => e.Id == id);
        }

        public List<Provincia> GetAll()
        {
            return _context.Provincias.ToList();
        }

        public List<Provincia> Filter(Provincia criteria)
        {

            return _context.Provincias.Where(p => p.Nombre.Contains(criteria.Nombre)).ToList();
        }
    }
}
