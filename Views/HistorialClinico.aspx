<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialClinico.aspx.cs" Inherits="VeterinariaRemaster.HistorialClinico" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Historial Clínico</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand" href="Menu.aspx">Veterinaria</a>
                <span class="navbar-text text-white">
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </span>
            </div>
        </nav>

        <div class="container mt-4">
            <h2 class="mb-3">Historial Clínico</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mb-2 d-block"></asp:Label>

            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <h5>Búsqueda de Mascota</h5>
                    <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Identificación del Propietario</label>
                            <asp:TextBox ID="txtIdentificacionProp" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Nombre de la Mascota</label>
                            <asp:TextBox ID="txtNombreMascota" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 d-flex align-items-end">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary me-2"
                                OnClick="btnBuscar_Click" />
                            <asp:Button ID="btnIrMantenimientoMascotas" runat="server" Text="Ir a Mantenimiento de Mascotas"
                                CssClass="btn btn-outline-secondary" PostBackUrl="~/Views/MantenimientoMascotas.aspx" />
                        </div>
                    </div>

                    <hr />

                    <h5>Datos de la Mascota</h5>
                    <asp:HiddenField ID="hfMasId" runat="server" />

                    <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Nombre</label>
                            <asp:Label ID="lblNomMascota" runat="server" CssClass="form-control-plaintext"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <label>Propietario</label>
                            <asp:Label ID="lblNomPropietario" runat="server" CssClass="form-control-plaintext"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <label>Peso</label>
                            <asp:Label ID="lblPeso" runat="server" CssClass="form-control-plaintext"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <label>Alergias</label>
                            <asp:Label ID="lblAlergias" runat="server" CssClass="form-control-plaintext"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <h5>Historial de Atenciones</h5>
                    <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-striped table-hover">
                        <Columns>
                            <asp:BoundField DataField="FechaAtencion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Sintomas" HeaderText="Síntomas" />
                            <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
                            <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <h5>Registrar Nueva Atención</h5>

                    <div class="row mb-2">
                        <div class="col-md-3">
                            <label>Fecha de Atención</label>
                            <asp:TextBox ID="txtFechaAtencion" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-9">
                            <label>Síntomas</label>
                            <asp:TextBox ID="txtSintomas" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <label>Diagnóstico</label>
                            <asp:TextBox ID="txtDiagnostico" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Tratamiento</label>
                            <asp:TextBox ID="txtTratamiento" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="mt-3">
                        <asp:Button ID="btnGuardarAtencion" runat="server" Text="Guardar Atención"
                            CssClass="btn btn-success"
                            OnClick="btnGuardarAtencion_Click" />
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
