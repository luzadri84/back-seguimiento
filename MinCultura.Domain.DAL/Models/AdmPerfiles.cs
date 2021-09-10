using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("ADM_PERFILES")]
    public partial class AdmPerfiles
    {
        [Key]
        [Column("PER_ID", TypeName = "decimal(18, 0)")]
        public decimal PerId { get; set; }
        [Column("PER_NOMBRE")]
        public string PerNombre { get; set; }
        [Column("PER_DESCRIPCION")]
        public string PerDescripcion { get; set; }
        [Column("PER_TIPO")]
        public string PerTipo { get; set; }
        [Column("PER_ESTADO")]
        public string PerEstado { get; set; }
        [Column("PER_FECHA_CREACION")]
        public DateTime PerFechaCreacion { get; set; }
        [Column("PER_FECHA_ACTUALIZACION")]
        public DateTime? PerFechaActualizacion { get; set; }
    }
}
