using System;

namespace VeterinariaRemaster
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Seguridad: verificar login
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
