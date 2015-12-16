namespace SisBim.Datos
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Entidades;

    /// <summary>
    /// Clase de datos de Perfiles
    /// </summary>
    public class PerfilesDa
    {
        /// <summary>
        /// Iniciación de conexión
        /// </summary>
        private readonly SqlConnection _conexion;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="strConexion">Cadena de conexión</param>
        public PerfilesDa(string strConexion)
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
        /// Método que almacena un perfil
        /// </summary>
        /// <param name="perfil">Datos del perfil</param>
        /// <returns>Confirmación del almacenamiento</returns>
        public bool InsertarPerfil(Perfiles perfil)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "InsertarPerfil";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Parameters.Add("@NombrePerfil", SqlDbType.VarChar, 20).Value = perfil.NombrePerfil;
                comandoSql.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = perfil.Descripcion;
                comandoSql.Parameters.Add("@Estado", SqlDbType.Bit).Value = perfil.Estado;

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
        /// Método que actualiza los datos de un perfil
        /// </summary>
        /// <param name="perfil">Datos del perfil</param>
        /// <returns>Confirmación de la actualización</returns>
        public bool ActualizarPerfil(Perfiles perfil)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ActualizarPerfil";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = perfil.IdPerfil;
                comandoSql.Parameters.Add("@NombrePerfil", SqlDbType.VarChar, 20).Value = perfil.NombrePerfil;
                comandoSql.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = perfil.Descripcion;
                comandoSql.Parameters.Add("@Estado", SqlDbType.Bit).Value = perfil.Estado;

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
        /// Método que obtiene todos los perfiles
        /// </summary>
        /// <returns>Tabla con los perfiles</returns>
        public DataTable ObtenerPerfiles()
        {
            var comandoSql = new SqlCommand();
            try
            {
                var retornoDataTable = new DataTable();
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ObtenerPerfiles";
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
        /// Método que obtiene los datos de un perfil por Id
        /// </summary>
        /// <param name="idPerfil">Id del perfil</param>
        /// <returns>Datos del perfil</returns>
        public Perfiles ObtenerPerfil(int idPerfil)
        {
            var comandoSql = new SqlCommand();
            try
            {
                var tablaPerfil = new DataTable();
                var perfilRetorno = new Perfiles();
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ObtenerPerfil";
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = idPerfil;

                comandoSql.Connection.Open();
                tablaPerfil.Load(comandoSql.ExecuteReader());

                foreach (DataRow datosPerfil in tablaPerfil.Rows)
                {
                    perfilRetorno.IdPerfil = int.Parse(datosPerfil["IdPerfil"] + "");
                    perfilRetorno.NombrePerfil = datosPerfil["NombrePerfil"] + "";
                    perfilRetorno.Descripcion = datosPerfil["ApellidoPaterno"] + "";
                    perfilRetorno.Estado = true.Equals(datosPerfil["Estado"]);
                }

                return perfilRetorno;
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
        /// Método que elimina un perfil
        /// </summary>
        /// <param name="idPerfil">Id del perfil</param>
        /// <returns>Confirmación de la eliminación</returns>
        public bool EliminarPerfil(int idPerfil)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "EliminarPerfil";
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = idPerfil;

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
