using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("PLANTILLA_CORREOS")]
    public partial class PlantillaCorreos
    {
        [Key]
        [Column("CODIGOPLANTILLACORREOS")]
        [StringLength(50)]
        public string Codigoplantillacorreos { get; set; }
        [Required]
        [Column("ASUNTO")]
        [StringLength(500)]
        public string Asunto { get; set; }
        [Required]
        [Column("CUERPO")]
        public string Cuerpo { get; set; }
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
