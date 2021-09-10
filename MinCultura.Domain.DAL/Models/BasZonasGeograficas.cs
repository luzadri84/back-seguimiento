using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("BAS_ZONAS_GEOGRAFICAS")]
    public partial class BasZonasGeograficas
    {
        public BasZonasGeograficas()
        {
            AppProponentes = new HashSet<AppProponentes>();
        }

        [Key]
        [Column("ZON_ID")]
        [StringLength(5)]
        public string ZonId { get; set; }
        [Column("ZON_NOMBRE")]
        [StringLength(100)]
        public string ZonNombre { get; set; }
        [Column("ZON_PADRE_ID")]
        [StringLength(2)]
        public string ZonPadreId { get; set; }
        [Column("ZON_POBLACION", TypeName = "numeric(18, 0)")]
        public decimal? ZonPoblacion { get; set; }
        [Column("ZON_POBLACIONSINIC", TypeName = "numeric(18, 0)")]
        public decimal? ZonPoblacionsinic { get; set; }
        [Column("ZON_DISTRITO")]
        public byte? ZonDistrito { get; set; }
        [Column("ZON_LATITUD")]
        public double? ZonLatitud { get; set; }
        [Column("ZON_LONGITUD")]
        public double? ZonLongitud { get; set; }
        [Column("ZON_CATEGORIA")]
        [StringLength(10)]
        public string ZonCategoria { get; set; }
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

        [InverseProperty("Zon")]
        public virtual ICollection<AppProponentes> AppProponentes { get; set; }
    }
}
