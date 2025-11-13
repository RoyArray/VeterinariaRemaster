using System;
using System.Linq;
using VeterinariaRemaster.Data;
using VeterinariaRemaster.Models;

namespace VeterinariaRemaster
{
    public partial class HistorialClinico : System.Web.UI.Page
    {
        private readonly PropietarioDAO propietarioDao = new PropietarioDAO();
        private readonly MascotaDAO mascotaDao = new MascotaDAO();
        private readonly HojaClinicaDAO hojaDao = new HojaClinicaDAO();

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
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                LimpiarDatosMascota();
                gvHistorial.DataSource = null;
                gvHistorial.DataBind();
                hfMasId.Value = "";

                string identificacion = txtIdentificacionProp.Text.Trim();
                string nombreMascota = txtNombreMascota.Text.Trim().ToUpper();

                if (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(nombreMascota))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Ingrese identificación del propietario y nombre de la mascota.";
                    return;
                }

                var propietario = propietarioDao.ObtenerPorIdentificacion(identificacion);
                if (propietario == null)
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "No se encontró propietario con esa identificación.";
                    return;
                }

                int? masId = mascotaDao.BuscarMascotaIdPorPropietarioYNombre(propietario.ProId, nombreMascota);
                if (masId == null)
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "No se encontró una mascota con ese nombre para el propietario indicado.";
                    return;
                }

                var mascota = mascotaDao.ObtenerPorId(masId.Value);
                if (mascota == null)
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "No se pudo cargar la información de la mascota.";
                    return;
                }

                // Mostrar datos
                hfMasId.Value = mascota.MasId.ToString();
                lblNomMascota.Text = mascota.Nombre;
                lblNomPropietario.Text = propietario.PrimerNombre + " " + propietario.PrimerApellido;
                lblPeso.Text = mascota.Peso.ToString("F2") + " kg";
                lblAlergias.Text = mascota.Alergias;

                CargarHistorial(mascota.MasId);
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al buscar: " + ex.Message;
            }
        }

        private void CargarHistorial(int masId)
        {
            var historial = hojaDao.ListarPorMascota(masId)
                                   .OrderByDescending(h => h.FechaAtencion)
                                   .ToList();

            gvHistorial.DataSource = historial;
            gvHistorial.DataBind();
        }

        private void LimpiarDatosMascota()
        {
            lblNomMascota.Text = "";
            lblNomPropietario.Text = "";
            lblPeso.Text = "";
            lblAlergias.Text = "";
        }

        protected void btnGuardarAtencion_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";

                if (string.IsNullOrEmpty(hfMasId.Value))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Debe seleccionar primero una mascota (realice una búsqueda).";
                    return;
                }

                int masId = int.Parse(hfMasId.Value);

                DateTime fechaAtencion = string.IsNullOrEmpty(txtFechaAtencion.Text)
                    ? DateTime.Today
                    : DateTime.Parse(txtFechaAtencion.Text);

                if (string.IsNullOrWhiteSpace(txtSintomas.Text) ||
                    string.IsNullOrWhiteSpace(txtDiagnostico.Text) ||
                    string.IsNullOrWhiteSpace(txtTratamiento.Text))
                {
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Text = "Complete todos los campos de la atención clínica.";
                    return;
                }

                var hoja = new HojaClinica
                {
                    MasId = masId,
                    FechaAtencion = fechaAtencion,
                    Sintomas = txtSintomas.Text.Trim().ToUpper(),
                    Diagnostico = txtDiagnostico.Text.Trim().ToUpper(),
                    Tratamiento = txtTratamiento.Text.Trim().ToUpper(),
                    AdicionadoPor = Session["Usuario"]?.ToString() ?? "ADMIN",
                    FechaAdicion = DateTime.Now
                };

                hojaDao.Insertar(hoja);
                CargarHistorial(masId);

                txtFechaAtencion.Text = "";
                txtSintomas.Text = "";
                txtDiagnostico.Text = "";
                txtTratamiento.Text = "";

                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Atención registrada correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al guardar la atención: " + ex.Message;
            }
        }
    }
}
