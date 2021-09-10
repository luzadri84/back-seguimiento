using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_CONTRATACION")]
    public partial class AppContratacion
    {
        [Key]
        [Column("ID", TypeName = "numeric(18, 0)")]
        public decimal Id { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }
        [Column("CON_NUMEROCONVENIO", TypeName = "numeric(18, 0)")]
        public decimal? ConNumeroconvenio { get; set; }
        [Column("CON_FECHAINICIO", TypeName = "datetime")]
        public DateTime? ConFechainicio { get; set; }
        [Column("CON_FECHAFIN", TypeName = "datetime")]
        public DateTime? ConFechafin { get; set; }
        [Column("CON_VALORCONVENIO", TypeName = "numeric(18, 0)")]
        public decimal? ConValorconvenio { get; set; }
        [Column("CON_REGISTROPRESUP")]
        [StringLength(50)]
        public string ConRegistropresup { get; set; }
        [Column("CON_REGISTROPRESUP_S_N")]
        [StringLength(1)]
        public string ConRegistropresupSN { get; set; }
        [Column("CON_CONVENIOFIRMADO")]
        [StringLength(1)]
        public string ConConveniofirmado { get; set; }
        [Column("CON_FORMATO_A")]
        [StringLength(1)]
        public string ConFormatoA { get; set; }
        [Column("CON_TOTALFOLIOS", TypeName = "numeric(18, 0)")]
        public decimal? ConTotalfolios { get; set; }
        [Column("CON_GARANTIA_MANEJO_DESDE", TypeName = "datetime")]
        public DateTime? ConGarantiaManejoDesde { get; set; }
        [Column("CON_GARANTIA_MANEJO_HASTA", TypeName = "datetime")]
        public DateTime? ConGarantiaManejoHasta { get; set; }
        [Column("CON_GARANTIA_MANEJO_OK")]
        [StringLength(1)]
        public string ConGarantiaManejoOk { get; set; }
        [Column("CON_GARANTIA_CUMP_DESDE", TypeName = "datetime")]
        public DateTime? ConGarantiaCumpDesde { get; set; }
        [Column("CON_GARANTIA_CUMP_HASTA", TypeName = "datetime")]
        public DateTime? ConGarantiaCumpHasta { get; set; }
        [Column("CON_GARANTIA_CUMP_OK")]
        [StringLength(1)]
        public string ConGarantiaCumpOk { get; set; }
        [Column("CON_GARANTIA_SALARIO_DESDE", TypeName = "datetime")]
        public DateTime? ConGarantiaSalarioDesde { get; set; }
        [Column("CON_GARANTIA_SALARIO_HASTA", TypeName = "datetime")]
        public DateTime? ConGarantiaSalarioHasta { get; set; }
        [Column("CON_GARANTIA_SALARIO_OK")]
        [StringLength(1)]
        public string ConGarantiaSalarioOk { get; set; }
        [Column("CON_CRP")]
        [StringLength(50)]
        public string ConCrp { get; set; }
        [Column("CON_USUARIO")]
        [StringLength(50)]
        public string ConUsuario { get; set; }
        [Column("DEP_ID", TypeName = "numeric(18, 0)")]
        public decimal? DepId { get; set; }
        [Column("ESC_ID", TypeName = "numeric(18, 0)")]
        public decimal? EscId { get; set; }
        [Column("CON_CDP")]
        [StringLength(50)]
        public string ConCdp { get; set; }
        [Column("CON_FECHACDP")]
        [StringLength(10)]
        public string ConFechacdp { get; set; }
        [Column("CON_ACTA")]
        [StringLength(50)]
        public string ConActa { get; set; }
        [Column("CON_FECHAACTA")]
        [StringLength(10)]
        public string ConFechaacta { get; set; }
        [Column("CON_ANEXOS")]
        [StringLength(1)]
        public string ConAnexos { get; set; }
        [Column("CON_EVALUACION")]
        [StringLength(1)]
        public string ConEvaluacion { get; set; }
        [Column("CON_FORMATO_B")]
        [StringLength(1)]
        public string ConFormatoB { get; set; }
        [Column("CON_CONTRATANDO")]
        [StringLength(1)]
        public string ConContratando { get; set; }
        [Column("CON_VALORADICION", TypeName = "numeric(18, 0)")]
        public decimal? ConValoradicion { get; set; }
        [Column("CON_CORREEOSUPERVISOR")]
        [StringLength(1)]
        public string ConCorreeosupervisor { get; set; }
        [Column("CON_CORREOFINALIZACION")]
        [StringLength(1)]
        public string ConCorreofinalizacion { get; set; }
        [Column("CON_FORMA_PAGO")]
        [StringLength(1000)]
        public string ConFormaPago { get; set; }
        [Column("CON_ABOGADO")]
        [StringLength(500)]
        public string ConAbogado { get; set; }
        [Column("CON_FECHASUSCRIPCION", TypeName = "datetime")]
        public DateTime? ConFechasuscripcion { get; set; }
        [Column("CON_LINKSECOP")]
        [StringLength(500)]
        public string ConLinksecop { get; set; }
        [Column("CON_FECHA_LIQUIDACION", TypeName = "datetime")]
        public DateTime? ConFechaLiquidacion { get; set; }
        [Column("CON_FECHA_RAD_CONTRATOS", TypeName = "datetime")]
        public DateTime? ConFechaRadContratos { get; set; }
        [Column("CON_FECHA_LIQ_CONTRATOS", TypeName = "datetime")]
        public DateTime? ConFechaLiqContratos { get; set; }
        [Column("CON_NUM_PROCESO_SECOP")]
        [StringLength(500)]
        public string ConNumProcesoSecop { get; set; }
        [Column("CON_NOTIFICADO")]
        public bool? ConNotificado { get; set; }
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

        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(BasDependencias.AppContratacion))]
        public virtual BasDependencias Dep { get; set; }
        [ForeignKey(nameof(EscId))]
        [InverseProperty(nameof(AppEstadoContratacion.AppContratacion))]
        public virtual AppEstadoContratacion Esc { get; set; }
        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppContratacion))]
        public virtual AppProyectos Pro { get; set; }
    }
}
