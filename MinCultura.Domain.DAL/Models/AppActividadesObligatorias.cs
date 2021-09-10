using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_ACTIVIDADES_OBLIGATORIAS")]
    public partial class AppActividadesObligatorias
    {

        public AppActividadesObligatorias()
        {
            AppProyectosActObligatorias = new HashSet<AppProyectoActividadesObligatorias>();
        }

        [Key]
        [Column("ACT_ID", TypeName = "decimal(18, 0)")]
        public decimal ActId { get; set; }

        [Column("ACT_ACTIVIDAD")]
        public string ActActividad { get; set; }

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

        [InverseProperty("ActObl")]
        public virtual ICollection<AppProyectoActividadesObligatorias> AppProyectosActObligatorias { get; set; }
    }
}

