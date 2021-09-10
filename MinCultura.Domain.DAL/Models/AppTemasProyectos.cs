using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_TEMAS_PROYECTOS")]
    public partial class AppTemasProyectos
    {

        [Key]
        [Column("ID", TypeName = "Int")]
        public int Id { get; set; }
        [Column("TEM_ID", TypeName = "Int")]
        public int TemId { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }
    }
}
