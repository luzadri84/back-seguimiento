using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppProyectos
    {
        public AppProyectos()
        {
            AppBeneficiarios = new HashSet<AppBeneficiarios>();
            AppComponentes = new HashSet<AppComponentes>();
            AppContratacion = new HashSet<AppContratacion>();
            AppEvaluacionRequisitos = new HashSet<AppEvaluacionRequisitos>();
            AppPresupuestoDetalle = new HashSet<AppPresupuestoDetalle>();
            AppProyectoActividadesObligatorias = new HashSet<AppProyectoActividadesObligatorias>();
            AppProyectosCronograma = new HashSet<AppProyectosCronograma>();
            AppRadicadoProyectos = new HashSet<AppRadicadoProyectos>();
            AppRegistroRechazados = new HashSet<AppRegistroRechazados>();
            AppTemasProyectos = new HashSet<AppTemasProyectos>();
            AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
            AppUsuariosImpresion = new HashSet<AppUsuariosImpresion>();
            AppValoresIndicador = new HashSet<AppValoresIndicador>();
            TrayectoriaProyecto = new HashSet<TrayectoriaProyecto>();
        }

        public decimal ProId { get; set; }
        public decimal? LinId { get; set; }
        public decimal? UsuId { get; set; }
        public decimal? AreId { get; set; }
        public decimal? VigId { get; set; }
        public string ZonId { get; set; }
        public string ProTipoCuenta { get; set; }
        public string ProNumeroCuenta { get; set; }
        public string ProCiudadEntidadFinanciera { get; set; }
        public string ProFirmado { get; set; }
        public string ProNumeroRadicacion { get; set; }
        public string ProOtraArea { get; set; }
        public string ProNombre { get; set; }
        public string ProObjeto { get; set; }
        public DateTime? ProFechaInicial { get; set; }
        public DateTime? ProFechaFinal { get; set; }
        public decimal? ProValorProyecto { get; set; }
        public decimal? ProValorSolicitado { get; set; }
        public decimal? ProPorcentaje { get; set; }
        public string ProPeriodicidadCronograma { get; set; }
        public decimal? ProValorAprobado { get; set; }
        public string ProEstado { get; set; }
        public string ProEstadoNuevo { get; set; }
        public int? ProPuntajeTotal { get; set; }
        public decimal EntId { get; set; }
        public decimal ProIdProponente { get; set; }
        public string ProPersonaEncargadaProyecto { get; set; }
        public string ProTelefonosPersonaEncargadaProyecto { get; set; }
        public string ProCorreoPersonaEncargada { get; set; }
        public DateTime? ProFechaRadicacion { get; set; }
        public DateTime? PorFechaCartaComplementacion { get; set; }
        public decimal? TipId { get; set; }
        public string ProObservaciones { get; set; }
        public decimal? UsuarioEvalua { get; set; }
        public DateTime? ProFechaCartaRechazo { get; set; }
        public string ProActaComite { get; set; }
        public string ProActaAjuste { get; set; }
        public string ProObservacionesEvaluacion { get; set; }
        public string ProActaInicial { get; set; }
        public DateTime? ProFechaCambioEstado { get; set; }
        public string ZonIdEntidadBancaria { get; set; }
        public double? ZonLatitud { get; set; }
        public double? ZonLongitud { get; set; }
        public decimal? UsuIdCartaComplementacion { get; set; }
        public decimal? CauId { get; set; }
        public int? ProVisible { get; set; }
        public string ProTema1 { get; set; }
        public string ProTema2 { get; set; }
        public string ProTema3 { get; set; }
        public string ProImagenPlano { get; set; }
        public DateTime? ProEnvioCartaComplementacion { get; set; }
        public string ProImagenOrganigrama { get; set; }
        public string ProTemaLinea51 { get; set; }
        public string ProTemaLinea52 { get; set; }
        public string ProTemaLinea53 { get; set; }
        public string ProTemaLinea54 { get; set; }
        public string ProTemaLinea55 { get; set; }
        public string ProTemaLinea56 { get; set; }
        public string ProGrupoLinea7 { get; set; }
        public string ProTemaLinea31 { get; set; }
        public string ProTemaLinea32 { get; set; }
        public string ProTemaLinea33 { get; set; }
        public string ProIncentivo { get; set; }
        public string ProGrupoLinea72 { get; set; }
        public string ProGrupoLinea73 { get; set; }
        public string ProGrupoLinea74 { get; set; }
        public string ProGrupoLinea75 { get; set; }
        public bool? ProAplicaIncentivo { get; set; }
        public string ObservacionesProyecto { get; set; }
        public string ProCorregimiento { get; set; }
        public string ProTemaLinea34 { get; set; }
        public string ProTemaLinea35 { get; set; }
        public string ProTemaLinea36 { get; set; }
        public string ProTemaLinea521 { get; set; }
        public string ProTemaLinea522 { get; set; }
        public string ProTemaLinea523 { get; set; }
        public string ProTemaLinea524 { get; set; }
        public decimal? ProApoyoPropio { get; set; }
        public string ProTemaLinea525 { get; set; }
        public string ProTemaLinea526 { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
        public decimal? AreaId1 { get; set; }
        public decimal? AreaId2 { get; set; }
        public decimal? AreaId3 { get; set; }
        public string ProOtrosMunicipios { get; set; }
        public string ZonDepId { get; set; }
        public string ProConvenio { get; set; }
        public string ProCelularPersonaEncargada { get; set; }
        public DateTime? ProFechaPuntualInicial { get; set; }
        public DateTime? ProFechaPuntualFinal { get; set; }
        public DateTime? ProFechaLegalizacion { get; set; }

        public virtual BasEntidadesFinancieras Ent { get; set; }
        public virtual AppProponentes ProIdProponenteNavigation { get; set; }
        public virtual ICollection<AppBeneficiarios> AppBeneficiarios { get; set; }
        public virtual ICollection<AppComponentes> AppComponentes { get; set; }
        public virtual ICollection<AppContratacion> AppContratacion { get; set; }
        public virtual ICollection<AppEvaluacionRequisitos> AppEvaluacionRequisitos { get; set; }
        public virtual ICollection<AppPresupuestoDetalle> AppPresupuestoDetalle { get; set; }
        public virtual ICollection<AppProyectoActividadesObligatorias> AppProyectoActividadesObligatorias { get; set; }
        public virtual ICollection<AppProyectosCronograma> AppProyectosCronograma { get; set; }
        public virtual ICollection<AppRadicadoProyectos> AppRadicadoProyectos { get; set; }
        public virtual ICollection<AppRegistroRechazados> AppRegistroRechazados { get; set; }
        public virtual ICollection<AppTemasProyectos> AppTemasProyectos { get; set; }
        public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
        public virtual ICollection<AppUsuariosImpresion> AppUsuariosImpresion { get; set; }
        public virtual ICollection<AppValoresIndicador> AppValoresIndicador { get; set; }
        public virtual ICollection<TrayectoriaProyecto> TrayectoriaProyecto { get; set; }
    }
}
