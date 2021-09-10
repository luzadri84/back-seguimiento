using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_DETALLE_TIPOS_ENTIDADES")]
    public partial class AppDetalleTiposEntidades
    {
        public AppDetalleTiposEntidades()
        {
            AppTipoEntidadUsuario = new HashSet<AppTipoEntidadUsuario>();
        }

        [Key]
        [Column("DET_ID")]
        public int DetId { get; set; }
        [Column("TIP_ID")]
        public int TipId { get; set; }
        [Required]
        [Column("DET_NOMBRE")]
        [StringLength(200)]
        public string DetNombre { get; set; }
        [Column("DET_NUMERO_PROYECTOS")]
        public short? DetNumeroProyectos { get; set; }
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

        [ForeignKey(nameof(TipId))]
        [InverseProperty(nameof(AppTiposEntidades.AppDetalleTiposEntidades))]
        public virtual AppTiposEntidades Tip { get; set; }
        [InverseProperty("IdDetalleTipoEntidadNavigation")]
        public virtual ICollection<AppTipoEntidadUsuario> AppTipoEntidadUsuario { get; set; }
    }
}
