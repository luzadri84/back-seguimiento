using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class ServicioRepository : IServicioRepository<Servicio>
    {
        protected readonly ConcertacionContext context = null;
        public ServicioRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public ICollection<Servicio> Get(int cuentaUsuarioId)
        {
            var servicios = context.Servicio.FromSqlRaw("EXECUTE Seguridad.ServicioMenu_Obtener @P_CuentaUsuarioId = {0}", cuentaUsuarioId).ToList();
            return servicios;
        }
    }
}
