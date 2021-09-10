using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("LOGACCIONES", Schema = "Seguridad")]
    public partial class Logacciones
    {
        [Key]
        [Column("LOGID")]
        public long Logid { get; set; }
        [Required]
        [Column("LOGTIPOACCION")]
        [StringLength(1)]
        public string Logtipoaccion { get; set; }
        [Required]
        [Column("LOGUSUARIO")]
        [StringLength(50)]
        public string Logusuario { get; set; }
        [Column("LOGFECHA", TypeName = "datetime")]
        public DateTime Logfecha { get; set; }
        [Required]
        [Column("LOGIP")]
        [StringLength(50)]
        public string Logip { get; set; }
        [Required]
        [Column("LOGKEY")]
        [StringLength(50)]
        public string Logkey { get; set; }
        [Required]
        [Column("LOGTRAZA")]
        public string Logtraza { get; set; }
    }
}
