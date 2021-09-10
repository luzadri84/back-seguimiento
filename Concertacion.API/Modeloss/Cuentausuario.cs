using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class Cuentausuario
    {
        public Cuentausuario()
        {
            AppUsuariosImpresion = new HashSet<AppUsuariosImpresion>();
            PerfilesCuentausuario = new HashSet<PerfilesCuentausuario>();
            PreguntaUsuario = new HashSet<PreguntaUsuario>();
        }

        public int Cuentausuarioid { get; set; }
        public decimal? Personaid { get; set; }
        public string Cuentausuariousuario { get; set; }
        public bool Cuentausuariodominio { get; set; }
        public string Cuentausuarioclave { get; set; }
        public string Cuentausuarioemail { get; set; }
        public DateTime? Cuentausuariofechaactualizacionclave { get; set; }
        public int Cuentausuarionumerointentos { get; set; }
        public string Cuentausuariohistorialclave { get; set; }
        public DateTime? Cuentausuariovencimiento { get; set; }
        public DateTime? Cuentausuarioplazoprimerlogeo { get; set; }
        public string Cuentausuariosesionid { get; set; }
        public bool Cuentausuariohabilitada { get; set; }
        public string Cuentausuariolink { get; set; }

        public virtual ICollection<AppUsuariosImpresion> AppUsuariosImpresion { get; set; }
        public virtual ICollection<PerfilesCuentausuario> PerfilesCuentausuario { get; set; }
        public virtual ICollection<PreguntaUsuario> PreguntaUsuario { get; set; }
    }
}
