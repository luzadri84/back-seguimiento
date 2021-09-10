using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_TEMAS")]
    public partial class AppTemas
    {
        [Key]
        [Column("TEM_ID", TypeName = "Int")]
        public int TemId { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Column("LIN_ID", TypeName = "decimal(18, 0)")]
        public decimal LinId { get; set; }
    }

}
