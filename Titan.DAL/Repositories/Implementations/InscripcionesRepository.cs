using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class InscripcionesRepository : IInscripcionesRepository
    {
        public pitufoContext _context { get; set; }
        public InscripcionesRepository(pitufoContext context)
        {
            this._context = context;

        }

        public Inscripciones Create(Inscripciones inscripcion)
        {
            var i = _context.Inscripciones.Add(inscripcion);
            _context.SaveChanges();
            return i.Entity;
        }

        public List<Inscripciones> GetAll()
        {
            return _context.Inscripciones.ToList();
        }

        public List<Inscripciones> SearchEmpresas(int id)
        {
            return _context.Inscripciones.Where(i => i.Oferta.offer.EmpresaId == id).ToList();
        }

        public List<Inscripciones> SearchFamilias(string nombre)
        {
            return _context.Inscripciones.Where(i => i.Oferta.ciclo.Familia.ToString().Contains(nombre)).ToList();
        }
    }
}
