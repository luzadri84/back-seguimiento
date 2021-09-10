namespace MinCultura.Domain.Common.DTO
{
    public class PerfilesCuentausuarioDto
    {
        public int PerfilesCuentausuarioid { get; set; }
        public int Perfilid { get; set; }
        public int Cuentausuarioid { get; set; }
        public virtual CuentaUsuarioDto Cuentausuario { get; set; }
        public virtual PerfilDto Perfil { get; set; }
    }
}
