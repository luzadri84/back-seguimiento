using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_TIPO_PROYECTO_PROPONENTE")]
    public partial class AppTipoProyectoProponente
    {
        [Key]
        [Column("TPP_ID")]
        public int TppId { get; set; }
        [Column("TPP_NIT")]
        [StringLength(10)]
        public string TppNit { get; set; }
        [Column("TPP_TIP_ID", TypeName = "numeric(18, 0)")]
        public decimal TppTipId { get; set; }
        [Column("TPP_VALOR", TypeName = "numeric(18, 0)")]
        public decimal TppValor { get; set; }
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
    }
}
