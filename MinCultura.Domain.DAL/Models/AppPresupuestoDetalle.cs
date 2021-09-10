using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_PRESUPUESTO_DETALLE")]
    public partial class AppPresupuestoDetalle
    {
        [Key]
        [Column("PDE_ID", TypeName = "numeric(18, 0)")]
        public decimal PdeId { get; set; }
        [Column("PDE_VALOR_TOTAL", TypeName = "money")]
        public decimal? PdeValorTotal { get; set; }
        [Column("PDE_RECURSOS_MUNICIPIO", TypeName = "money")]
        public decimal? PdeRecursosMunicipio { get; set; }
        [Column("PDE_RECURSOS_DEPARTMENTO", TypeName = "money")]
        public decimal? PdeRecursosDepartmento { get; set; }
        [Column("PDE_RECURSOS_MINISTERIO", TypeName = "money")]
        public decimal? PdeRecursosMinisterio { get; set; }
        [Column("PDE_INGRESOS_PROPIOS", TypeName = "money")]
        public decimal? PdeIngresosPropios { get; set; }
        [Column("PDE_OTROS_RECURSOS", TypeName = "money")]
        public decimal? PdeOtrosRecursos { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal? ProId { get; set; }

        [Column("APT_ID", TypeName = "numeric(18, 0)")]
        public decimal? AptId { get; set; }

        [Column("PDE_DETALLE_OTROS_RECURSOS")]
        public string PdeDetalleOtrosRecursos { get; set; }

     

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

        [ForeignKey(nameof(AptId))]
        [InverseProperty(nameof(AppPresupuestoDetalleTipo.AppPresupuestoDetalle))]
        public virtual AppPresupuestoDetalleTipo Apt { get; set; }
        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppPresupuestoDetalle))]
        public virtual AppProyectos Pro { get; set; }
    }
}
