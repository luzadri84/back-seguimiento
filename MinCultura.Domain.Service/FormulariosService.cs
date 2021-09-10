
using System.Collections.ObjectModel;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Service.Interface;

namespace MinCultura.Domain.Service
{
    public class FormulariosService : IFormulariosServicice
    {
        private readonly IFormulariosBL _formulariosBL;

        public FormulariosService(IFormulariosBL formulariosBL)
        {
            _formulariosBL = formulariosBL;
        }

        public RespuestaDto CrearFormularioA(FormularioADto formularioA)
        {
            return _formulariosBL.CrearFormularioA(formularioA);
        }
        public RespuestaDto CrearProponente(ProponenteDto proponente)
        {
            return _formulariosBL.CrearProponente(proponente);
        }
        public RespuestaDto CrearBeneficiarios(AppBeneficiariosDto appBeneficiarios)
        {
            return _formulariosBL.Crearappbeneficiarios(appBeneficiarios);
        }

        public AppBeneficiariosDto ConsultarBeneficiarios(decimal pro_id)
        {
            return _formulariosBL.GetBeneficiados(pro_id);
        }

        public RespuestaDto ActualizarFormularioB(FormularioBDto formularioB, string userName)
        {
            return _formulariosBL.ActualizarFormularioB(formularioB, userName);
        }

        public RespuestaDto ActualizarProyecto(ProyectoDto proyecto)
        {
            return _formulariosBL.ActualizacionProyecto(proyecto);
        }

        public ProponenteDto GetProponenteById(decimal pro_id)
        {
            return _formulariosBL.GetProponenteById(pro_id);
        }

        public ProyectoDto GetProyectoById(decimal pro_id)
        {
            return _formulariosBL.GetProyectoById(pro_id);
        }

        public Collection<ProyectoDto> GetProyectosByProponente(decimal pro_id)
        {
            return _formulariosBL.GetProyectosByProponente(pro_id);
        }

        public Collection<TemasProyectosDto> GetTemasByProyecto(decimal pro_id)
        {
            return _formulariosBL.GetTemasByProyecto(pro_id);
        }

        public ComponentesDto GetComponenteByProyecto(decimal pro_id)
        {
            return _formulariosBL.ComponenteByProyecto(pro_id);
        }


        public Collection<CronogramaDto> GetCronograma(decimal proId)
        {
            return _formulariosBL.GetCronograma(proId);
        }

        public Collection<ProyectoActividadesObligatoriasDto> GetActividadesObligatoriasByProyecto(decimal proId)
        {
            return _formulariosBL.GetActividadesObligatoriasByProyecto(proId);
        }

        public Collection<ValoresIndicadorDto> GetValoresIndicadorByProyecto(decimal proId)
        {
            return _formulariosBL.GetValoresIndicadorByProyecto(proId);
        }

        public Collection<ValoresIndicadorLineaCategoriaMunicipioDto> GetValoresIndicadorLineaCategoriaMunicipio(decimal proId) 
        {
            return _formulariosBL.GetValoresIndicadorLineaCategoriaMunicipio(proId);
        }

        public RespuestaDto CrearSeguimiento(ConSeguimientosDto segumiento)
        {
            return _formulariosBL.CrearSeguimiento(segumiento);
        }


    }
}
