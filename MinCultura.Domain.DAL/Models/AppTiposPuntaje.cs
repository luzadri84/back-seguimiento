using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_TIPOS_PUNTAJE")]
    public partial class AppTiposPuntaje
    {
        public AppTiposPuntaje()
        {
            AppVariables = new HashSet<AppVariables>();
        }

        [Key]
        [Column("PUN_ID", TypeName = "numeric(18, 0)")]
        public decimal PunId { get; set; }
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal VigId { get; set; }
        [Column("PUN_DESCRIPCION")]
        [StringLength(200)]
        public string PunDescripcion { get; set; }
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
        [InverseProperty(nameof(AppVigencias.AppTiposPuntaje))]
        public virtual AppVigencias Vig { get; set; }
        [InverseProperty("Pun")]
        public virtual ICollection<AppVariables> AppVariables { get; set; }
    }
}
