<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VeterinariaRemaster.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login - Veterinaria</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container d-flex justify-content-center align-items-center vh-100">
            <div class="card shadow-lg p-4" style="width: 350px;">
                <h3 class="text-center mb-4 text-primary">Veterinaria</h3>
                
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger text-center d-block mb-2"></asp:Label>

                <div class="mb-3">
                    <label class="form-label">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su usuario"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese su clave"></asp:TextBox>
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
