using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_REQUISITOS")]
    public partial class AppRequisitos
    {
        public AppRequisitos()
        {
            AppEvaluacionRequisitos = new HashSet<AppEvaluacionRequisitos>();
        }

        [Key]
        [Column("REQ_ID", TypeName = "numeric(18, 0)")]
        public decimal ReqId { get; set; }
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal VigId { get; set; }
        [Required]
        [Column("REQ_NOMBRE")]
        [StringLength(4000)]
        public string ReqNombre { get; set; }
        [Column("TIP_ID")]
        public int TipId { get; set; }
        [Column("REQ_CAUSAL_RECHAZO")]
        [StringLength(1)]
        public string ReqCausalRechazo { get; set; }
        [Column("REQ_ORDEN")]
        public int? ReqOrden { get; set; }
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

        [ForeignKey(nameof(VigId))]
        [InverseProperty(nameof(AppVigencias.AppRequisitos))]
        public virtual AppVigencias Vig { get; set; }
        [InverseProperty("Req")]
        public virtual ICollection<AppEvaluacionRequisitos> AppEvaluacionRequisitos { get; set; }
    }
}
