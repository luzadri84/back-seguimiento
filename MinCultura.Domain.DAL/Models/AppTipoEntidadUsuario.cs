using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_TIPO_ENTIDAD_USUARIO")]
    public partial class AppTipoEntidadUsuario
    {
        [Key]
        [Column("NIT")]
        [StringLength(50)]
        public string Nit { get; set; }
        [Key]
        [Column("ID_VIGENCIA", TypeName = "numeric(18, 0)")]
        public decimal IdVigencia { get; set; }
        [Column("ID_TIPO_ENTIDAD")]
        public int IdTipoEntidad { get; set; }
        [Column("ID_DETALLE_TIPO_ENTIDAD")]
        public int? IdDetalleTipoEntidad { get; set; }
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

        [ForeignKey(nameof(IdDetalleTipoEntidad))]
        [InverseProperty(nameof(AppDetalleTiposEntidades.AppTipoEntidadUsuario))]
        public virtual AppDetalleTiposEntidades IdDetalleTipoEntidadNavigation { get; set; }
        [ForeignKey(nameof(IdTipoEntidad))]
        [InverseProperty(nameof(AppTiposEntidades.AppTipoEntidadUsuario))]
        public virtual AppTiposEntidades IdTipoEntidadNavigation { get; set; }
        [ForeignKey(nameof(IdVigencia))]
        [InverseProperty(nameof(AppVigencias.AppTipoEntidadUsuario))]
        public virtual AppVigencias IdVigenciaNavigation { get; set; }
    }
}
