namespace SisBim.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using Datos;
    using Entidades;

    /// <summary>
    /// Clase de negocio para Usuarios
    /// </summary>
    public class UsuariosBo
    {
        /// <summary>
        /// Datos de la conexión
        /// </summary>
        private readonly string _conexion;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="strConexion">Cadena de conexión</param>
        public UsuariosBo(string strConexion)
        {
            _conexion = strConexion;
        }

        /// <summary>
        /// Método que almacena un usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Confirmación del almacenamiento</returns>
        public bool InsertarUsuario(Usuarios usuario)
        {
            return new UsuariosDa(_conexion).InsertarUsuario(usuario);
        }

        /// <summary>
        /// Método que actualiza un usuario
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        /// <returns>Confirmación de la actualización</returns>
        public bool ActualizarUsuario(Usuarios usuario)
        {
            return new UsuariosDa(_conexion).ActualizarUsuario(usuario);
        }

        /// <summary>
        /// Método que obtiene todos los usuarios
        /// </summary>
        /// <returns>Tabla de usuarios</returns>
        public DataTable ObtenerUsuarios()
        {
            return new UsuariosDa(_conexion).ObtenerUsuarios();
        }

        /// <summary>
        /// Método que obtiene los datos de un usuario por Id
        /// </summary>
        /// <param name="rutUsuario">Rut del usuario</param>
        /// <returns>Datos del usuario</returns>
        public Usuarios ObtenerUsuario(string rutUsuario)
        {
            return new UsuariosDa(_conexion).ObtenerUsuario(rutUsuario);            
        }

        /// <summary>
        /// Método que elimina un usuario
        /// </summary>
        /// <param name="rutUsuario">Rut del usuario</param>
        /// <returns>Confirmación de la eliminación</returns>
        public bool EliminarUsuario(string rutUsuario)
        {
            return new UsuariosDa(_conexion).EliminarUsuario(rutUsuario);
        }

        /// <summary>
        /// Método que valida un usuario
        /// </summary>
        /// <param name="rutUsuario">Rut del usuario</param>
        /// <param name="clave">Clave del usuario</param>
        /// <returns>Validación del usuario</returns>
        public bool ValidarAcceso(string rutUsuario, string clave)
        {
            var usuario = ObtenerUsuario(rutUsuario);
            if (usuario == null) return false;
            return clave.Equals(usuario.Clave) && usuario.Estado;
        }
    }
}
