
using System.Collections.ObjectModel;
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.Service.Interface
{
    public interface IFormulariosServicice
    {
        RespuestaDto CrearFormularioA(FormularioADto formularioA);
        RespuestaDto CrearProponente(ProponenteDto proponente);
        RespuestaDto ActualizarFormularioB(FormularioBDto formularioB, string UserName);
        RespuestaDto ActualizarProyecto(ProyectoDto proyecto);
        ProponenteDto GetProponenteById(decimal pro_id);
        ProyectoDto GetProyectoById(decimal pro_id);
        Collection<ProyectoDto> GetProyectosByProponente(decimal pro_id);
        Collection<TemasProyectosDto> GetTemasByProyecto(decimal pro_id);
        ComponentesDto GetComponenteByProyecto(decimal pro_id);
        Collection<CronogramaDto> GetCronograma(decimal proId);
        Collection<ProyectoActividadesObligatoriasDto> GetActividadesObligatoriasByProyecto(decimal proId);
        Collection<ValoresIndicadorDto> GetValoresIndicadorByProyecto(decimal proId);
        Collection<ValoresIndicadorLineaCategoriaMunicipioDto> GetValoresIndicadorLineaCategoriaMunicipio(decimal proId);
        AppBeneficiariosDto ConsultarBeneficiarios(decimal pro_id);
        RespuestaDto CrearBeneficiarios(AppBeneficiariosDto appBeneficiarios);

        RespuestaDto CrearSeguimiento(ConSeguimientosDto segumiento);

    }
}
