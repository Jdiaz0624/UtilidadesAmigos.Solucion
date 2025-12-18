<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acceso Corporativo – Futuro Seguros</title>

    <!-- Bootstrap & Fonts -->
    <link type="text/css" rel="stylesheet" href="../Content/bootstrap.min.css" />
    <script type="text/javascript" src="../scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery-3.6.0.slim.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;500&display=swap" rel="stylesheet" />

    <!-- Estilos Corporativos -->
    <style>
    body {
        font-family: 'Roboto', sans-serif;
        background: linear-gradient(135deg, #0d47a1, #1976d2);
        min-height: 100vh;
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .card {
        border-radius: 20px; /* esquinas más redondeadas */
        background: linear-gradient(180deg, #ffffff, #f9f9f9); /* fondo suave */
        box-shadow: 0 12px 30px rgba(0,0,0,0.25); /* sombra más elegante */
        max-width: 420px;
        width: 100%;
        overflow: hidden; /* suaviza bordes internos */
    }
    h4 {
        color: #0d47a1;
        font-weight: 600;
    }
    .form-control {
        border: 1px solid #ccc;
        text-align: center;
        border-radius: 10px; /* inputs también más suaves */
    }
    .form-control:focus {
        border-color: #1976d2;
        box-shadow: 0 0 10px rgba(25,118,210,0.5);
    }
    .BotonImagen {
        margin: 8px;
        width: 48px;
        height: 48px;
        transition: transform 0.2s ease-in-out;
    }
    .BotonImagen:hover {
        transform: scale(1.1);
    }
</style>


</head>
<body>
    <form id="form1" runat="server">
        <div class="card shadow-lg border-0 rounded-3">
            <div class="card-body p-5">
                <!-- Logo -->
                <div class="text-center mb-4">
                    <img src="../Imagenes/Logo.jpg" alt="Futuro Seguros" style="height:60px;" />
                </div>

                <!-- Título -->
                <h4 class="text-center mb-4">
                    <i class="fa fa-shield"></i> Utilidades – Futuro Seguros
                </h4>

                <!-- Bloque Login -->
                <div id="DivBloqueLogin" runat="server">
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" 
                                     AutoCompleteType="Disabled" placeholder="Usuario"></asp:TextBox>
                        <label class="form-label text-primary"><i class="fa fa-user-circle"></i> Usuario</label>
                    </div>

                    <div class="form-group mb-3">
                        <asp:Label ID="lbContador" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" 
                                     TextMode="Password" placeholder="Clave"></asp:TextBox>
                        <label class="form-label text-primary"><i class="fa fa-lock"></i> Clave</label>
                    </div>
                </div>

                <!-- Bloque Cambio Clave -->
                <div id="DivBloqueCambiaClave" runat="server">
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtNuevaClave" runat="server" CssClass="form-control" 
                                     TextMode="Password" placeholder="Nueva Clave"></asp:TextBox>
                        <label class="form-label text-primary"><i class="fa fa-key"></i> Nueva Clave</label>
                    </div>
                    <div class="form-group mb-3">
                        <asp:TextBox ID="txtConformacionClave" runat="server" CssClass="form-control" 
                                     TextMode="Password" placeholder="Confirmar Clave"></asp:TextBox>
                        <label class="form-label text-primary"><i class="fa fa-check-circle"></i> Confirmación</label>
                    </div>
                </div>

                <!-- Botones con imágenes -->
                <div class="text-center mt-3">
                    <asp:ImageButton ID="btnIngresarSistema" runat="server" ToolTip="Ingresar al Sistema" 
                                     CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Entrar.png" 
                                     OnClick="btnIngresarSistema_Click" />
                    <asp:ImageButton ID="btnCambioClave" runat="server" ToolTip="Cambiar Clave" 
                                     CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" 
                                     OnClick="btnCambioClave_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>