using MinCultura.Domain.Common.DTO;
using System.Collections.ObjectModel;

namespace MinCultura.Domain.Service.Interface
{
    public interface IAdministracionService
    {
        /// <summary>
        /// Metodo con las validaciones de autenticación
        /// </summary>
        /// <param name="login">Información del login</param>
        /// <returns>Usuario</returns>
        CuentaUsuarioDto Login(UserLoginDto login);
        Collection<ServicioDto> GetServicios(int cuentaUsuarioId);
        Collection<ZonaGeograficaDto> GetDepartamento();
        Collection<ZonaGeograficaDto> GetMunicipiosByDepartamento(string IdDepartamento);
        Collection<AppVigenciasDto> GetAppVigencias();
        Collection<AppTiposEntidadesDto> GetTiposEntidades();

        /// <summary>
        /// Método para crear un usuario y asociarlo a una Entidad
        /// </summary>
        /// <param name="usuario">Información del usuario a crear</param>
        /// <returns>Respuesta Usuario creado si cumple con los requisitos de la convocatoria</returns>
        CrearUsuarioRespuestaDto CrearUsuario(CrearUsuarioDto crear);
        bool ActualizarUsuario(CuentaUsuarioDto actualizar);
        Collection<EntidadesFinancierasDto> GetEntidadesFinancieras();
        RespuestaDto RecuperarClave(ForgotDto usuario);
        RespuestaDto ValidarLink(string guid);
        RespuestaDto CambiarClave(ChangePasswordDto data);
        RespuestaDto ConfirmarUsuario(string guid);

        Collection<TrayectoriasDTO> GetTrayectoria(int tipoTrayectoria);
        Collection<TrayectoriasDTO> GetTrayectoria();
        Collection<TipoTrayectoriasDTO> GetTipoTrayectoria();

        Collection<AppPresupuestoDetalleTipoTitulosDto> GetAppPresupuestoDetalleTipoTitulos();
        Collection<AppPresupuestoDetalleDto> GetAppPresupuestoDetalle(decimal idProyecto);
        Collection<FuncionarioDto> getFuncionarios(int idPerfil);

        Collection<ConZonasDto> GetZonas();

        Collection<ConEstadosDto> GetEstados();

        // Collection<AppPresupuestoDetalleDto> GetAppPresupuestoDetalle(decimal idVigencia, decimal idProyecto);

        Collection<AppPresupuestoDetalleTipoDto> GetAppPresupuestoDetalleTipo();
        Collection<PresupuestoParametrizacionLineasTopeDto> GetPresupuestoParametrizacionLineasTope(string zonId, decimal lineaId);
        Collection<AppDocumentosTipoEntidadesDto> GetAppDocumentosTipoEntidades(int idtipId);
        Collection<AppTipoDocumentosValoresDto> GetappTipoDocumentosValores(int idPro);
        Collection<ResultadoDTO> GetResultadoConvocatoria(int idVigencia, string depId, string munId, string proyecto, string proponente, string nroRadicacion);

        Collection<ConActividadesDto> GetActividades();

        #region Formulario parte B
        /// <summary>
        /// Obtiene las lineas 
        /// </summary>
        /// <returns></returns>
        Collection<LineaDto> GetLineas();
        /// <summary>
        /// Obtiene indicadores por línea
        /// </summary>
        /// <param name="LineaId"></param>
        /// <returns></returns>
        Collection<IndicadoresLineaDto> GetIndicadoresByLinea(decimal LineaId);


        Collection<IndicadoresDto> GetIndicadores();

        /// <summary>
        /// Obtiene las áreas
        /// </summary>
        /// <returns></returns>
        Collection<AreaDto> GetAreas();

        /// <summary>
        /// Obtiene temas por línea
        /// </summary>
        /// <param name="LineaId"></param>
        /// <returns></returns>
        Collection<TemasDto> GetTemasByLinea(decimal LineaId);

        /// <summary>
        /// Obtiene actividades obligatorias
        /// </summary>
        /// <returns></returns>
        Collection<ActividadesObligatoriasDto> GetActividadesObligatorias();


        Collection<IndicadorLineaCategoriaMunicipioDto> GetAppIndicadorLineaCategoriaMunicipio();




        #endregion


        #region Evaluación 
        Collection<RequisitosDto> GetRequisitos(int tipId);
        #endregion
    }
}
