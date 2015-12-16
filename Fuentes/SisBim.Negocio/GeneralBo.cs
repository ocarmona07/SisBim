
using System.Data;

namespace SisBim.Negocio
{
    using System;
    using System.Collections.Generic;
    using Datos;

    public class GeneralBo
    {
        /// <summary>
        /// Retorna el copyright del sitio
        /// </summary>
        public string Copyright = "SisBim&copy; " + DateTime.Today.Year
            + " <a rel=\"nofollow\" href=\"http://www.ocrinnovaciones.cl\" target=\"_blank\">OCR innovaciones</a>";

        /// <summary>
        /// Método que valida un rut
        /// </summary>
        /// <param name="rut">RUT</param>
        /// <returns>Respuesta de validación</returns>
        public bool ValidarRut(string rut)
        {
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                var rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                var dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                return dv == (char)(s != 0 ? s + 47 : 75);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método que obtiene los Perfiles y su Id
        /// </summary>
        /// <param name="strConexion">Cadena de conexión</param>
        /// <returns>Diccionario de perfiles</returns>
        public Dictionary<int, string> ObtenerPerfilesId(string strConexion)
        {
            try
            {
                var dicRetorno = new Dictionary<int, string>();
                var perfiles = new PerfilesDa(strConexion).ObtenerPerfiles();
                foreach (DataRow perfil in perfiles.Rows)
                {
                    if (true.Equals(perfil["Estado"]))
                    {
                        dicRetorno.Add(int.Parse(perfil["IdPerfil"] + ""), perfil["NombrePerfil"] + "");
                    }
                }

                return dicRetorno;
            }
            catch (Exception)
            {
                return null;
            }
        } 
    }
}
