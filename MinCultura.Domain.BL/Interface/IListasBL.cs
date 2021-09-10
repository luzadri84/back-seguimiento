using System.Collections.ObjectModel;
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.BL.Interface
{
    public interface IListasBL
    {

        Collection<AppVigenciasDto> GetAppVigencias();
        Collection<AppTiposEntidadesDto> GetTiposEntidades(decimal idVigencia);
        Collection<LineaDto> GetLineas(decimal idVigencia);
        Collection<EntidadesFinancierasDto> GetEntidadesFinancieras();
        Collection<IndicadoresLineaDto> GetIndicadoresByLinea(decimal idLinea);
        Collection<AreaDto> GetAreas(decimal idVigencia);
        Collection<TemasDto> GetTemasByLinea(decimal idLinea);
        Collection<ActividadesObligatoriasDto> GetActividadesObligatorias();
        Collection<TrayectoriasDTO> GetTrayectorias(decimal idVigencia, int tipoTrayectoria);
        Collection<TrayectoriasDTO> GetTrayectorias(decimal idVigencia);
        Collection<TipoTrayectoriasDTO> GetTipoTrayectorias();
        Collection<AppPresupuestoDetalleTipoTitulosDto> GetAppPresupuestoDetalleTipoTitulos();
        Collection<AppPresupuestoDetalleTipoDto> GetAppPresupuestoDetalleTipo(decimal idVigencia);
        Collection<IndicadoresDto> GetIndicadores();
        Collection<AppPresupuestoDetalleDto> GetAppPresupuestoDetalle(decimal idVigencia, decimal idProyecto);
        Collection<PresupuestoParametrizacionLineasTopeDto> GetPresupuestoParametrizacionLineasTope(string zonId, decimal lineaId);
        Collection<IndicadorLineaCategoriaMunicipioDto> GetAppIndicadorLineaCategoriaMunicipios();
        Collection<AppDocumentosTipoEntidadesDto> GetAppDocumentosTipoEntidades(int tipId);
        Collection<AppTipoDocumentosDto> GetAppTipoDocumentos();
        Collection<AppTipoDocumentosValoresDto> GetappTipoDocumentosValores(int idPro);
        Collection<ResultadoDTO> GetResultado(int idVigencia,  string depId, string munId, string proyecto, string proponente, string nroRadicacion);
        Collection<RequisitosDto> GetRequisitos(int tipId);
        Collection<ConZonasDto> GetZonas();
        Collection<ConEstadosDto> GetEstados();

        Collection<ConActividadesDto> GetActividades();





    }
}
