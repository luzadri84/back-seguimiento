namespace MinCultura.Domain.Common
{
    public class ConexionEnvioCorreo
    {
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string FromPassword { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
