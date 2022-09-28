using System.Data.SqlClient;

namespace GestionVuelosApi.Conexion
{
    public class ConexionDB
    {
        private readonly string ConnectionString = Configuration.AppSetting["ConnectionStrings:Connection"];

        public bool IsConnected()
        {
            try
            {
                SqlConnection connection = new(ConnectionString);
                connection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
