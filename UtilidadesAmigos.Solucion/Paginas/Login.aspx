<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Utilidades Amigos</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" type="text/css" />
    <link rel="shortcut icon" href="../Imagenes/Iniciales.ico" />
    <script type="text/javascript" src="../JS/Utililades.js"></script>
    <style>
body{
	margin:0;
	color:#6a6f8c;
	background:url('https://i.pinimg.com/originals/49/4c/6b/494c6b914a7842e7c0e18cb68d41255e.png') no-repeat center center fixed;
    background-size:cover;
   width=100%;
	font:600 16px/18px 'Open Sans',sans-serif;
}
*,:after,:before{box-sizing:border-box}
.clearfix:after,.clearfix:before{content:'';display:table}
.clearfix:after{clear:both;display:block}
a{color:inherit;text-decoration:none}

.login-wrap{
	width:100%;
	margin:auto;
	max-width:525px;
	min-height:670px;
	position:relative;
	background:url('../Imagenes/login.jpg');
    background-position-x:center;

   
	box-shadow:0 12px 15px 0 rgba(0,0,0,.24),0 17px 50px 0 rgba(0,0,0,.19);
}
.login-html{
	width:100%;
	height:100%;
	position:absolute;
	padding:90px 70px 50px 70px;
	background:rgba(40,57,101,.9);
}
.login-html .sign-in-htm,
.login-html .sign-up-htm{
	top:0;
	left:0;
	right:0;
	bottom:0;
	position:absolute;
	transform:rotateY(180deg);
	backface-visibility:hidden;
	transition:all .4s linear;
}
.login-html .sign-in,
.login-html .sign-up,
.login-form .group .check{
	display:none;
}
.login-html .tab,
.login-form .group .label,
.login-form .group .button{
	text-transform:uppercase;
}
.login-html .tab{
	font-size:22px;
	margin-right:15px;
	padding-bottom:5px;
	margin:0 15px 10px 0;
	display:inline-block;
	border-bottom:2px solid transparent;
}
.login-html .sign-in:checked + .tab,
.login-html .sign-up:checked + .tab{
	color:#fff;
	border-color:#1161ee;
}
.login-form{
	min-height:345px;
	position:relative;
	perspective:1000px;
	transform-style:preserve-3d;
}
.login-form .group{
	margin-bottom:15px;
}
.login-form .group .label,
.login-form .group .input,
.login-form .group .button{
	width:100%;
	color:#fff;
	display:block;
}
.login-form .group .input,
.login-form .group .button{
	border:none;
	padding:15px 20px;
	border-radius:25px;
	background:rgba(255,255,255,.1);
}
.login-form .group input[data-type="password"]{
	text-security:circle;
	-webkit-text-security:circle;
}
.login-form .group .label{
	color:#aaa;
	font-size:12px;
}
.login-form .group .button{
	background:#1161ee;
}
.login-form .group label .icon{
	width:15px;
	height:15px;
	border-radius:2px;
	position:relative;
	display:inline-block;
	background:rgba(255,255,255,.1);
}
.login-form .group label .icon:before,
.login-form .group label .icon:after{
	content:'';
	width:10px;
	height:2px;
	background:#fff;
	position:absolute;
	transition:all .2s ease-in-out 0s;
}
.login-form .group label .icon:before{
	left:3px;
	width:5px;
	bottom:6px;
	transform:scale(0) rotate(0);
}
.login-form .group label .icon:after{
	top:6px;
	right:0;
	transform:scale(0) rotate(0);
}
.login-form .group .check:checked + label{
	color:#fff;
}
.login-form .group .check:checked + label .icon{
	background:#1161ee;
}
.login-form .group .check:checked + label .icon:before{
	transform:scale(1) rotate(45deg);
}
.login-form .group .check:checked + label .icon:after{
	transform:scale(1) rotate(-45deg);
}
.login-html .sign-in:checked + .tab + .sign-up + .tab + .login-form .sign-in-htm{
	transform:rotate(0);
}
.login-html .sign-up:checked + .tab + .login-form .sign-up-htm{
	transform:rotate(0);
}

.hr{
	height:2px;
	margin:60px 0 50px 0;
	background:rgba(255,255,255,.2);
}
.foot-lnk{
	text-align:center;
}
    </style>
    <script>
        function CamposVaciosLogin() {
            alert("No puedes dejar campos Vacios para Ingresar al Sistema")
        }
        function UsuarioNoValido() {
            alert("El usuario o la clave ingresada no son validos, favor de verificar")
        }
        function CamposVaciosClave() {
            alert("No puedes dejar campos vacios para cambiar la clave")
        }
        function ClavesInvalidas() {
            alert("Las claves ingresadas no concuerdan favor de verificar")
        }
        function UsuarioBloqueado() {
            alert("Este usuario se encuentra bloqueado, favor comunicarse con un administrador para desbloquear la cuenta")
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
           <div class="login-wrap">
        <div class="login-html">
            <div class="hr"></div>
               <div class="form-group form-check">
                      <div class="form-check-inline">
                           <asp:RadioButton ID="rbcolaborador" GroupName="Login" runat="server" AutoPostBack="true" CssClass="form-check-input" Text="Colaborador" OnCheckedChanged="rbcolaborador_CheckedChanged" />
                          <asp:RadioButton ID="rbSupervisor" GroupName="Login" runat="server" AutoPostBack="true" CssClass="form-check-input" Text="Supervisor" OnCheckedChanged="rbSupervisor_CheckedChanged"/>
                          <asp:RadioButton ID="rbIntermediario" GroupName="Login" runat="server" AutoPostBack="true" CssClass="form-check-input" Text="Intermediario" OnCheckedChanged="rbIntermediario_CheckedChanged"/>
                      </div>
                  </div>
          <div class="login-form">
              <div class="group">
                <asp:Label ID="lbIngresarUsuarioClave" runat="server" class="label" Text="Ingrese Nombre de Usuario y Clave"></asp:Label>
                  <asp:TextBox ID="txtUsuario"  Class="input" runat="server" MaxLength="20" Placeholder="Usuario" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="group">
                    <asp:TextBox ID="txtClave" Class="input" runat="server" placeholder="Clave" MaxLength="20" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>

                </div>
                <div class="group">
                    <asp:Button ID="btnIngresarSistema" class="button" ToolTip="Ingresar al Sistema" runat="server" Text="<%$Resources:Traducciones,Entrar %>" OnClick="btnIngresarSistema_Click" />
                  </div>
  
                <div class="hr"></div>
           
               

        
        
              <div id="CambiaClave">
                    <div class="group">
                        <asp:TextBox ID="txtNuevaClave" runat="server" placeholder="<%$Resources:Traducciones,NuevaClave %>" TextMode="Password" CssClass="input" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                     <div class="group">
                        <asp:TextBox ID="txtConfirmarClave" runat="server" placeholder="<%$Resources:Traducciones,ConfirmarClave %>" TextMode="Password" CssClass="input" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div class="group">
                        <asp:Button ID="btnCambiarClave" runat="server" Text="Cambiar Clave" ToolTip="Cambiar Clave" CssClass="button" OnClick="btnCambiarClave_Click" />
                        <asp:Label ID="lbContadorBloqueo" runat="server" Text="Contador" Visible="false"></asp:Label>
                    </div>
                </div>
          </div>
        </div>
      </div>
    </form>
</body>
</html>
