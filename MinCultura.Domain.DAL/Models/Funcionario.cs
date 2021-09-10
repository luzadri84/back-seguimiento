using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("FUNCIONARIO", Schema = "Seguridad")]
    public partial class Funcionario
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TIPOIDENTIFICACIONID")]
        public short Tipoidentificacionid { get; set; }
        [Required]
        [Column("NUMEROID")]
        [StringLength(20)]
        public string Numeroid { get; set; }
        [Column("PRIMERNOMBRE")]
        [StringLength(2000)]
        public string Primernombre { get; set; }
        [Column("SEGUNDONOMBRE")]
        [StringLength(50)]
        public string Segundonombre { get; set; }
        [Required]
        [Column("PRIMERAPELLIDO")]
        [StringLength(50)]
        public string Primerapellido { get; set; }
        [Column("SEGUNDOAPELLIDO")]
        [StringLength(50)]
        public string Segundoapellido { get; set; }
        [Required]
        [Column("GENERO")]
        [StringLength(1)]
        public string Genero { get; set; }
        [Column("NOMBRECOMPLETO")]
        [StringLength(2000)]
        public string Nombrecompleto { get; set; }
    }
}
