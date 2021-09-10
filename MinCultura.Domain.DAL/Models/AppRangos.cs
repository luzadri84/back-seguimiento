using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_RANGOS")]
    public partial class AppRangos
    {
        public AppRangos()
        {
            AppPuntajeProyecto = new HashSet<AppPuntajeProyecto>();
        }

        [Key]
        [Column("RAN_ID", TypeName = "numeric(18, 0)")]
        public decimal RanId { get; set; }
        [Column("VAR_ID", TypeName = "numeric(18, 0)")]
        public decimal VarId { get; set; }
        [Column("RAN_DESCRIPCION")]
        [StringLength(200)]
        public string RanDescripcion { get; set; }
        [Column("RAN_PUNTAJE_ABIERTO")]
        [StringLength(1)]
        public string RanPuntajeAbierto { get; set; }
        [Column("RAN_PUNTAJE", TypeName = "numeric(18, 0)")]
        public decimal? RanPuntaje { get; set; }
        [Column("RAN_MINIMO", TypeName = "numeric(38, 20)")]
        public decimal? RanMinimo { get; set; }
        [Column("RAN_MAXIMO", TypeName = "numeric(38, 20)")]
        public decimal? RanMaximo { get; set; }
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

        [ForeignKey(nameof(VarId))]
        [InverseProperty(nameof(AppVariables.AppRangos))]
        public virtual AppVariables Var { get; set; }
        [InverseProperty("Ran")]
        public virtual ICollection<AppPuntajeProyecto> AppPuntajeProyecto { get; set; }
    }
}
