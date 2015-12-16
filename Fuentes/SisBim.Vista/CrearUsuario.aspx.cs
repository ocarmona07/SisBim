
namespace SisBim.Vista
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Negocio;
    using Entidades;

    /// <summary>
    /// Clase que crea o modifica un usuario
    /// </summary>
    public partial class CrearUsuario : Page
    {
        private readonly string _datosConexion = ConfigurationManager.ConnectionStrings["SisBimServer"].ConnectionString;

        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ddlPerfil.DataSource = new PerfilesBo(_datosConexion).ObtenerPerfiles();
            ddlPerfil.DataTextField = "NombrePerfil";
            ddlPerfil.DataValueField = "IdPerfil";
            ddlPerfil.DataBind();

            lblCrearUsuario.Text = "Crear Usuario";
            lblTituloPanel.Text = "Crear Usuario";

            if (!string.IsNullOrEmpty(Request.QueryString["RUT"]))
            {
                lblCrearUsuario.Text = "Modificar Usuario";
                lblTituloPanel.Text = "RUT Usuario: " + Request.QueryString["RUT"];
                CargarControles(new UsuariosBo(_datosConexion).ObtenerUsuario(Request.QueryString["RUT"]));
            }
        }

        /// <summary>
        /// Método que almacena/modifica los datos del usuario
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void GuardarUsuario(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btnGuardar.CommandArgument))
            {
                if (new UsuariosBo(_datosConexion).InsertarUsuario(LlenarObjUsuarios()))
                {
                    // Confirmación OK
                }
            }
            else
            {
                var modUsuario = LlenarObjUsuarios();
                modUsuario.RUT = btnGuardar.CommandArgument;
                if (new UsuariosBo(_datosConexion).ActualizarUsuario(modUsuario))
                {
                    // Confirmación OK
                }
            }
        }

        /// <summary>
        /// Método que carga los controles según el usuario a modificar
        /// </summary>
        /// <param name="usuario">Datos del usuario</param>
        private void CargarControles(Usuarios usuario)
        {
            tbNombres.Text = usuario.Nombres;
            tbApPaterno.Text = usuario.ApellidoPaterno;
            tbApMaterno.Text = usuario.ApellidoMaterno;
            ddlPerfil.SelectedValue = usuario.IdPerfil.ToString();
            chkEstado.Checked = usuario.Estado;
            btnGuardar.CommandArgument = usuario.RUT;
        }

        /// <summary>
        /// Método que obtiene los campos de los controles del formulario y retorna un objeto Usuario
        /// </summary>
        /// <returns>Usuario</returns>
        private Usuarios LlenarObjUsuarios()
        {
            var usuario = new Usuarios();
            usuario.Nombres = tbNombres.Text;
            usuario.ApellidoPaterno = tbApPaterno.Text;
            usuario.ApellidoMaterno = tbApMaterno.Text;
            usuario.IdPerfil = int.Parse(ddlPerfil.SelectedValue);
            usuario.Clave = "1234";
            usuario.Estado = chkEstado.Checked;
            return usuario;
        }
    }
}