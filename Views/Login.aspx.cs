using System;
using System.Data.SqlClient;
using System.Configuration;

namespace VeterinariaRemaster
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Session.Clear();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                lblMensaje.Text = "Ingrese usuario y contraseña.";
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["VetDB"].ConnectionString))
                {
                    cn.Open();
                    string query = @"SELECT USU_ID, USU_USUARIO, USU_ESTADO 
                                     FROM VT_USUARIOS 
                                     WHERE USU_USUARIO = @usuario AND USU_CLAVE = @clave";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", clave);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        if (dr["USU_ESTADO"].ToString() == "A")
                        {
                            Session["Usuario"] = dr["USU_USUARIO"].ToString();
                            Response.Redirect("Menu.aspx");
                        }
                        else
                        {
                            lblMensaje.Text = "Usuario inactivo.";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}
