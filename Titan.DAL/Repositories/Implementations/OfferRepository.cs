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

        public bool Delete(Offer offer)
        {
            _context.Offers.Remove(offer);
            _context.SaveChanges();
            return true;
        }

        public bool Exist(Offer offer)
        {
            return _context.Offers.Any(u => u.Id == offer.Id);
        }


        public Offer Obtain(Offer offer)
        {
            return _context.Offers.FirstOrDefault(e => e.Id == offer.Id);
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
    }
}
