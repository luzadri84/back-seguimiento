using System.Collections.ObjectModel;
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.BL.Interface
{
    public interface IFormulariosBL
    {
        RespuestaDto CrearFormularioA(FormularioADto formularioA);
        RespuestaDto Crearappbeneficiarios(AppBeneficiariosDto appBeneficiarios);

        RespuestaDto CrearProponente(ProponenteDto proponente);
        RespuestaDto ActualizacionProyecto(ProyectoDto proyecto);
        AppBeneficiariosDto GetBeneficiados(decimal pro_id);
        ProponenteDto GetProponenteById(decimal pro_id);
        ProyectoDto GetProyectoById(decimal pro_id);
        RespuestaDto ActualizarFormularioB(FormularioBDto formularioB, string UserName);
        Collection<ProyectoDto> GetProyectosByProponente(decimal pro_id);
        Collection<TemasProyectosDto> GetTemasByProyecto(decimal pro_id);
        ComponentesDto ComponenteByProyecto(decimal pro_id);
        Collection<CronogramaDto> GetCronograma(decimal pro_id);
        Collection<ProyectoActividadesObligatoriasDto> GetActividadesObligatoriasByProyecto(decimal proId);
        Collection<ValoresIndicadorDto> GetValoresIndicadorByProyecto(decimal proId);
        Collection<ValoresIndicadorLineaCategoriaMunicipioDto> GetValoresIndicadorLineaCategoriaMunicipio(decimal pro_id);
        RespuestaDto CrearSeguimiento(ConSeguimientosDto seguimiento);
    }
}
