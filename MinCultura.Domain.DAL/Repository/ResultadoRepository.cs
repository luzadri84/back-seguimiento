using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class ResultadoRepository : IResultadoRepository<Resultado>
    {
        protected readonly ConcertacionContext context = null;
        public ResultadoRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public ICollection<Resultado> Get(int idVigencia, string depId, string munId, string proyecto, string proponente, string nroRadicacion)
        {
            var resultado = context.Resultados.FromSqlRaw("EXECUTE PAS_REPORTE_RESULTADOS @depId= {0}, @munId =  {1}, @proyecto = {2}, @proponente = {3}, @nroRadicacion = {4}, @idVigencia = {5}", depId,  munId,  proyecto,  proponente,  nroRadicacion, idVigencia).ToList();
            return resultado;
        }
    }
}
