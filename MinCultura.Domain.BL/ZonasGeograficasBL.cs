using System.Collections.ObjectModel;
using AutoMapper;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.BL
{
    public class ZonasGeograficasBL : IZonasGeograficasBL
    {
        private readonly IZonasGeograficasRepository<BasZonasGeograficas> _zonasGeoRepository;
        private readonly IMapper _mapper;

        public ZonasGeograficasBL(IZonasGeograficasRepository<BasZonasGeograficas> zonasGeoRepository, IMapper mapper)
        {
            _zonasGeoRepository = zonasGeoRepository;
            _mapper = mapper;
        }

        public Collection<ZonaGeograficaDto> GetDepartamento()
        {
            return _mapper.Map<Collection<ZonaGeograficaDto>>(_zonasGeoRepository.Get(p => p.ZonPadreId == null));
        }

        public Collection<ZonaGeograficaDto> GetMunicipiosByDepartamento(string IdDepartamento)
        {
            return _mapper.Map<Collection<ZonaGeograficaDto>>(_zonasGeoRepository.Get(p => p.ZonPadreId.Equals(IdDepartamento)));
        }
    }
}
