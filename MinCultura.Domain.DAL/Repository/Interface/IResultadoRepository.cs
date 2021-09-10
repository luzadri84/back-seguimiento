using System;
using System.Collections.Generic;
using MinCultura.Domain.DAL;
namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IResultadoRepository<Resultado>
    {
        ICollection<Resultado> Get(int idVigencia, string depId, string munId, string proyecto, string proponente, string nroRadicacion);
    }
}
