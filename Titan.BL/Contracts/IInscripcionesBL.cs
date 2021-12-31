using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IInscripcionesBL
    {
        InscripcionesDTO Create(InscripcionesDTO Inscripcion);
        List<InscripcionesDTO> SearchFamilias(string Familia);
        List<InscripcionesDTO> SearchEmpresas(int id);
        List<InscripcionesDTO> GetAll();
    }
}
