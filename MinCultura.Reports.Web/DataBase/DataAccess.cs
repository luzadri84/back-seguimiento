using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MinCultura.Reports.Web.DataBase
{
    public static class DataAccess
    {
        private static readonly string ConcertacionConnectionString = "ConcertacionConnectionString";
        private static readonly string INSERT = "INSERT INTO ADJUNTO_CORREOS (ID_ENVIO, RUTA_ADJUNTO, NOMBRE_ADJUNTO, FECHA_CREO) VALUES ({0}, '{1}', '{2}', GETDATE())";
        private static readonly string UPDATE = "UPDATE ENVIO_CORREOS SET ENVIADO = 0 WHERE ID = {0}";

        public static void SaveAdjunto(int idEnvio, string path, string name)
        {
            SqlConnection conexion = null;
            try
            {
                using (conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConcertacionConnectionString].ConnectionString))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(string.Format(INSERT, idEnvio, path, name), conexion);
                    comando.ExecuteNonQuery();
                    comando = new SqlCommand(string.Format(UPDATE, idEnvio), conexion);
                    comando.ExecuteNonQuery();
                }
            }
            catch(Exception){}
            finally
            {
                if (conexion != null)
                {
                    try
                    {
                        conexion.Close();
                    }
                    catch (Exception) { }
                }
            }

        }
    }
}