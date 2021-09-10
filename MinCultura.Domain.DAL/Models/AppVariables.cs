using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_VARIABLES")]
    public partial class AppVariables
    {
        public AppVariables()
        {
            AppRangos = new HashSet<AppRangos>();
        }

        [Key]
        [Column("VAR_ID", TypeName = "numeric(18, 0)")]
        public decimal VarId { get; set; }
        [Column("PUN_ID", TypeName = "numeric(18, 0)")]
        public decimal PunId { get; set; }
        [Column("LIN_ID", TypeName = "decimal(18, 0)")]
        public decimal? LinId { get; set; }
        [Column("VAR_DESCRIPCION")]
        [StringLength(5000)]
        public string VarDescripcion { get; set; }
        [Column("VAR_FORMULADO")]
        [StringLength(1)]
        public string VarFormulado { get; set; }
        [Column("VAR_OPERANDO1", TypeName = "numeric(18, 0)")]
        public decimal? VarOperando1 { get; set; }
        [Column("VAR_OPERANDO2", TypeName = "numeric(18, 0)")]
        public decimal? VarOperando2 { get; set; }
        [Column("VAR_OPERADOR")]
        [StringLength(1)]
        public string VarOperador { get; set; }
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

        //[ForeignKey(nameof(LinId))]
        //[InverseProperty(nameof(AppLineas.AppVariables))]
        public virtual AppLineas Lin { get; set; }
        [ForeignKey(nameof(PunId))]
        [InverseProperty(nameof(AppTiposPuntaje.AppVariables))]
        public virtual AppTiposPuntaje Pun { get; set; }
        [InverseProperty("Var")]
        public virtual ICollection<AppRangos> AppRangos { get; set; }
    }
}
