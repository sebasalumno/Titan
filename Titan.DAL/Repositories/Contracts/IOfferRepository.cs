﻿using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
    public interface IOfferRepository
    {

        Offer Create(Offer offer);
        Offer Obtain(Offer offer);
        List<Offer> ObtainAll();
        bool Delete(Offer offer);
        Offer Update(Offer offer);
        bool Exist(Offer u);
    }
}
