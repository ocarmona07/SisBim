namespace SisBim.Datos
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Entidades;

    /// <summary>
    /// Clase de datos de Usuarios
    /// </summary>
    public class UsuariosDa
    {
        /// <summary>
        /// Iniciación de conexión
        /// </summary>
        private readonly SqlConnection _conexion;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="strConexion">Cadena de conexión</param>
        public UsuariosDa(string strConexion)
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
        /// Método que almacena un usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Confirmación del almacenamiento</returns>
        public bool InsertarUsuario(Usuarios usuario)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "InsertarUsuario";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Parameters.Add("@RUT", SqlDbType.VarChar, 9).Value = usuario.RUT;
                comandoSql.Parameters.Add("@Nombres", SqlDbType.VarChar, 30).Value = usuario.Nombres;
                comandoSql.Parameters.Add("@ApPaterno", SqlDbType.VarChar, 30).Value = usuario.ApellidoPaterno;
                comandoSql.Parameters.Add("@ApMaterno", SqlDbType.VarChar, 30).Value = usuario.ApellidoMaterno;
                comandoSql.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = usuario.IdPerfil;
                comandoSql.Parameters.Add("@Clave", SqlDbType.VarChar, 16).Value = usuario.Clave;
                comandoSql.Parameters.Add("@Estado", SqlDbType.Bit).Value = usuario.Estado;

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
        /// Método que actualiza los datos de un usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Confirmación de la actualización</returns>
        public bool ActualizarUsuario(Usuarios usuario)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ActualizarUsuario";
                comandoSql.CommandType = CommandType.StoredProcedure;

                comandoSql.Parameters.Add("@RUT", SqlDbType.VarChar, 9).Value = usuario.RUT;
                comandoSql.Parameters.Add("@Nombres", SqlDbType.VarChar, 30).Value = usuario.Nombres;
                comandoSql.Parameters.Add("@ApPaterno", SqlDbType.VarChar, 30).Value = usuario.ApellidoPaterno;
                comandoSql.Parameters.Add("@ApMaterno", SqlDbType.VarChar, 30).Value = usuario.ApellidoMaterno;
                comandoSql.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = usuario.IdPerfil;
                comandoSql.Parameters.Add("@Clave", SqlDbType.VarChar, 16).Value = usuario.Clave;
                comandoSql.Parameters.Add("@Estado", SqlDbType.Bit).Value = usuario.Estado;

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
        /// Método que obtiene todos los usuarios
        /// </summary>
        /// <returns>Tabla con los usuarios</returns>
        public DataTable ObtenerUsuarios()
        {
            var comandoSql = new SqlCommand();
            try
            {
                var retornoDataTable = new DataTable();
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ObtenerUsuarios";
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
        /// Método que obtiene los datos de un usuario por RUT
        /// </summary>
        /// <param name="rutUsuario">Rut del usuario</param>
        /// <returns>Datos del usuario</returns>
        public Usuarios ObtenerUsuario(string rutUsuario)
        {
            var comandoSql = new SqlCommand();
            try
            {
                var tablaUsuario = new DataTable();
                var usuarioRetorno = new Usuarios();
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "ObtenerUsuario";
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.Add("@RUT", SqlDbType.VarChar, 9).Value = rutUsuario;

                comandoSql.Connection.Open();
                tablaUsuario.Load(comandoSql.ExecuteReader());

                foreach (DataRow datosUsuario in tablaUsuario.Rows)
                {
                    usuarioRetorno.RUT = datosUsuario["RUT"] + "";
                    usuarioRetorno.Nombres = datosUsuario["Nombres"] + "";
                    usuarioRetorno.ApellidoPaterno = datosUsuario["ApellidoPaterno"] + "";
                    usuarioRetorno.ApellidoMaterno = datosUsuario["ApellidoMaterno"] + "";
                    usuarioRetorno.IdPerfil = int.Parse(datosUsuario["IdPerfil"] + "");
                    usuarioRetorno.Clave = datosUsuario["Clave"] + "";
                    usuarioRetorno.Estado = true.Equals(datosUsuario["Estado"]);
                }

                return usuarioRetorno;
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
        /// Método que elimina un Usuario
        /// </summary>
        /// <param name="rutUsuario">Rut del usuario</param>
        /// <returns>Confirmación de la eliminación</returns>
        public bool EliminarUsuario(string rutUsuario)
        {
            var comandoSql = new SqlCommand();
            try
            {
                comandoSql.Connection = _conexion;
                comandoSql.CommandText = "EliminarUsuario";
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.Add("@RUT", SqlDbType.VarChar, 9).Value = rutUsuario;

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
