using System;
using VeterinariaRemaster.Data;
using VeterinariaRemaster.Models;

namespace VeterinariaRemaster
{
    public partial class MantenimientoPropietarios : System.Web.UI.Page
    {
        private readonly PropietarioDAO dao = new PropietarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                lblUsuario.Text = "Usuario: " + Session["Usuario"].ToString();
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            gvPropietarios.DataSource = dao.Listar();
            gvPropietarios.DataBind();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtIdentificacion.Text = "";
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            lblMensaje.Text = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid) return;

                var p = new Propietario
                {
                    NumeroIdentificacion = txtIdentificacion.Text.Trim().ToUpper(),
                    PrimerNombre = txtPrimerNombre.Text.Trim().ToUpper(),
                    SegundoNombre = txtSegundoNombre.Text.Trim().ToUpper(),
                    PrimerApellido = txtPrimerApellido.Text.Trim().ToUpper(),
                    SegundoApellido = txtSegundoApellido.Text.Trim().ToUpper(),
                    TelefonoCelular = txtTelefono.Text.Trim(),
                    CorreoElectronico = txtCorreo.Text.Trim(),
                    AdicionadoPor = Session["Usuario"]?.ToString() ?? "ADMIN",
                    FechaAdicion = DateTime.Now
                };

                dao.Insertar(p);
                CargarGrid();
                LimpiarCampos();
                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Propietario guardado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al guardar: " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Seleccione un propietario para actualizar.";
                    return;
                }

                var p = new Propietario
                {
                    ProId = int.Parse(txtId.Text),
                    NumeroIdentificacion = txtIdentificacion.Text.Trim().ToUpper(),
                    PrimerNombre = txtPrimerNombre.Text.Trim().ToUpper(),
                    SegundoNombre = txtSegundoNombre.Text.Trim().ToUpper(),
                    PrimerApellido = txtPrimerApellido.Text.Trim().ToUpper(),
                    SegundoApellido = txtSegundoApellido.Text.Trim().ToUpper(),
                    TelefonoCelular = txtTelefono.Text.Trim(),
                    CorreoElectronico = txtCorreo.Text.Trim(),
                    ModificadoPor = Session["Usuario"]?.ToString() ?? "ADMIN",
                    FechaModificacion = DateTime.Now
                };

                dao.Actualizar(p);
                CargarGrid();
                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Propietario actualizado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al actualizar: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Seleccione un propietario para eliminar.";
                    return;
                }

                int id = int.Parse(txtId.Text);
                dao.Eliminar(id);
                CargarGrid();
                LimpiarCampos();
                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Propietario eliminado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void gvPropietarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)gvPropietarios.DataKeys[gvPropietarios.SelectedIndex].Value;
            var p = dao.ObtenerPorId(id);

            if (p != null)
            {
                txtId.Text = p.ProId.ToString();
                txtIdentificacion.Text = p.NumeroIdentificacion;
                txtPrimerNombre.Text = p.PrimerNombre;
                txtSegundoNombre.Text = p.SegundoNombre;
                txtPrimerApellido.Text = p.PrimerApellido;
                txtSegundoApellido.Text = p.SegundoApellido;
                txtTelefono.Text = p.TelefonoCelular;
                txtCorreo.Text = p.CorreoElectronico;
                lblMensaje.Text = "";
            }
        }
    }
}
