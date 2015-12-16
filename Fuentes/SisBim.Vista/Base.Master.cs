namespace SisBim.Vista
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Clase para Master Page
    /// </summary>
    public partial class Base : MasterPage
    {
        /// <summary>
        /// Método que se llama al iniciar la vista
        /// </summary>
        /// <param name="sender">Objeto del evento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["RutUsuario"] + "") ||
                string.IsNullOrEmpty(Session["NombreUsuario"] + "") ||
                string.IsNullOrEmpty(Session["Perfil"] + ""))
            {
                Response.Redirect("Index.aspx", true);
            }

            lblUsername.Text = Session["NombreUsuario"] + "";
        }
    }
}