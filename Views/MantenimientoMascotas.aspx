<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoMascotas.aspx.cs" Inherits="VeterinariaRemaster.MantenimientoMascotas" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Mantenimiento de Mascotas</title>
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
            <h2 class="mb-3">Mantenimiento de Mascotas</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mb-2 d-block"></asp:Label>

            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <div class="row mb-2">
                        <div class="col-md-2">
                            <label>ID</label>
                            <asp:TextBox ID="txtIdMascota" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Nombre</label>
                            <asp:TextBox ID="txtNombreMascota" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombreMascota" runat="server"
                                ControlToValidate="txtNombreMascota" ErrorMessage="Requerido"
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <label>Fecha Nacimiento</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Sexo</label>
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-select">
                                <asp:ListItem Text="-- Seleccione --" Value=""></asp:ListItem>
                                <asp:ListItem Text="Macho" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Hembra" Value="F"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-3">
                            <label>Peso (kg)</label>
                            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <label>Alergias</label>
                            <asp:TextBox ID="txtAlergias" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Propietario</label>
                            <asp:DropDownList ID="ddlPropietario" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="mt-3">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-secondary me-2"
                            OnClick="btnNuevo_Click" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary me-2"
                            OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-warning me-2"
                            OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger me-2"
                            OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-outline-secondary"
                            OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>

            <asp:GridView ID="gvMascotas" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped table-hover"
                DataKeyNames="MasId"
                OnSelectedIndexChanged="gvMascotas_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                    <asp:BoundField DataField="MasId" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nac." DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="Peso" HeaderText="Peso" DataFormatString="{0:F2}" />
                    <asp:BoundField DataField="Alergias" HeaderText="Alergias" />
                    <asp:BoundField DataField="ProId" HeaderText="ID Propietario" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
