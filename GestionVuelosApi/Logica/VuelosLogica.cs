using GestionVuelosApi.Interfaces;
using GestionVuelosApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace GestionVuelosApi.Logica
{
    public class VuelosLogica : IVuelos
    {
        public Response RegistrarVuelo(RegistroVuelosModel registroVuelo)
        {
            Response response = new();

            var spRegistrarVuelos = "[dbo].[SP_RegistrarVuelos]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spRegistrarVuelos, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@idCiudadOrigen", registroVuelo.IdCiudadOrigen));
                command.Parameters.Add(new SqlParameter("@idCiudadDestino", registroVuelo.IdCiudadDestino));
                command.Parameters.Add(new SqlParameter("@fecha", registroVuelo.Fecha));
                command.Parameters.Add(new SqlParameter("@horaSalida", registroVuelo.HoraSalida));
                command.Parameters.Add(new SqlParameter("@horaLLegada", registroVuelo.HoraLlegada));
                command.Parameters.Add(new SqlParameter("@numeroVuelo", registroVuelo.NumeroVuelo));
                command.Parameters.Add(new SqlParameter("@idAerolinea", registroVuelo.IdAerolinea));
                command.Parameters.Add(new SqlParameter("@idEstado", registroVuelo.IdEstado));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                response.Respuesta = 200;
            }
            catch (Exception ex)
            {
                response.Respuesta = 500;
                response.Mensaje = ex.Message;
            }

            return response;
        }
        public Response EditarVuelo(RegistroVuelosModel EditarVuelo)
        {
            Response response = new();

            var spRegistrarVuelos = "[dbo].[SP_EditarVuelos]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spRegistrarVuelos, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@id", EditarVuelo.Id));
                command.Parameters.Add(new SqlParameter("@idCiudadOrigen", EditarVuelo.IdCiudadOrigen));
                command.Parameters.Add(new SqlParameter("@idCiudadDestino", EditarVuelo.IdCiudadDestino));
                command.Parameters.Add(new SqlParameter("@fecha", EditarVuelo.Fecha));
                command.Parameters.Add(new SqlParameter("@horaSalida", EditarVuelo.HoraSalida));
                command.Parameters.Add(new SqlParameter("@horaLLegada", EditarVuelo.HoraLlegada));
                command.Parameters.Add(new SqlParameter("@numeroVuelo", EditarVuelo.NumeroVuelo));
                command.Parameters.Add(new SqlParameter("@idAerolinea", EditarVuelo.IdAerolinea));
                command.Parameters.Add(new SqlParameter("@idEstado", EditarVuelo.IdEstado));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                response.Respuesta = 200;
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
                    VuelosModel vuelosModel = new();
                    vuelosModel.Id = Convert.ToInt32(reader["id"]);
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
        public Response ConsultarVuelosById(int id)
        {
            Response response = new();
            RegistroVuelosModel registroVuelosModel = new();

            var spConsultarVuelos = "[dbo].[SP_ConsultarVuelosById]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spConsultarVuelos, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@id", id));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    registroVuelosModel.IdCiudadOrigen = (int)reader["idCiudadOrigen"];
                    registroVuelosModel.IdCiudadDestino = (int)reader["idCiudadDestino"];
                    registroVuelosModel.Fecha = (DateTime)reader["fecha"];
                    registroVuelosModel.HoraSalida = reader["horaSalida"].ToString();
                    registroVuelosModel.HoraLlegada = reader["horaLLegada"].ToString();
                    registroVuelosModel.NumeroVuelo = reader["numeroVuelo"].ToString();
                    registroVuelosModel.IdAerolinea = (int)reader["idAerolinea"];
                    registroVuelosModel.IdEstado = (int)reader["idEstado"];
                }

                reader.Close();
                connection.Close();

                response.Respuesta = 200;
                response.Data = registroVuelosModel;
            }
            catch (Exception ex)
            {
                response.Respuesta = 500;
                response.Mensaje = ex.Message;
            }

            return response;
        }
        public Response ConsultarCiudades()
        {
            Response response = new();
            ListaModel ListaModel = new();
            List<ListaModel> listaCiudades = new();

            var spConsultarVuelos = "EXECUTE [dbo].[SP_ConsultarCiudades]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spConsultarVuelos, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ListaModel.Id = 0;
                ListaModel.Nombre = "-- Seleccione --";
                listaCiudades.Add(ListaModel);

                while (reader.Read())
                {
                    ListaModel = new()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString()
                    };
                    listaCiudades.Add(ListaModel);
                }

                reader.Close();
                connection.Close();

                response.Respuesta = 200;
                response.Data = listaCiudades;
            }
            catch (Exception ex)
            {
                response.Respuesta = 500;
                response.Mensaje = ex.Message;
            }

            return response;
        }
        public Response ConsultarEstados()
        {
            Response response = new();
            ListaModel ListaModel = new();
            List<ListaModel> listaCiudades = new();

            var spConsultarVuelos = "EXECUTE [dbo].[SP_ConsultarEstados]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spConsultarVuelos, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ListaModel.Id = 0;
                ListaModel.Nombre = "-- Seleccione --";
                listaCiudades.Add(ListaModel);

                while (reader.Read())
                {
                    ListaModel = new()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString()
                    };
                    listaCiudades.Add(ListaModel);
                }

                reader.Close();
                connection.Close();

                response.Respuesta = 200;
                response.Data = listaCiudades;
            }
            catch (Exception ex)
            {
                response.Respuesta = 500;
                response.Mensaje = ex.Message;
            }

            return response;
        }
        public Response ConsultarAerolineas()
        {
            Response response = new();
            ListaModel ListaModel = new();
            List<ListaModel> listaAerolineas = new();

            var spConsultarVuelos = "EXECUTE [dbo].[SP_ConsultarAerolineas]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spConsultarVuelos, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ListaModel.Id = 0;
                ListaModel.Nombre = "-- Seleccione --";
                listaAerolineas.Add(ListaModel);

                while (reader.Read())
                {
                    ListaModel = new()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString()
                    };
                    listaAerolineas.Add(ListaModel);
                }

                reader.Close();
                connection.Close();

                response.Respuesta = 200;
                response.Data = listaAerolineas;
            }
            catch (Exception ex)
            {
                response.Respuesta = 500;
                response.Mensaje = ex.Message;
            }

            return response;
        }
        public Response EliminarVuelo(int id)
        {
            Response response = new();

            var spEliminarVuelo = "[dbo].[SP_EliminarVuelos]";

            try
            {
                string ConnectionStrings = Configuration.AppSetting["ConnectionStrings:Connection"];
                using SqlConnection connection = new(ConnectionStrings);
                SqlCommand command = new(spEliminarVuelo, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@id", id));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                response.Respuesta = 200;
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
