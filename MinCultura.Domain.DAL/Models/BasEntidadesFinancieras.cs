using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("BAS_ENTIDADES_FINANCIERAS")]
    public partial class BasEntidadesFinancieras
    {
        public BasEntidadesFinancieras()
        {
            AppProyectos = new HashSet<AppProyectos>();
        }

        [Key]
        [Column("ENT_ID", TypeName = "decimal(18, 0)")]
        public decimal EntId { get; set; }
        [Column("ENT_NOMBRE")]
        [StringLength(100)]
        public string EntNombre { get; set; }
        [Column("ENT_VISIBLE")]
        [StringLength(1)]
        public string EntVisible { get; set; }
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

        [InverseProperty("Ent")]
        public virtual ICollection<AppProyectos> AppProyectos { get; set; }
    }
}
