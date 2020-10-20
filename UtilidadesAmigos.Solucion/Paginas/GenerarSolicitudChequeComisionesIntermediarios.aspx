<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarSolicitudChequeComisionesIntermediarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarSolicitudChequeComisionesIntermediarios" %>
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
            width:100px;
        }
          .LetrasNegrita {
          font-weight:bold;
          }


    </style>

    <script type="text/javascript">

        function CampoFechaDesdeVacio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }

        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }

        $(document).ready(function () {

            $("#<%=btnProcesarSolicitud.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio, favor de verificar");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                return false;
            }
            });
               
        })
   
    </script>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
        <asp:Label ID="lbTituloPagina" runat="server" Text="Generar Solicitud de Cheques Intermediarios"></asp:Label>
    </div>


        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbChequeNoEndosable" runat="server" Text="No Endosable" ToolTip="Generar Solicitud No Endosable" GroupName="TipoCheque" CssClass="form-check-input LetrasNegrita" />
                <asp:RadioButton ID="rbChequeEndosable" runat="server" Text="Endosable" ToolTip="Generar Solicitud Endosable" GroupName="TipoCheque" CssClass="form-check-input LetrasNegrita" />
            </div>
              </div>
            <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbGenerarSolicidutLote" runat="server" AutoPostBack="true" OnCheckedChanged="cbGenerarSolicidutLote_CheckedChanged" Text="Generar Solicitud por lote" CssClass="form-check-input LetrasNegrita" />
                <asp:Label ID="lbLetreroSolicitudCheque" runat="server" Text="Este proceso puede durar hasta 5 Minutos o mas dependiendo de la cantidad de registros a procesar" Visible="false" CssClass="LetrasNegrita" ForeColor="Red"></asp:Label>
            </div>
        </div>
            <div class="form-row">
               
                <div class="form-group col-md-3">
                    <asp:Label ID="lbIngresarCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediario" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                 <div class="form-group col-md-9">
                    <asp:Label ID="lbNombreIntermediario" runat="server"  Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                 <div class="form-group col-md-6">
                    <asp:Label ID="lbSeleccionarBanco" runat="server" Text="Seleccionar Banco de Banco" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarBanco" runat="server" ToolTip="Seleccionar Banco" CssClass="form-control"></asp:DropDownList>
                </div>
                 <div class="form-group col-md-3">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                  <div class="form-group col-md-3">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
                  <!--BOTONES-->
                 <div align="center">
                     <asp:Button ID="btnProcesarSolicitud" runat="server" Text="Procesar" CssClass="btn btn-outline-primary btn-sm" OnClick="btnProcesarSolicitud_Click" ToolTip="Generar la solicitud de cheque" />
                 </div>
                 <!--BOTONES-->                    
    </div>
</asp:Content>
