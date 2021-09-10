using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_EVALUACION_REQUISITOS")]
    public partial class AppEvaluacionRequisitos
    {
        [Key]
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }
        [Key]
        [Column("REQ_ID", TypeName = "numeric(18, 0)")]
        public decimal ReqId { get; set; }
        [Column("PUN_VALOR")]
        [StringLength(1)]
        public string PunValor { get; set; }
        [Column("EVA_OBSERVACION")]
        [StringLength(4000)]
        public string EvaObservacion { get; set; }
        [Column("EVA_FECHA", TypeName = "datetime")]
        public DateTime? EvaFecha { get; set; }
        [Column("PUN_SOLICITUD")]
        [StringLength(1)]
        public string PunSolicitud { get; set; }
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

        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppEvaluacionRequisitos))]
        public virtual AppProyectos Pro { get; set; }
        [ForeignKey(nameof(ReqId))]
        [InverseProperty(nameof(AppRequisitos.AppEvaluacionRequisitos))]
        public virtual AppRequisitos Req { get; set; }
    }
}
