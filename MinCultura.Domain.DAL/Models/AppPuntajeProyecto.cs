using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_PUNTAJE_PROYECTO")]
    public partial class AppPuntajeProyecto
    {
        [Key]
        [Column("RAN_ID", TypeName = "numeric(18, 0)")]
        public decimal RanId { get; set; }
        [Key]
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }
        [Column("PUN_VALOR", TypeName = "numeric(18, 2)")]
        public decimal? PunValor { get; set; }
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

        [ForeignKey(nameof(RanId))]
        [InverseProperty(nameof(AppRangos.AppPuntajeProyecto))]
        public virtual AppRangos Ran { get; set; }
    }
}
