using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_COMPONENTES")]
    public partial class AdmConfiguracion
    {
        [Column("ADM_PERFIL_SUPERVISORES", TypeName = "numeric(18, 0)")]
        public decimal? AdmPerfilSupervisores { get; set; }
    }
}
