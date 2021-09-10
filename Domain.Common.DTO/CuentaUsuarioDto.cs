using System;
using System.Collections.Generic;

namespace MinCultura.Domain.Common.DTO
{
    public class CuentaUsuarioDto
    {
        public int Cuentausuarioid { get; set; }
        public decimal? Personaid { get; set; }
        public string Cuentausuariousuario { get; set; }
        public bool Cuentausuariodominio { get; set; }
        public string Cuentausuarioemail { get; set; }
        public string Cuentausuarioemailnuevo { get; set; }
        public string Cuentausuarioemailnuevoconf { get; set; }
        public DateTime? Cuentausuariofechaactualizacionclave { get; set; }
        public int Cuentausuarionumerointentos { get; set; }
        public string Cuentausuariohistorialclave { get; set; }
        public DateTime? Cuentausuariovencimiento { get; set; }
        public DateTime? Cuentausuarioplazoprimerlogeo { get; set; }
        public string Cuentausuariosesionid { get; set; }
        public bool Cuentausuariohabilitada { get; set; }
        public string Cuentausuariolink { get; set; }
        public virtual ICollection<PerfilesCuentausuarioDto> PerfilesCuentausuario { get; set; }
    }
}
