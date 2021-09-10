
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Service.Interface;

namespace MinCultura.Domain.Service
{
    public class TrayectoriaProyectoService : ITrayectoriaProyectoService
    {
        private readonly ITrayectoriasProyectoBL _trayectoriasProyectoBL;
        private readonly IListasBL _listasBL;

        public TrayectoriaProyectoService(ITrayectoriasProyectoBL trayectoriasProyectoBL, IListasBL listasBL)
        {
            _listasBL = listasBL;
            _trayectoriasProyectoBL = trayectoriasProyectoBL;
        }

        public RespuestaDto CrearTrayectorias(List<TrayectoriaProyectoDTO> trayectoriaProyectos)
        {
            return _trayectoriasProyectoBL.CrearTrayectorias(trayectoriaProyectos);
        }

        public RespuestaDto CrearPresupuesto(List<AppPresupuestoDetalleDto> presupuestoProyecto)
        {
            return _trayectoriasProyectoBL.CrearPresupuesto(presupuestoProyecto);
        }
                
        public Collection<TrayectoriaProyectoDTO> GetTrayectoriasProyecto(decimal pro_id)
        {
            return _trayectoriasProyectoBL.GetTrayectoriasProyecto(GetIdVigencia(), pro_id);
        }

        public RespuestaDto CrearDocumento(AppTipoDocumentosValoresDto appTipoDocumentosValores)
        {
            return _trayectoriasProyectoBL.CrearAppTipoDocumentosValores(appTipoDocumentosValores);
        }

        /// <summary>
        /// Obtener el IdVigencia para crear el proyecto y asociarlo
        /// </summary>
        /// <returns></returns>
        private decimal GetIdVigencia()
        {
            var vigencias = _listasBL.GetAppVigencias();
            var vigencia = vigencias.Where(p => p.VigEstado.Equals("A")).FirstOrDefault();
            return vigencia != null ? vigencia.VigId : 0;
        }
    }
}
