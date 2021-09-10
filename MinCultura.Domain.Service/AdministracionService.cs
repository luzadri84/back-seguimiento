using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Service.Interface;
using System.Collections.ObjectModel;
using System.Linq;

namespace MinCultura.Domain.Service
{
    public class AdministracionService : IAdministracionService
    {
        private readonly ILoginBL _loginBL;
        private readonly IZonasGeograficasBL _zonasGeoBL;
        private readonly IServicioBL _servicioBL;
        private readonly IListasBL _listasBL;


        public AdministracionService(ILoginBL loginBL, IZonasGeograficasBL zonasGeoBL, IServicioBL servicioBL,
            IListasBL listasBL)
        {
            _loginBL = loginBL;
            _zonasGeoBL = zonasGeoBL;
            _servicioBL = servicioBL;
            _listasBL = listasBL;
        }
        public Collection<ServicioDto> GetServicios(int cuentaUsuarioId)
        {
            return _servicioBL.Get(cuentaUsuarioId);
        }

        public Collection<ZonaGeograficaDto> GetDepartamento()
        {
            return _zonasGeoBL.GetDepartamento();
        }

        public Collection<ZonaGeograficaDto> GetMunicipiosByDepartamento(string IdDepartamento)
        {
            return _zonasGeoBL.GetMunicipiosByDepartamento(IdDepartamento);
        }

        public CuentaUsuarioDto Login(UserLoginDto login)
        {
            return _loginBL.Login(login);
        }

        public Collection<AppVigenciasDto> GetAppVigencias()
        {
            return _listasBL.GetAppVigencias();
        }

        public Collection<AppTiposEntidadesDto> GetTiposEntidades()
        {
            var vigencias = _listasBL.GetAppVigencias();
            var vigencia = vigencias.Where(p => p.VigEstado.Equals("A")).FirstOrDefault();
            return _listasBL.GetTiposEntidades(vigencia != null ? vigencia.VigId : 0);
        }

        public CrearUsuarioRespuestaDto CrearUsuario(CrearUsuarioDto crear)
        {
            return _loginBL.CrearUsuario(crear);
        }

        public bool ActualizarUsuario(CuentaUsuarioDto actualizar)
        {
            return _loginBL.ActualizarUsuario(actualizar);
        }

        public Collection<LineaDto> GetLineas()
        {
            return _listasBL.GetLineas(GetIdVigencia());
        }

        public Collection<IndicadoresLineaDto> GetIndicadoresByLinea(decimal LineaId)
        {
            return _listasBL.GetIndicadoresByLinea(LineaId);
        }

        public Collection<IndicadoresDto> GetIndicadores()
        {
            return _listasBL.GetIndicadores();
        }


        public Collection<TemasDto> GetTemasByLinea(decimal LineaId)
        {
            return _listasBL.GetTemasByLinea(LineaId);
        }

        public Collection<EntidadesFinancierasDto> GetEntidadesFinancieras()
        {
            return _listasBL.GetEntidadesFinancieras();
        }

        public Collection<AreaDto> GetAreas()
        {
            return _listasBL.GetAreas(GetIdVigencia());
        }

        public Collection<ActividadesObligatoriasDto> GetActividadesObligatorias()
        {
            return _listasBL.GetActividadesObligatorias();
        }


        public RespuestaDto RecuperarClave(ForgotDto usuario)
        {
            return _loginBL.RecuperarClave(usuario);
        }

        public RespuestaDto ValidarLink(string guid)
        {
            return _loginBL.ValidarLink(guid);
        }

        public RespuestaDto CambiarClave(ChangePasswordDto data)
        {
            return _loginBL.CambiarClave(data);
        }

        public RespuestaDto ConfirmarUsuario(string guid)
        {
            return _loginBL.ConfirmarUsuario(guid);
        }

        public Collection<PresupuestoParametrizacionLineasTopeDto> GetPresupuestoParametrizacionLineasTope(string zonId, decimal lineaId )
        {
            return _listasBL.GetPresupuestoParametrizacionLineasTope(zonId, lineaId);
        }

        public Collection<TrayectoriasDTO> GetTrayectoria(int tipoTrayectoria)
        {
            return _listasBL.GetTrayectorias(GetIdVigencia(), tipoTrayectoria);
        }

        public Collection<TrayectoriasDTO> GetTrayectoria()
        {
            return _listasBL.GetTrayectorias(GetIdVigencia());
        }

        public Collection<TipoTrayectoriasDTO> GetTipoTrayectoria()
        {
            return _listasBL.GetTipoTrayectorias();
        }

        public Collection<AppPresupuestoDetalleTipoTitulosDto> GetAppPresupuestoDetalleTipoTitulos()
        {
            return _listasBL.GetAppPresupuestoDetalleTipoTitulos();
        }

        public Collection<AppPresupuestoDetalleTipoDto> GetAppPresupuestoDetalleTipo()
        {
            return _listasBL.GetAppPresupuestoDetalleTipo(GetIdVigencia());
        }

        public Collection<AppPresupuestoDetalleDto> GetAppPresupuestoDetalle(decimal idProyecto)
        {
            return _listasBL.GetAppPresupuestoDetalle(GetIdVigencia(), idProyecto);
        }

        public Collection<AppDocumentosTipoEntidadesDto> GetAppDocumentosTipoEntidades(int idtipId)
        {
            return _listasBL.GetAppDocumentosTipoEntidades(idtipId);
        }

        public Collection<AppTipoDocumentosValoresDto> GetappTipoDocumentosValores(int idPro)
        {
            return _listasBL.GetappTipoDocumentosValores(idPro);
        }

        /// <summary>
        /// Obtiene indicador por categoria de municipio
        /// </summary>
        /// <param name="idZonCategoria"></param>
        /// <returns>Lista de inidcador pertenecientes a esa categoria de municipio</returns>
        public Collection<IndicadorLineaCategoriaMunicipioDto> GetAppIndicadorLineaCategoriaMunicipio()
        {
            return _listasBL.GetAppIndicadorLineaCategoriaMunicipios();
        }

        /// <summary>
        /// Obtiene indicador por categoria de municipio
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <returns>Lista de inidcador pertenecientes a esa categoria de municipio</returns>
        public Collection<FuncionarioDto> getFuncionarios(int idPerfil)
        {
            return _loginBL.getFuncionarios(idPerfil);
        }

        public Collection<RequisitosDto> GetRequisitos(int tipId)
        {
            return _listasBL.GetRequisitos(tipId);
        }

        public Collection<ConZonasDto> GetZonas()
        {
            return _listasBL.GetZonas();
        }

        public Collection<ConEstadosDto> GetEstados()
        {
            return _listasBL.GetEstados();
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

        public Collection<ResultadoDTO> GetResultadoConvocatoria(int idVigencia, string depId, string munId, string proyecto, string proponente, string nroRadicacion)
        {
            return _listasBL.GetResultado(idVigencia, depId,  munId,  proyecto,  proponente,  nroRadicacion);
        }

        public Collection<ConActividadesDto> GetActividades()
        {
            return _listasBL.GetActividades();
        }
    }
}
