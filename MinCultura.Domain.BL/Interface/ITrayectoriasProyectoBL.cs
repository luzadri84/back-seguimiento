using System.Collections.Generic;
using System.Collections.ObjectModel;
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.BL.Interface
{
    public interface ITrayectoriasProyectoBL
    {
        RespuestaDto CrearTrayectorias(List<TrayectoriaProyectoDTO> trayectoriaProyectos);
        RespuestaDto CrearPresupuesto(List<AppPresupuestoDetalleDto> presupuestoProyecto);
        RespuestaDto CrearAppTipoDocumentosValores(AppTipoDocumentosValoresDto appTipoDocumentosValores);
        Collection<TrayectoriaProyectoDTO> GetTrayectoriasProyecto(decimal idVigencia, decimal pro_id);
    }
}
