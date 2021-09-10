using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_VALORES_INDICADOR")]
    public partial class AppValoresIndicador
    {
        [Key]
        [Column("VI_ID", TypeName = "decimal(18, 0)")]
        public decimal ViId { get; set; }
        [Column("IL_ID", TypeName = "numeric(18, 0)")]
        public decimal IlId { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }
        [Column("VAL_VALOR", TypeName = "decimal(33, 15)")]
        public decimal? ValValor { get; set; }
        [Column("VAL_VALOR_TEXTO")]
        public string ValValorTexto { get; set; }
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
        [InverseProperty(nameof(AppProyectos.AppValoresIndicador))]
        public virtual AppProyectos Pro { get; set; }
    }
}
