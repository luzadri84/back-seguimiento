using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_PROYECTOS")]
    public partial class AppProyectos
    {
        public AppProyectos()
        {
            AppBeneficiarios = new HashSet<AppBeneficiarios>();
            AppComponentes = new HashSet<AppComponentes>();
            AppContratacion = new HashSet<AppContratacion>();
            AppEvaluacionRequisitos = new HashSet<AppEvaluacionRequisitos>();
            AppPresupuestoDetalle = new HashSet<AppPresupuestoDetalle>();
            AppCronograma = new HashSet<AppCronograma>();
            AppRegistroRechazados = new HashSet<AppRegistroRechazados>();
            AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
            AppUsuariosImpresion = new HashSet<AppUsuariosImpresion>();
            AppValoresIndicador = new HashSet<AppValoresIndicador>();
            AppRadicadoProyectos = new HashSet<AppRadicadoProyectos>();
        }

        [Key]
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }
        [Column("LIN_ID", TypeName = "decimal(18, 0)")]
        public decimal? LinId { get; set; }
        [Column("USU_ID", TypeName = "decimal(18, 0)")]
        public decimal? UsuId { get; set; }
        [Column("ARE_ID", TypeName = "decimal(18, 0)")]
        public decimal? AreId { get; set; }
        [Column("VIG_ID", TypeName = "decimal(18, 0)")]
        public decimal? VigId { get; set; }
        [Column("ZON_ID")]
        [StringLength(5)]
        public string ZonId { get; set; }
        [Column("PRO_TIPO_CUENTA")]
        [StringLength(1)]
        public string ProTipoCuenta { get; set; }
        [Column("PRO_NUMERO_CUENTA")]
        [StringLength(50)]
        public string ProNumeroCuenta { get; set; }
        [Column("PRO_CIUDAD_ENTIDAD_FINANCIERA")]
        [StringLength(50)]
        public string ProCiudadEntidadFinanciera { get; set; }
        [Column("PRO_FIRMADO")]
        [StringLength(1)]
        public string ProFirmado { get; set; }
        [Column("PRO_NUMERO_RADICACION")]
        [StringLength(20)]
        public string ProNumeroRadicacion { get; set; }
        [Column("PRO_OTRA_AREA")]
        [StringLength(200)]
        public string ProOtraArea { get; set; }
        [Column("PRO_NOMBRE")]
        [StringLength(500)]
        public string ProNombre { get; set; }
        [Column("PRO_OBJETO")]
        [StringLength(500)]
        public string ProObjeto { get; set; }
        [Column("PRO_FECHA_INICIAL", TypeName = "datetime")]
        public DateTime? ProFechaInicial { get; set; }
        [Column("PRO_FECHA_FINAL", TypeName = "datetime")]
        public DateTime? ProFechaFinal { get; set; }
        [Column("PRO_VALOR_PROYECTO", TypeName = "decimal(18, 0)")]
        public decimal? ProValorProyecto { get; set; }
        [Column("PRO_VALOR_SOLICITADO", TypeName = "decimal(10, 0)")]
        public decimal? ProValorSolicitado { get; set; }
        [Column("PRO_PORCENTAJE", TypeName = "decimal(18, 2)")]
        public decimal? ProPorcentaje { get; set; }
        [Column("PRO_PERIODICIDAD_CRONOGRAMA")]
        [StringLength(1)]
        public string ProPeriodicidadCronograma { get; set; }
        [Column("PRO_VALOR_APROBADO", TypeName = "decimal(18, 0)")]
        public decimal? ProValorAprobado { get; set; }
        [Column("PRO_ESTADO")]
        [StringLength(1)]
        public string ProEstado { get; set; }
        [Column("PRO_ESTADO_NUEVO")]
        [StringLength(1)]
        public string ProEstadoNuevo { get; set; }
        [Column("PRO_PUNTAJE_TOTAL")]
        public int? ProPuntajeTotal { get; set; }
        [Column("ENT_ID", TypeName = "decimal(18, 0)")]
        public decimal EntId { get; set; }
        [Column("PRO_ID_PROPONENTE", TypeName = "numeric(18, 0)")]
        public decimal ProIdProponente { get; set; }
        [Column("PRO_PERSONA_ENCARGADA_PROYECTO")]
        [StringLength(100)]
        public string ProPersonaEncargadaProyecto { get; set; }
        [Column("PRO_TELEFONOS_PERSONA_ENCARGADA_PROYECTO")]
        [StringLength(50)]
        public string ProTelefonosPersonaEncargadaProyecto { get; set; }
        [Column("PRO_CORREO_PERSONA_ENCARGADA")]
        [StringLength(200)]
        public string ProCorreoPersonaEncargada { get; set; }
        [Column("PRO_FECHA_RADICACION", TypeName = "datetime")]
        public DateTime? ProFechaRadicacion { get; set; }
        [Column("POR_FECHA_CARTA_COMPLEMENTACION", TypeName = "datetime")]
        public DateTime? PorFechaCartaComplementacion { get; set; }
        [Column("TIP_ID", TypeName = "decimal(18, 0)")]
        public decimal? TipId { get; set; }
        [Column("PRO_OBSERVACIONES")]
        [StringLength(4000)]
        public string ProObservaciones { get; set; }
        [Column("USUARIO_EVALUA", TypeName = "decimal(18, 0)")]
        public decimal? UsuarioEvalua { get; set; }
        [Column("PRO_FECHA_CARTA_RECHAZO", TypeName = "datetime")]
        public DateTime? ProFechaCartaRechazo { get; set; }
        [Column("PRO_ACTA_COMITE")]
        [StringLength(1)]
        public string ProActaComite { get; set; }
        [Column("PRO_ACTA_AJUSTE")]
        [StringLength(1)]
        public string ProActaAjuste { get; set; }
        [Column("PRO_OBSERVACIONES_EVALUACION")]
        public string ProObservacionesEvaluacion { get; set; }
        [Column("PRO_ACTA_INICIAL")]
        [StringLength(1)]
        public string ProActaInicial { get; set; }
        [Column("PRO_FECHA_CAMBIO_ESTADO", TypeName = "datetime")]
        public DateTime? ProFechaCambioEstado { get; set; }
        [Column("ZON_ID_ENTIDAD_BANCARIA")]
        [StringLength(5)]
        public string ZonIdEntidadBancaria { get; set; }
        [Column("ZON_LATITUD")]
        public double? ZonLatitud { get; set; }
        [Column("ZON_LONGITUD")]
        public double? ZonLongitud { get; set; }
        [Column("USU_ID_CARTA_COMPLEMENTACION", TypeName = "decimal(18, 0)")]
        public decimal? UsuIdCartaComplementacion { get; set; }
        [Column("CAU_ID", TypeName = "decimal(18, 0)")]
        public decimal? CauId { get; set; }
        [Column("PRO_VISIBLE")]
        public int? ProVisible { get; set; }
        [Column("PRO_IMAGEN_PLANO")]
        [StringLength(300)]
        public string ProImagenPlano { get; set; }
        [Column("PRO_ENVIO_CARTA_COMPLEMENTACION", TypeName = "datetime")]
        public DateTime? ProEnvioCartaComplementacion { get; set; }
        [Column("PRO_IMAGEN_ORGANIGRAMA")]
        [StringLength(300)]
        public string ProImagenOrganigrama { get; set; }
        
        [Column("PRO_INCENTIVO")]
        [StringLength(1)]
        public string ProIncentivo { get; set; }
        [Column("PRO_APLICA_INCENTIVO")]
        public bool? ProAplicaIncentivo { get; set; }
        [Column("PRO_CORREGIMIENTO")]
        [StringLength(1000)]
        public string ProCorregimiento { get; set; }
        [Column("PRO_APOYO_PROPIO", TypeName = "decimal(18, 0)")]
        public decimal? ProApoyoPropio { get; set; }
        [Required]
        [Column("USU_CREO")]
        [StringLength(100)]
        public string UsuCreo { get; set; }
        [Column("USU_MODIFICO")]
        [StringLength(100)]
        public string UsuModifico { get; set; }
        [Column("FEC_CREO", TypeName = "datetime")]
        public DateTime FecCreo { get; set; }
        [Column("FEC_MODIFICO", TypeName = "datetime")]
        public DateTime? FecModifico { get; set; }
        [Column("AREA_ID_1", TypeName = "decimal(18,0)")]
        public decimal? AreaId1 { get; set; }
        [Column("AREA_ID_2", TypeName = "decimal(18, 0)")]
        public decimal? AreaId2 { get; set; }
        [Column("AREA_ID_3", TypeName = "decimal(18, 0)")]
        public decimal? AreaId3 { get; set; }
        [Column("PRO_OTROS_MUNICIPIOS")]
        public string ProOtrosMunicipios { get; set; }

        [Column("ZON_DEP_ID")]
        [StringLength(5)]
        public string ZonDepId { get; set; }

        [Column("PRO_CONVENIO")]
        public string ProConvenio { get; set; }

        [Column("PRO_FECHA_LEGALIZACION")]
        public DateTime? ProFechaLegalizacion { get; set; }
        [Column("PRO_CELULAR_PERSONA_ENCARGADA")]
        public string ProCelularPersonaEncargada { get; set; }


        [Column("PRO_FECHA_PUNTUAL_INICIAL")]
        public DateTime? ProFechaPuntualInicial { get; set; }

        [Column("PRO_FECHA_PUNTUAL_FINAL")]
        public DateTime? ProFechaPuntualFinal { get; set; }

        [Column("PRO_USUARIO_ASIGNADO")]
        public decimal? ProUsuarioAsignado { get; set; }
        [Column("ZONA_ID")]
        public decimal? ZonaId { get; set; }
        [Column("PRO_FECHA_ENTREGADO_SUPERVISOR")]
        public DateTime? ProFechaEntregadoSupervisor { get; set; }
        [Column("PRO_FECHA_PRORROGA")]
        public DateTime? ProFechaProrroga { get; set; }
        [Column("PRO_ESTADO_SEGUIMIENTO")]
        public decimal? ProEstadoSeguimiento { get; set; }
        [Column("PRO_FECHA_ESTADO")]
        public DateTime? ProFechaEstado { get; set; }
        [Column("PRO_FECHA_RADICACION_SEGUIMIENTO")]
        public DateTime? ProFechaRadicacionSeguimiento { get; set; }
        [Column("PRO_CUENTAS_PAGAR")]
        public decimal? ProCuentasPagar { get; set; }
        [Column("PRO_ESTADO_OBSERVACIONES")]
        public string ProEstadoObservaciones { get; set; }


        [ForeignKey(nameof(EntId))]
        [InverseProperty(nameof(BasEntidadesFinancieras.AppProyectos))]
        public virtual BasEntidadesFinancieras Ent { get; set; }
        [ForeignKey(nameof(ProIdProponente))]
        [InverseProperty(nameof(AppProponentes.AppProyectos))]
        public virtual AppProponentes ProIdProponenteNavigation { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppBeneficiarios> AppBeneficiarios { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppComponentes> AppComponentes { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppContratacion> AppContratacion { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppEvaluacionRequisitos> AppEvaluacionRequisitos { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppPresupuestoDetalle> AppPresupuestoDetalle { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppCronograma> AppCronograma { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppRegistroRechazados> AppRegistroRechazados { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppUsuariosImpresion> AppUsuariosImpresion { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppValoresIndicador> AppValoresIndicador { get; set; }
        [InverseProperty("Pro")]
        public virtual ICollection<AppRadicadoProyectos> AppRadicadoProyectos { get; set; }
        public virtual ICollection<AppValoresIndicadorLineaCategoriaMunicipio> AppValoresIndicadorLineaCategoriaMunicipio { get; set; }
    }
}
