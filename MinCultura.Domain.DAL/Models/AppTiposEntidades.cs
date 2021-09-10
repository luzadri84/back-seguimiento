using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_TIPOS_ENTIDADES")]
    public partial class AppTiposEntidades
    {
        public AppTiposEntidades()
        {
            AppDetalleTiposEntidades = new HashSet<AppDetalleTiposEntidades>();
            AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            AppProponentes = new HashSet<AppProponentes>();
            AppTipoEntidadUsuario = new HashSet<AppTipoEntidadUsuario>();
        }

        [Key]
        [Column("TIP_ID")]
        public int TipId { get; set; }
        [Required]
        [Column("TIP_NOMBRE")]
        [StringLength(200)]
        public string TipNombre { get; set; }
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal VigId { get; set; }
        [Column("TIP_TIP_ID", TypeName = "numeric(18, 0)")]
        public decimal TipTipId { get; set; }
        [Column("TIP_NUMERO_PROYECTOS")]
        public short? TipNumeroProyectos { get; set; }
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
        [Column("TIP_RECURSOS_ENTIDAD")]
        public bool TipRecursosEntidad { get; set; }

        [InverseProperty("Tip")]
        public virtual ICollection<AppDetalleTiposEntidades> AppDetalleTiposEntidades { get; set; }
        [InverseProperty("Tip")]
        public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        [InverseProperty("Tip")]
        public virtual ICollection<AppProponentes> AppProponentes { get; set; }
        [InverseProperty("IdTipoEntidadNavigation")]
        public virtual ICollection<AppTipoEntidadUsuario> AppTipoEntidadUsuario { get; set; }
    }
}
