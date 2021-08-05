<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Redireccionamiento.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Redireccionamiento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Redireccionamiento</title>
    <link type="text/css" href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div align="center">
                <asp:Image ID="Image2" Width="70%" Height="200px" ImageUrl="~/Imagenes/LogoReducido.jpg" runat="server" />
            </div>

            <div >
                <asp:Image ID="Image3" align="left" Width="20%" ImageUrl="~/Imagenes/dd.jpg" runat="server" />
                <asp:Image ID="Image4" align="center" Width="60%" ImageUrl="~/Imagenes/Untitled.jpg" runat="server" />
                <asp:Image ID="Image1" align="right" Width="20%" ImageUrl="~/Imagenes/123541429-retrato-de-mujer-de-negocios-elegante-con-los-brazos-cruzados-aislados-ilustración-vectorial (1).jpg" runat="server" /><br />
       
                  <asp:Button ID="btnRedireccionar" Width="100%" runat="server" Text="Ir al Nuevo Sitio" CssClass="btn btn-outline-danger" OnClick="btnRedireccionar_Click" ToolTip="Ir al nuevo sitio de utilidades" />
            </div>

        
        </div>
    </form>
</body>
</html>
