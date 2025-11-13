<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="VeterinariaRemaster.Menu" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Menú Principal - Veterinaria</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">

    <form id="form1" runat="server">
        <!-- Barra superior -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Veterinaria</a>

                <div class="d-flex">
                    <span class="navbar-text text-white me-3">
                        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    </span>
                    <asp:Button ID="btnSalir" runat="server" CssClass="btn btn-outline-light btn-sm"
                        Text="Salir" OnClick="btnSalir_Click" />
                </div>
            </div>
        </nav>

        <!-- Contenido principal -->
        <div class="container mt-5">

            <h2 class="mb-4 text-center text-primary">Menú Principal</h2>

            <div class="row g-4">

                <!-- Propietarios -->
                <div class="col-md-4">
                    <div class="card shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title text-primary">Propietarios</h5>
                            <p class="card-text">Administración de propietarios registrados.</p>
                            <asp:HyperLink ID="lnkPropietarios" runat="server"
                                NavigateUrl="~/Views/MantenimientoPropietarios.aspx"
                                CssClass="btn btn-primary">Ir al módulo</asp:HyperLink>
                        </div>
                    </div>
                </div>

                <!-- Mascotas -->
                <div class="col-md-4">
                    <div class="card shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title text-primary">Mascotas</h5>
                            <p class="card-text">Administración de mascotas.</p>
                            <asp:HyperLink ID="lnkMascotas" runat="server"
                                NavigateUrl="~/Views/MantenimientoMascotas.aspx"
                                CssClass="btn btn-primary">Ir al módulo</asp:HyperLink>
                        </div>
                    </div>
                </div>

                <!-- Historial Clínico -->
                <div class="col-md-4">
                    <div class="card shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title text-primary">Historial Clínico</h5>
                            <p class="card-text">Consultar y registrar atenciones clínicas.</p>
                            <asp:HyperLink ID="lnkHistorial" runat="server"
                                NavigateUrl="~/Views/HistorialClinico.aspx"
                                CssClass="btn btn-primary">Ir al módulo</asp:HyperLink>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </form>

</body>
</html>

