namespace SisBim.Negocio
{
    using System.Data;
    using Datos;
    using Entidades;

    /// <summary>
    /// Clase de negocio para Perfiles
    /// </summary>
    public class PerfilesBo
    {
        /// <summary>
        /// Datos de la conexión
        /// </summary>
        private readonly string _conexion;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="strConexion">Cadena de conexión</param>
        public PerfilesBo(string strConexion)
        {
            _conexion = strConexion;
        }

        /// <summary>
        /// Método que almacena un perfil
        /// </summary>
        /// <param name="perfil">Datos del perfil</param>
        /// <returns>Confirmación del almacenamiento</returns>
        public bool InsertarPerfil(Perfiles perfil)
        {
            return new PerfilesDa(_conexion).InsertarPerfil(perfil);
        }

        /// <summary>
        /// Método que actualiza un perfil
        /// </summary>
        /// <param name="perfil">Datos del perfil</param>
        /// <returns>Confirmación de la actualización</returns>
        public bool ActualizarPerfil(Perfiles perfil)
        {
            return new PerfilesDa(_conexion).ActualizarPerfil(perfil);
        }

        /// <summary>
        /// Método que obtiene todos los perfiles
        /// </summary>
        /// <returns>Tabla de perfiles</returns>
        public DataTable ObtenerPerfiles()
        {
            return new PerfilesDa(_conexion).ObtenerPerfiles();
        }

        /// <summary>
        /// Método que obtiene los datos de un perfil por Id
        /// </summary>
        /// <param name="idPerfil">Id del perfil</param>
        /// <returns>Datos del perfil</returns>
        public Perfiles ObtenerPerfil(int idPerfil)
        {
            return new PerfilesDa(_conexion).ObtenerPerfil(idPerfil);            
        }

        /// <summary>
        /// Método que elimina un perfil
        /// </summary>
        /// <param name="idPerfil">Id del perfil</param>
        /// <returns>Confirmación de la eliminación</returns>
        public bool EliminarPerfil(int idPerfil)
        {
            return new PerfilesDa(_conexion).EliminarPerfil(idPerfil);
        }
    }
}