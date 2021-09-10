using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_REGISTRO_RECHAZADOS")]
    public partial class AppRegistroRechazados
    {
        [Key]
        [Column("REQ_ID", TypeName = "decimal(18, 0)")]
        public decimal ReqId { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal? ProId { get; set; }
        [Column("CAU_ID", TypeName = "decimal(18, 0)")]
        public decimal? CauId { get; set; }
        [Column("PRO_OBSERVACIONES")]
        [StringLength(2000)]
        public string ProObservaciones { get; set; }
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
        [InverseProperty(nameof(AppProyectos.AppRegistroRechazados))]
        public virtual AppProyectos Pro { get; set; }
    }
}
