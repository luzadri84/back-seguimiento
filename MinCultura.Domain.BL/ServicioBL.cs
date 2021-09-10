using System.Collections.ObjectModel;
using AutoMapper;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.BL
{
    public class ServicioBL : IServicioBL
    {
        private readonly IServicioRepository<Servicio> _servicioRepository;
        private readonly IMapper _mapper;

        public ServicioBL(IServicioRepository<Servicio> servicioRepository, IMapper mapper)
        {
            _servicioRepository = servicioRepository;
            _mapper = mapper;
        }


        public Collection<ServicioDto> Get(int cuentaUsuarioId)
        {
            var servicios = _servicioRepository.Get(cuentaUsuarioId);
            return _mapper.Map<Collection<ServicioDto>>(servicios);
        }
    }
}
