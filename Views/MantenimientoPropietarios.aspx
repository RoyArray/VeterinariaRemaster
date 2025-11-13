<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoPropietarios.aspx.cs" Inherits="VeterinariaRemaster.MantenimientoPropietarios" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Mantenimiento de Propietarios</title>
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
            <h2 class="mb-3">Mantenimiento de Propietarios</h2>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mb-2 d-block"></asp:Label>

            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <div class="row mb-2">
                        <div class="col-md-2">
                            <label>ID</label>
                            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Identificación</label>
                            <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdentificacion" runat="server"
                                ControlToValidate="txtIdentificacion" ErrorMessage="Requerido"
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <label>Teléfono</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Correo</label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revCorreo" runat="server"
                                ControlToValidate="txtCorreo"
                                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                                ErrorMessage="Correo inválido" CssClass="text-danger"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-3">
                            <label>Primer Nombre</label>
                            <asp:TextBox ID="txtPrimerNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Segundo Nombre</label>
                            <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Primer Apellido</label>
                            <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Segundo Apellido</label>
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="form-control"></asp:TextBox>
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

            <asp:GridView ID="gvPropietarios" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped table-hover"
                DataKeyNames="ProId"
                OnSelectedIndexChanged="gvPropietarios_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                    <asp:BoundField DataField="ProId" HeaderText="ID" />
                    <asp:BoundField DataField="NumeroIdentificacion" HeaderText="Identificación" />
                    <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                    <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="TelefonoCelular" HeaderText="Teléfono" />
                    <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
