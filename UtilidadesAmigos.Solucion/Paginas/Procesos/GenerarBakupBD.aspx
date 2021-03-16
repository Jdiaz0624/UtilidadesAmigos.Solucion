<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarBakupBD.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarBakupBD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
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


}
    </style>

    <script type="text/javascript">
        function ClaveSeguridadNoValida() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar e intente nuevamente");
        }

   

        function CampoRutaArchivoVacio() {
            alert("El campo ruta de archivo no pude estar vacio, favor de verificar");
            $("#<%=txtRutaArchivo.ClientID%>").css("border-color", "red");
        }
        function CampoExtencionArchivo() {
              alert("El campo extención de archivo no pude estar vacio, favor de verificar");
            $("#<%=txtExtencionArchivo.ClientID%>").css("border-color", "red");
        }
        function ClaveSeguridadVacia() {
              alert("El campo clave de seguridad no puede estar vacio, favor de verificar");
        }
             $(window).load(function() {
    $(".loader").fadeOut("slow");
});
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
            <asp:Label ID="lbTituloPagina" runat="server" Text="Generar Bakup de Base de datos"></asp:Label>
             <asp:Label ID="lbIdUsuario" runat="server" Visible="false" Text="Generar Bakup de Base de datos"></asp:Label>
             <asp:Label ID="lbNumeroBackup" runat="server" Visible="false" Text="Generar Bakup de Base de datos"></asp:Label>
        </div>


           
    </div>

    <div align="center">
        <div class="container">
            
                     <div class="form-group col-md-3">
                    <asp:Label ID="lbIngresarClaveSeguridad" runat="server" Text="Ingresar Clave de Seguridad" CssClass="LetraNegrita"></asp:Label>
                    <asp:TextBox ID="txtClaveSeguridad" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
                </div>
               <asp:Button ID="btnValidarClaveSeguridad" runat="server" Text="Validar Clave" CssClass="btn btn-outline-primary btn-sm" ToolTip="Validar la clave de seguridad" OnClick="btnValidarClaveSeguridad_Click" />
                
            <br />
                 <div class="form-check-inline">
                     <div class="form-group form-check">
                         <asp:RadioButton ID="rbGenerarBakup" Visible="false" runat="server" AutoPostBack="true" Text="Generar Backup" CssClass="form-check-input" ToolTip="Generar Bakup de Base de datos" GroupName="BackupDB" OnCheckedChanged="rbGenerarBakup_CheckedChanged" />
                     </div>
                      <div class="form-group form-check">
                         <asp:RadioButton ID="rbConfigurarRutaBD" Visible="false" runat="server" AutoPostBack="true" Text="Configurar Ruta" CssClass="form-check-input" ToolTip="Configurar ruta de base de datos" GroupName="BackupDB" OnCheckedChanged="rbConfigurarRutaBD_CheckedChanged" />
                     </div>
                       <div class="form-group form-check">
                         <asp:RadioButton ID="rbHistorial" runat="server" Visible="false" Text="Historial" AutoPostBack="true" CssClass="form-check-input" ToolTip="Listado de backups realizados" GroupName="BackupDB" OnCheckedChanged="rbHistorial_CheckedChanged" />
                     </div>
                 </div>
           
                <div class="form-group col-md-3">
                    <asp:Label ID="lbNombreArchivo" Visible="false" runat="server" Text="Nombre de Archivo" CssClass="LetraNegrita"></asp:Label>
                <asp:TextBox ID="txtNombrearchivo" AutoCompleteType="Disabled" runat="server" Visible="false" CssClass="form-control" MaxLength="30"></asp:TextBox>
                </div>
                 <div class="form-group col-md-6">
                     <asp:Label ID="lbRutaBakup" runat="server" Visible="false" Text="Ruta de Archivo" CssClass="LetraNegrita"></asp:Label>
                       <asp:TextBox ID="txtRutaArchivo" AutoCompleteType="Disabled" runat="server" Visible="false" CssClass="form-control" MaxLength="8000"></asp:TextBox>
                 </div>
            <div class="form-group col-md-6">
                     <asp:Label ID="lbExtencionArchivo" runat="server" Visible="false" Text="Extencion de Archivo" CssClass="LetraNegrita"></asp:Label>
                       <asp:TextBox ID="txtExtencionArchivo" AutoCompleteType="Disabled" runat="server" Visible="False" CssClass="form-control" MaxLength="10"></asp:TextBox>
                 </div>
            <!--FILTROS PARA RANGO DE FECHA-->
            <div class="form-group col-md-2">
                    <asp:Label ID="lbFechaDesde" Visible="false" runat="server" Text="Fecha Desde" CssClass="LetraNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" Visible="False" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

            <div class="form-group col-md-2">
                    <asp:Label ID="lbFechaHasta" Visible="false" runat="server" Text="Fecha Hasta" CssClass="LetraNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" runat="server" Visible="False" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                


            <asp:Button ID="btnProcesar" runat="server" Visible="false" Text="Procesar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Iniciar Proceso de Bakup" OnClick="btnProcesar_Click"/>
            </div>
    </div>
  
</asp:Content>
