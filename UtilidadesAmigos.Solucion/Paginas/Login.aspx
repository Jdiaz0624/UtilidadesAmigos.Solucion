<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Utilidades Futuro Seguros</title>

    <link rel="icon" type="image/png" href="Recursos/Facturación-Electrónica-Icono-1024x1024.ico" />

    <link type="text/css" rel="stylesheet" href="../Content/bootstrap.min.css" />
    <script type="text/javascript" src="../scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery-3.6.0.slim.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100&display=swap" rel="stylesheet" />

    <link rel="stylesheet" href="../Content/EstilosLogin.css" />


     <script type="text/javascript">


         //MENSAJES
         function UsuarioNoValido() {
             alert("El nombre de Usuario o la clave ingresada no es valida, favor de verificar.");
         }

         function UsuarioDeshabilitado() {
             alert("El usuario actual esta deshabilitado, favor de contactar un administrador del sistema para activar la cuenta.");
         }

         $(function () {

             //VALIDAR EL BOTON INGRESAR AL SISTEMA
             $("#<%=btnIngresarSistema.ClientID%>").click(function () {
                var USuario = $("#<%=txtUsuario.ClientID%>").val().length;
                if (USuario < 1) {
                    alert("El campo usuario no puede estar vacio para ingresar al sistema, favor de verificar.");
                    $("#<%=txtUsuario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Clave = $("#<%=txtPassword.ClientID%>").val().length;
                    if (Clave < 1) {
                        alert("El campo clave no puede estar vacio para ingresar al sistema, favor de verificar.");
                        $("#<%=txtPassword.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }

            });

            $("#<%=btnCambioClave.ClientID%>").click(function () {

                var NuevaClave = $("#<%=txtNuevaClave.ClientID%>").val().length;
                if (NuevaClave < 1) {
                    alert("El campo para la nueva clave no puede estar vacio, favor de verificar.");
                    $("#<%=txtNuevaClave.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ConfirmacionClave = $("#<%=txtConformacionClave.ClientID%>").val().length;
                    if (ConfirmacionClave < 1) {
                        alert("El campo Confirmación de clave no puede estar vacio, favor de verificar.");
                        $("#<%=txtConformacionClave.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        if (NuevaClave != ConfirmacionClave) {
                            alert("las claves ingresadas no concuerdan, favor de verificar.");
                            $("#<%=txtNuevaClave.ClientID%>").css("border-color", "blue");
                            $("#<%=txtConformacionClave.ClientID%>").css("border-color", "blue");
                            document.getElementById("<%=txtNuevaClave.ClientID%>").value = "";
                            document.getElementById("<%=txtConformacionClave.ClientID%>").value = "";
                            return false;
                        }
                    }
                }
            });
        })

     </script>


</head>
<body>
   <asp:Label ID="lbCodigoUsuario" runat="server" Text="0" Visible="false"></asp:Label>
      <!-- Section: Design Block -->
<section class="text-center">
    <!-- Background image -->
    <div class="p-5 bg-image" style="
          background-image: url('https://mdbootstrap.com/img/new/textures/full/171.jpg');
          height: 300px;
          "></div>
    <!-- Background image -->
  
    <div class="card mx-4 mx-md-5 shadow-5-strong" style="
          margin-top: -100px;
          background: hsla(0, 0%, 100%, 0.8);
          backdrop-filter: blur(30px);
          ">
      <div class="card-body py-5 px-md-5">
  
        <div class="row d-flex justify-content-center">
          <div class="col-lg-8">
            <h2 class="fw-bold mb-5"><asp:Label ID="lbIdTitulo" runat="server" Text="Ingresar Datos"></asp:Label></h2>
            <form id="form1" runat="server">
              <!-- 2 column grid layout with text inputs for the first and last names -->
             <div id="DivBloqueLogin" runat="server">
                  <div class="row">
                <div class="col-md-12 mb-4 ContenidoCentro">

                    <asp:TextBox ID="txtUsuario" runat="server"  AutoCompleteType="Disabled" CssClass="form-control TextoCentrado"></asp:TextBox>
                    <label class="form-label" for="form3Example1"><b>Nombre de Usuario</b></label>
         
                </div>
                
              
              <!-- Password input -->
              <div class="form-outline mb-4 ContenidoCentro">
                  <asp:Label ID="lbContador" runat="server" Text="0" Visible="false"></asp:Label>

                  <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control TextoCentrado" TextMode="Password"></asp:TextBox>
                <label class="form-label" for="form3Example4"><b>Clave</b></label>
              </div>
            </div>
             </div>
                <div id="DivBloqueCambiaClave" runat="server">
                     <div class="row">
                <div class="col-md-12 mb-4 ContenidoCentro">

                    <asp:TextBox ID="txtNuevaClave" runat="server"  CssClass="form-control TextoCentrado" TextMode="Password"></asp:TextBox>
                    <label class="form-label" for="form3Example1"><b>Nueva Clave</b></label>
         
                </div>
                
              
              <!-- Password input -->
              <div class="form-outline mb-4 ContenidoCentro">

                  <asp:TextBox ID="txtConformacionClave" runat="server" CssClass="form-control TextoCentrado" TextMode="Password"></asp:TextBox>
                <label class="form-label" for="form3Example4"><b>Confirmacón de Clave</b></label>
              </div>
            </div>
                </div>

                <asp:ImageButton ID="btnIngresarSistema" runat="server" ToolTip="Ingresar al Sistema" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Entrar.png" OnClick="btnIngresarSistema_Click" />
                <asp:ImageButton ID="btnCambioClave" runat="server" ToolTip="Cambiar Clave" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" OnClick="btnCambioClave_Click" />
            </form>
          </div>
        </div>
      </div>
    </div>
  </section>
  <!-- Section: Design Block -->
</body>
</html>
