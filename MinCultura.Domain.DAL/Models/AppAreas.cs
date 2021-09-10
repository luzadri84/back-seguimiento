using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_AREAS")]
    public partial class AppAreas
    {
        [Key]
        [Column("ARE_ID", TypeName = "decimal(18, 0)")]
        public decimal AreId { get; set; }
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal? VigId { get; set; }
        [Column("ARE_NOMBRE")]
        [StringLength(500)]
        public string AreNombre { get; set; }
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
        [InverseProperty(nameof(AppVigencias.AppAreas))]
        public virtual AppVigencias Vig { get; set; }

    }
}
