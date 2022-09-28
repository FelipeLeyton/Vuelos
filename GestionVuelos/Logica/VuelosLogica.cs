using GestionVuelos.Interfaces;
using GestionVuelos.Models;
using System.Data;
using System.Data.SqlClient;

namespace GestionVuelos.Logica
{
    public class VuelosLogica : IVuelos
    {
        public Response RegistrarVuelos(RegistroVuelosModel registroVuelos)
        {
            Response response = new();

            var spRegistrarVuelos = "EXECUTE [dbo].[SP_RegistrarVuelos]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spRegistrarVuelos, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@idCiudadOrigen", registroVuelos.IdCiudadOrigen));
                command.Parameters.Add(new SqlParameter("@idCiudadDestino", registroVuelos.IdCiudadDestino));
                command.Parameters.Add(new SqlParameter("@fecha", registroVuelos.Fecha));
                command.Parameters.Add(new SqlParameter("@horaSalida", registroVuelos.HoraSalida));
                command.Parameters.Add(new SqlParameter("@horaLLegada", registroVuelos.HoraLlegada));
                command.Parameters.Add(new SqlParameter("@numeroVuelo", registroVuelos.NumeroVuelo));
                command.Parameters.Add(new SqlParameter("@idAerolinea", registroVuelos.IdAerolinea));
                command.Parameters.Add(new SqlParameter("@idEstado", registroVuelos.IdEstado));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                ConsultarVuelos();

            }
            catch (Exception ex)
            {
                response.Respuesta = 500;
                response.Mensaje = ex.Message;
            }

            return response;
        }

        public Response ConsultarVuelos()
        {
            Response response = new();
            VuelosModel vuelosModel = new();
            List<VuelosModel> vuelosModelList = new();

            var spConsultarVuelos = "EXECUTE [dbo].[SP_ConsultarVuelos]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spConsultarVuelos, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    vuelosModel.CiudadOrigen = reader["CiudadOrigen"].ToString();
                    vuelosModel.CiudadDestino = reader["CiudadDestino"].ToString();
                    vuelosModel.Fecha = Convert.ToDateTime(reader["fecha"].ToString());
                    vuelosModel.HoraSalida = reader["horaSalida"].ToString();
                    vuelosModel.HoraLlegada = reader["horaLLegada"].ToString();
                    vuelosModel.NumeroVuelo = reader["numeroVuelo"].ToString();
                    vuelosModel.Aerolinea = reader["Aerolinea"].ToString();
                    vuelosModel.Estado = reader["estado"].ToString();
                    vuelosModelList.Add(vuelosModel);
                }

                reader.Close();
                connection.Close();

                response.Respuesta = 200;
                response.Data = vuelosModelList;
            }
            catch (Exception ex)
            {
                response.Respuesta = 500;
                response.Mensaje = ex.Message;
            }

            return response;
        }
    }
}
