<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarBakupBD.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarBakupBD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#7BC5FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }

        .btn-sm{
            width:110px;
        }
          .LetraNegrita {
          font-weight:bold;
          }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            //VALIDAMOS EL CAMPO CLAVE DE SEGURIDAD
            $("#<%=btnValidarClaveSeguridad.ClientID%>").click(function () {
                var ClaveSeguridad = $("#<%=txtClaveSeguridad.ClientID%>").val().length;
                if (ClaveSeguridad < 1) {
                    alert("El campo clave de seguridad no puede estar vacio, favor de verificar");
                    $("#<%=txtClaveSeguridad.ClientID%>").css("border-color", "red");
                    return false;
                }
            })
        });
    </script>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTituloPagina" runat="server" Text="Generar Bakuo de Base de datos"></asp:Label>
        </div>


           
    </div>

    <div align="center">
        <div class="container">
                <div class="form-group col-md-3">
                    <asp:Label ID="lbIngresarClaveSeguridad" runat="server" Text="Ingresar Clave de Seguridad" CssClass="LetraNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridad" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
                </div>
               <asp:Button ID="btnValidarClaveSeguridad" runat="server" Text="Validar Clave" CssClass="btn btn-outline-primary btn-sm" ToolTip="Validar la clave de seguridad" />


                <div class="form-group col-md-3">
                    <asp:Label ID="lbNombreArchivo" Visible="false" runat="server" Text="Nombre de Archivo" CssClass="LetraNegrita"></asp:Label>
                <asp:TextBox ID="txtNombrearchivo" runat="server" Visible="false" CssClass="form-control" MaxLength="30"></asp:TextBox>
                </div>

            <asp:Button ID="btnProcesar" runat="server" Visible="false" Text="Procesar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Iniciar Proceso de Bakup" />
            </div>
    </div>
</asp:Content>
