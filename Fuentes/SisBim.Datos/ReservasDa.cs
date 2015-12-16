namespace SisBim.Datos
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Entidades;

    /// <summary>
    /// Clase de datos de Reservas
    /// </summary>
    public class ReservasDa
    {
        /// <summary>
        /// Iniciación de conexión
        /// </summary>
        private readonly SqlConnection _conexion;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="strConexion">Cadena de conexión</param>
        public ReservasDa(string strConexion)
        {
            if (_conexion == null & !string.IsNullOrEmpty(strConexion))
            {
                _conexion = new SqlConnection(strConexion);
            }
        }

        /// <summary>
        /// Descripción del error
        /// </summary>
        public string Error { get; private set; }

        /// <summary>
        /// Método que almacena una reserva
        /// </summary>
        /// <param name="reserva">Datos de la reserva</param>
        /// <returns>Confirmación del almacenamiento</returns>
        public bool InsertarReserva(Reservas reserva)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "InsertarReserva";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Parameters.Add("@IdSala", SqlDbType.Int).Value = reserva.IdSala;
                comandoSql.Parameters.Add("@RutUsuario", SqlDbType.VarChar, 9).Value = reserva.RUT;
                comandoSql.Parameters.Add("@NombreCliente", SqlDbType.VarChar, 50).Value = reserva.NombreCliente;
                comandoSql.Parameters.Add("@FechaReserva", SqlDbType.Date).Value = reserva.FechaReserva;
                comandoSql.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = reserva.HoraInicio;
                comandoSql.Parameters.Add("@HoraFin", SqlDbType.Time).Value = reserva.HoraFin;
                comandoSql.Parameters.Add("@EsPrivado", SqlDbType.Bit).Value = reserva.EsPrivado;
                comandoSql.Parameters.Add("@Pagado", SqlDbType.Bit).Value = reserva.Pagado;
                comandoSql.Parameters.Add("@FirmaActa", SqlDbType.Bit).Value = reserva.FirmaActa;
                comandoSql.Parameters.Add("@Estado", SqlDbType.Bit).Value = reserva.Estado;

                comandoSql.Connection.Open();
                if (comandoSql.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    Error = "Error al insertar el registro";
                    return false;
                }
            }
            catch (Exception eException)
            {
                Error = eException.Message;
                return false;
            }
            finally
            {
                comandoSql.Connection.Close();
                comandoSql.Dispose();
            }
        }

        /// <summary>
        /// Método que actualiza los datos de una reserva
        /// </summary>
        /// <param name="reserva">Datos de la reserva</param>
        /// <returns>Confirmación de la actualización</returns>
        public bool ActualizarReserva(Reservas reserva)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ActualizarReserva";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Parameters.Add("@IdReserva", SqlDbType.Int).Value = reserva.IdReserva;
                comandoSql.Parameters.Add("@IdSala", SqlDbType.Int).Value = reserva.IdSala;
                comandoSql.Parameters.Add("@RutUsuario", SqlDbType.VarChar, 9).Value = reserva.RUT;
                comandoSql.Parameters.Add("@NombreCliente", SqlDbType.VarChar, 50).Value = reserva.NombreCliente;
                comandoSql.Parameters.Add("@FechaReserva", SqlDbType.Date).Value = reserva.FechaReserva;
                comandoSql.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = reserva.HoraInicio;
                comandoSql.Parameters.Add("@HoraFin", SqlDbType.Time).Value = reserva.HoraFin;
                comandoSql.Parameters.Add("@EsPrivado", SqlDbType.Bit).Value = reserva.EsPrivado;
                comandoSql.Parameters.Add("@Pagado", SqlDbType.Bit).Value = reserva.Pagado;
                comandoSql.Parameters.Add("@FirmaActa", SqlDbType.Bit).Value = reserva.FirmaActa;
                comandoSql.Parameters.Add("@Estado", SqlDbType.Bit).Value = reserva.Estado;

                comandoSql.Connection.Open();
                if (comandoSql.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    Error = "Error al actualizar el registro";
                    return false;
                }
            }
            catch (Exception eException)
            {
                Error = eException.Message;
                return false;
            }
            finally
            {
                comandoSql.Connection.Close();
                comandoSql.Dispose();
            }
        }

        /// <summary>
        /// Método que obtiene todas las reservas
        /// </summary>
        /// <returns>Tabla con las reservas</returns>
        public DataTable ObtenerReservas()
        {
            var comandoSql = new SqlCommand();
            try
            {
                var retornoDataTable = new DataTable();
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ObtenerReservas";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Connection.Open();
                retornoDataTable.Load(comandoSql.ExecuteReader());
                return retornoDataTable;
            }
            catch (Exception eException)
            {
                Error = eException.Message;
                return null;
            }
            finally
            {
                comandoSql.Connection.Close();
                comandoSql.Dispose();
            }
        }

        /// <summary>
        /// Método que obtiene los datos de una reserva por Id
        /// </summary>
        /// <param name="idReserva">Id de la reserva</param>
        /// <returns>Datos de la reserva</returns>
        public Reservas ObtenerReserva(int idReserva)
        {
            var comandoSql = new SqlCommand();
            try
            {
                var tablaReserva = new DataTable();
                var reservaRetorno = new Reservas();
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ObtenerReserva";
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.Add("@IdReserva", SqlDbType.Int).Value = idReserva;

                comandoSql.Connection.Open();
                tablaReserva.Load(comandoSql.ExecuteReader());

                foreach (DataRow datosReserva in tablaReserva.Rows)
                {
                    reservaRetorno.IdReserva = int.Parse(datosReserva["IdReserva"] + "");
                    reservaRetorno.RUT = datosReserva["RUT"] + "";
                    reservaRetorno.IdSala = int.Parse(datosReserva["IdSala"] + "");
                    reservaRetorno.NombreCliente = datosReserva["NombreCliente"] + "";
                    reservaRetorno.FechaReserva = DateTime.Parse(datosReserva["FechaReserva"] + "");
                    reservaRetorno.HoraInicio = TimeSpan.Parse(datosReserva["HoraInicio"] + "");
                    reservaRetorno.HoraFin = TimeSpan.Parse(datosReserva["HoraFin"] + "");
                    reservaRetorno.EsPrivado = true.Equals(datosReserva["EsPrivado"]);
                    reservaRetorno.Pagado = true.Equals(datosReserva["Pagado"]);
                    reservaRetorno.FirmaActa = true.Equals(datosReserva["FirmaActa"]);
                    reservaRetorno.Estado = true.Equals(datosReserva["Estado"]);
                }

                return reservaRetorno;
            }
            catch (Exception eException)
            {
                Error = eException.Message;
                return null;
            }
            finally
            {
                comandoSql.Connection.Close();
                comandoSql.Dispose();
            }
        }

        /// <summary>
        /// Método que elimina una reserva
        /// </summary>
        /// <param name="idReserva">Id de la reserva</param>
        /// <returns>Confirmación de la eliminación</returns>
        public bool EliminarSala(int idReserva)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "EliminarReserva";
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.Add("@IdReserva", SqlDbType.Int).Value = idReserva;

                comandoSql.Connection.Open();
                if (comandoSql.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    Error = "Error al eliminar el registro";
                    return false;
                }
            }
            catch (Exception eException)
            {
                Error = eException.Message;
                return false;
            }
            finally
            {
                comandoSql.Connection.Close();
                comandoSql.Dispose();
            }
        }
    }
}
