using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_INDICADORES_LINEA")]
    public partial class AppIndicadoresLinea
    {
        [Key]
        [Column("IL_ID", TypeName = "numeric(18, 0)")]
        public decimal IlId { get; set; }
        [Column("IND_ID", TypeName = "numeric(18, 0)")]
        public decimal IndId { get; set; }
        [Column("LIN_ID", TypeName = "decimal(18, 0)")]
        public decimal LinId { get; set; }
        [Column("IND_ORDER", TypeName = "decimal(18, 0)")]
        public decimal? IndOrder { get; set; }
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

        [ForeignKey(nameof(IndId))]
        [InverseProperty(nameof(AppIndicadores.AppIndicadoresLinea))]
        public virtual AppIndicadores Ind { get; set; }
        [ForeignKey(nameof(LinId))]
        [InverseProperty(nameof(AppLineas.AppIndicadoresLinea))]
        public virtual AppLineas Lin { get; set; }
    }
}
