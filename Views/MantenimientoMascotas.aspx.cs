using System;
using System.Linq;
using VeterinariaRemaster.Data;
using VeterinariaRemaster.Models;

namespace VeterinariaRemaster
{
    public partial class MantenimientoMascotas : System.Web.UI.Page
    {
        private readonly MascotaDAO mascotaDao = new MascotaDAO();
        private readonly PropietarioDAO propietarioDao = new PropietarioDAO();

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
                CargarPropietarios();
                CargarMascotas();
            }
        }

        private void CargarPropietarios()
        {
            var lista = propietarioDao.Listar()
                .Select(p => new
                {
                    p.ProId,
                    Nombre = p.PrimerNombre + " " + p.PrimerApellido + " (" + p.NumeroIdentificacion + ")"
                }).ToList();

            ddlPropietario.DataSource = lista;
            ddlPropietario.DataTextField = "Nombre";
            ddlPropietario.DataValueField = "ProId";
            ddlPropietario.DataBind();

            ddlPropietario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione --", ""));
        }

        private void CargarMascotas()
        {
            gvMascotas.DataSource = mascotaDao.Listar();
            gvMascotas.DataBind();
        }

        private void LimpiarCampos()
        {
            txtIdMascota.Text = "";
            txtNombreMascota.Text = "";
            txtFechaNacimiento.Text = "";
            ddlSexo.SelectedIndex = 0;
            txtPeso.Text = "";
            txtAlergias.Text = "";
            if (ddlPropietario.Items.Count > 0)
                ddlPropietario.SelectedIndex = 0;
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
                if (string.IsNullOrEmpty(ddlPropietario.SelectedValue))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Seleccione un propietario.";
                    return;
                }

                var mascota = new Mascota
                {
                    Nombre = txtNombreMascota.Text.Trim().ToUpper(),
                    FechaNacimiento = string.IsNullOrEmpty(txtFechaNacimiento.Text)
                        ? DateTime.Today
                        : DateTime.Parse(txtFechaNacimiento.Text),
                    Sexo = ddlSexo.SelectedValue,
                    Peso = decimal.TryParse(txtPeso.Text, out decimal peso) ? peso : 0,
                    Alergias = txtAlergias.Text.Trim().ToUpper(),
                    ProId = int.Parse(ddlPropietario.SelectedValue),
                    AdicionadoPor = Session["Usuario"]?.ToString() ?? "ADMIN",
                    FechaAdicion = DateTime.Now
                };

                mascotaDao.Insertar(mascota);
                CargarMascotas();
                LimpiarCampos();
                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Mascota guardada correctamente.";
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
                if (string.IsNullOrWhiteSpace(txtIdMascota.Text))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Seleccione una mascota para actualizar.";
                    return;
                }
                if (string.IsNullOrEmpty(ddlPropietario.SelectedValue))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Seleccione un propietario.";
                    return;
                }

                var mascota = new Mascota
                {
                    MasId = int.Parse(txtIdMascota.Text),
                    Nombre = txtNombreMascota.Text.Trim().ToUpper(),
                    FechaNacimiento = string.IsNullOrEmpty(txtFechaNacimiento.Text)
                        ? DateTime.Today
                        : DateTime.Parse(txtFechaNacimiento.Text),
                    Sexo = ddlSexo.SelectedValue,
                    Peso = decimal.TryParse(txtPeso.Text, out decimal peso) ? peso : 0,
                    Alergias = txtAlergias.Text.Trim().ToUpper(),
                    ProId = int.Parse(ddlPropietario.SelectedValue),
                    ModificadoPor = Session["Usuario"]?.ToString() ?? "ADMIN",
                    FechaModificacion = DateTime.Now
                };

                mascotaDao.Actualizar(mascota);
                CargarMascotas();
                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Mascota actualizada correctamente.";
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
                if (string.IsNullOrWhiteSpace(txtIdMascota.Text))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Seleccione una mascota para eliminar.";
                    return;
                }

                int id = int.Parse(txtIdMascota.Text);
                mascotaDao.Eliminar(id);
                CargarMascotas();
                LimpiarCampos();
                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Mascota eliminada correctamente.";
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

        protected void gvMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)gvMascotas.DataKeys[gvMascotas.SelectedIndex].Value;
            var mascota = mascotaDao.ObtenerPorId(id);

            if (mascota != null)
            {
                txtIdMascota.Text = mascota.MasId.ToString();
                txtNombreMascota.Text = mascota.Nombre;
                txtFechaNacimiento.Text = mascota.FechaNacimiento.ToString("yyyy-MM-dd");
                ddlSexo.SelectedValue = mascota.Sexo;
                txtPeso.Text = mascota.Peso.ToString("F2");
                txtAlergias.Text = mascota.Alergias;
                ddlPropietario.SelectedValue = mascota.ProId.ToString();
                lblMensaje.Text = "";
            }
        }
    }
}
