using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.BL.MappingProfiles;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository;
using MinCultura.Domain.DAL.Repository.Base;
using System;
using System.Collections.ObjectModel;

namespace MinCultura.Domain.BL
{
    public class EnvioCorreosBL : IEnvioCorreoBL
    {

        // <summary>
        /// Contexto de trabajo
        /// </summary>
        private readonly ConcertacionContext context;
        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        public EnvioCorreosBL(ConcertacionContext context)
        {
            this.context = context;

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddProfile<ConfigAutoMapper>();
            });

            _mapper = new Mapper(mapConfig);
        }

        /// <summary>
        /// Obtener correos pendientes de envíar
        /// </summary>
        /// <returns></returns>
        public Collection<EnvioCorreosDto> GetCorreosPendientes()
        {
            BaseRepository<EnvioCorreos> envioCorreosRepository = new EnvioCorreosRepository(context);
            var correosPendientes = envioCorreosRepository.Get(p => !p.Enviado);
            var list = _mapper.Map<Collection<EnvioCorreosDto>>(correosPendientes);
            return list;
        }

        /// <summary>
        /// Actualizar la entidad envio de correos
        /// </summary>
        /// <param name="envioCorreosDto"></param>
        public void Update(EnvioCorreosDto envioCorreosDto)
        {
            try
            {
                BaseRepository<EnvioCorreos> envioCorreosRepository = new EnvioCorreosRepository(context);
                var entidad = _mapper.Map<EnvioCorreos>(envioCorreosDto);
                envioCorreosRepository.Update(entidad);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
    }
}
