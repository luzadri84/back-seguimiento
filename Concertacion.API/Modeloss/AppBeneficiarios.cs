using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppBeneficiarios
    {
        public decimal BenId { get; set; }
        public decimal? BenPersonasAsistentes { get; set; }
        public decimal? BenNumeroArtistasNacionales { get; set; }
        public decimal? BeeTotalBeneficiados { get; set; }
        public decimal? BenNumeroArtistasInternacionales { get; set; }
        public decimal? ProId { get; set; }
        public decimal? BenPersonasLogistica { get; set; }
        public string BenOtrasPersonasBeneficiadasDescripcion { get; set; }
        public string BenCaracteristicasPoblacion { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppProyectos Pro { get; set; }
    }
}
