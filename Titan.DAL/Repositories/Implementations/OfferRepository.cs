using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.DAL.Entities;
using Titan.DAL.Repositories.Contracts;

namespace Titan.DAL.Repositories.Implementations
{
    public class OfferRepository : IOfferRepository
    {
        public pitufoContext _context { get; set; }
        public OfferRepository(pitufoContext context)
        {
            this._context = context;

        }

        public Offer Create(Offer offer)
        {
            var u = _context.Offers.Add(offer);
            _context.SaveChanges();

            return u.Entity;
        }

        public bool Delete(int id)
        {
            var del = _context.Offers.Find(id);
            _context.Offers.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public bool Exist(Offer offer)
        {
            return _context.Offers.Any(u => u.Id == offer.Id);
        }


        public List<Offer> Obtain(int id)
        {
            return _context.Offers.Where(u => u.EmpresaId == id).ToList();
        }

        public List<Offer> ObtainAll()
        {
            return _context.Offers.ToList();
        }

        public Offer Update(Offer offer)
        {
            var update = _context.Offers.Update(offer);
            _context.SaveChanges();
            return update.Entity;
        }

        public List<Offer> Activas(DateTime date)
        {
            var lista = _context.Offers.Where(i => i.Fecha_Fin.CompareTo(date)>=0).ToList();
            return lista;
        }

        public List<Offer> SearchNombre(string nombre)
        {
            var lista = _context.Offers.Where(i => i.Nombre.Contains(nombre)).ToList();
            return lista;
        }
    }
}
