using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_USUARIOS_IMPRESION")]
    public partial class AppUsuariosImpresion
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CUENTAUSUARIOID")]
        public int Cuentausuarioid { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }
        [Column("FECHA_IMPRESION", TypeName = "datetime")]
        public DateTime? FechaImpresion { get; set; }
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

        [ForeignKey(nameof(Cuentausuarioid))]
        [InverseProperty("AppUsuariosImpresion")]
        public virtual Cuentausuario Cuentausuario { get; set; }
        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppUsuariosImpresion))]
        public virtual AppProyectos Pro { get; set; }
    }
}
