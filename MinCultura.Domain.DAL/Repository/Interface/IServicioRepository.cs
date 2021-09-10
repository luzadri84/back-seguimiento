using System;
using System.Collections.Generic;
using MinCultura.Domain.DAL;
namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IServicioRepository<Servicio>
    {
        ICollection<Servicio> Get(int cuentaUsuarioId);
    }
}
