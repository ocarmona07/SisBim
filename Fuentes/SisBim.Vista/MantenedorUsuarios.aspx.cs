namespace SisBim.Vista
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Negocio;

    /// <summary>
    /// Clase de Mantenedor de Usuarios
    /// </summary>
    public partial class MantenedorUsuarios : Page
    {
        private readonly string _datosConexion = ConfigurationManager.ConnectionStrings["SisBimServer"].ConnectionString;
        private Dictionary<int, string> _perfiles; 

        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            #region Dicc. Perfiles

            _perfiles = new GeneralBo().ObtenerPerfilesId(_datosConexion);
            
            #endregion

            #region Obtener Usuarios

            gvUsuarios.DataSource = new UsuariosBo(_datosConexion).ObtenerUsuarios();
            gvUsuarios.DataBind();

            #endregion
        }

        /// <summary>
        /// Método que itera los items de la grilla de usuarios
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void UsuariosDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            var row = ((DataRowView)e.Row.DataItem).Row;
            var lblRut = (Label)e.Row.FindControl("lblRut");
            var lblPerfil = (Label)e.Row.FindControl("lblPerfil");
            var btnEditar = (Button)e.Row.FindControl("btnEditar");
            var btnEstado = (Button)e.Row.FindControl("btnEstado");
            
            var rutDb = row["RUT"] + "";
            var inicioRut = int.Parse(rutDb.Substring(0, rutDb.Length - 1));
            lblRut.Text = string.Format("{0:N0}-{1}", inicioRut, rutDb.Substring(rutDb.Length - 1, 1));

            lblPerfil.Text = _perfiles[int.Parse(row["IdPerfil"] + "")];

            btnEditar.Text = "<i class='icon_pencil-edit'></i>";
            btnEstado.Controls.Add(new LiteralControl("<i class='icon_pencil-edit'></i>"));
        }
    }
}