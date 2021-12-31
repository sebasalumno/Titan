using System;
using System.Collections.Generic;
using System.Text;
using Titan.DAL.Entities;

namespace Titan.DAL.Repositories.Contracts
{
    public interface IInscripcionesRepository
    {
        Inscripciones Create(Inscripciones inscripcion);
        List<Inscripciones> GetAll();
        List<Inscripciones> SearchFamilias(string nombre);
        List<Inscripciones> SearchEmpresas(int id);
        

    }
}
