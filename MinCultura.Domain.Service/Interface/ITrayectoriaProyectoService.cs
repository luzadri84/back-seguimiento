
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.Service.Interface
{
    public interface ITrayectoriaProyectoService
    {
        RespuestaDto CrearTrayectorias(List<TrayectoriaProyectoDTO> trayectoriaProyectos);
        RespuestaDto CrearPresupuesto(List<AppPresupuestoDetalleDto> presupuestoProyecto);
        RespuestaDto CrearDocumento(AppTipoDocumentosValoresDto appTipoDocumentosValores);
        Collection<TrayectoriaProyectoDTO> GetTrayectoriasProyecto(decimal pro_id);
    }

}
