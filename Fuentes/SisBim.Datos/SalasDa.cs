namespace SisBim.Datos
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Entidades;

    /// <summary>
    /// Clase de datos de Salas
    /// </summary>
    public class SalasDa
    {
        /// <summary>
        /// Iniciación de conexión
        /// </summary>
        private readonly SqlConnection _conexion;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="strConexion">Cadena de conexión</param>
        public SalasDa(string strConexion)
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
        /// Método que almacena una sala
        /// </summary>
        /// <param name="sala">Datos de la sala</param>
        /// <returns>Confirmación del almacenamiento</returns>
        public bool InsertarSala(Salas sala)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "InsertarSala";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Parameters.Add("@NombreSala", SqlDbType.VarChar, 30).Value = sala.NombreSala;
                comandoSql.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = sala.Descripcion;
                comandoSql.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = sala.Imagen;
                comandoSql.Parameters.Add("@Detalles", SqlDbType.VarChar).Value = sala.Detalles;
                comandoSql.Parameters.Add("@Estado", SqlDbType.Bit).Value = sala.Estado;

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
        /// Método que actualiza los datos de una sala
        /// </summary>
        /// <param name="sala">Datos de la sala</param>
        /// <returns>Confirmación de la actualización</returns>
        public bool ActualizarSala(Salas sala)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ActualizarSala";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Parameters.Add("@IdSala", SqlDbType.Int).Value = sala.IdSala;
                comandoSql.Parameters.Add("@NombreSala", SqlDbType.VarChar, 30).Value = sala.NombreSala;
                comandoSql.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = sala.Descripcion;
                comandoSql.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = sala.Imagen;
                comandoSql.Parameters.Add("@Detalles", SqlDbType.VarChar).Value = sala.Detalles;
                comandoSql.Parameters.Add("@Estado", SqlDbType.Bit).Value = sala.Estado;

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
        /// Método que obtiene todas las salas
        /// </summary>
        /// <returns>Tabla con las sala</returns>
        public DataTable ObtenerSalas()
        {
            var comandoSql = new SqlCommand();
            try
            {
                var retornoDataTable = new DataTable();
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ObtenerSalas";
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
        /// Método que obtiene los datos de una sala por Id
        /// </summary>
        /// <param name="idSala">Id de la sala</param>
        /// <returns>Datos de la sala</returns>
        public Salas ObtenerSala(int idSala)
        {
            var comandoSql = new SqlCommand();
            try
            {
                var tablaSala = new DataTable();
                var salaRetorno = new Salas();
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ObtenerPerfil";
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.Add("@IdSala", SqlDbType.Int).Value = idSala;

                comandoSql.Connection.Open();
                tablaSala.Load(comandoSql.ExecuteReader());

                foreach (DataRow datosSala in tablaSala.Rows)
                {
                    salaRetorno.IdSala = int.Parse(datosSala["IdSala"] + "");
                    salaRetorno.NombreSala = datosSala["NombreSala"] + "";
                    salaRetorno.Descripcion = datosSala["Descripcion"] + "";
                    salaRetorno.Imagen = datosSala["Imagen"] + "";
                    salaRetorno.Detalles = datosSala["Detalles"] + "";
                    salaRetorno.Estado = true.Equals(datosSala["Estado"]);
                }

                return salaRetorno;
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
        /// Método que elimina una sala
        /// </summary>
        /// <param name="idSala">Id de la sala</param>
        /// <returns>Confirmación de la eliminación</returns>
        public bool EliminarSala(int idSala)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "EliminarSala";
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.Add("@IdSala", SqlDbType.Int).Value = idSala;

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
