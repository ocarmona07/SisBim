namespace SisBim.Vista
{
    using System;
    using System.Configuration;
    using System.Web.UI;
    using Negocio;

    /// <summary>
    /// Clase principal de entrada al sitio
    /// </summary>
    public partial class Default : Page
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            Session["RUTUsuario"] = string.Empty;
            Session["NombreUsuario"] = string.Empty;
            Session["Perfil"] = string.Empty;
            lblMensaje.Text = string.Empty;
        }

        /// <summary>
        /// Método que se llama al presionar el botón Ingresar
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Ingresar(object sender, EventArgs e)
        {
            if (new GeneralBo().ValidarRut(tbRut.Text))
            {
                var datosConexion = ConfigurationManager.ConnectionStrings["SisBimServer"].ConnectionString;
                var rutUsuario = tbRut.Text.Replace(".", "").Replace("-", "").ToUpper().Trim();
                if (new UsuariosBo(datosConexion).ValidarAcceso(rutUsuario, tbClave.Text))
                {
                    var datosUsuario = new UsuariosBo(datosConexion).ObtenerUsuario(rutUsuario);
                    Session["RutUsuario"] = datosUsuario.RUT;
                    Session["NombreUsuario"] = datosUsuario.Nombres + " " + datosUsuario.ApellidoPaterno;
                    Session["Perfil"] = datosUsuario.IdPerfil;
                    Response.Redirect("Inicio.aspx", true);
                }
                else
                    lblMensaje.Text = "RUT o Contraseña incorrecta.";
            }
            else
                lblMensaje.Text = "El RUT ingresado no es válido.";
        }
    }
}