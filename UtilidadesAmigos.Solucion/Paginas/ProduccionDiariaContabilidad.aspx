<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionDiariaContabilidad.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionDiariaContabilidad" %>
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
        function ErrorConsulta() {
            alert("Error al realizar la consulta, favor de verificar los parametros ingresados o contactar al departamento de Tecnologia");
        }
        function OpcionNoDisponible() {
            alert("la Opción de cobros esta en desarrollo en estos momentos");
        }

        function ErrorExportacionConsulta() {
            alert("Error al exportar la data, favor de verificar los parametros ingresados o contactar al departamento de tecnologia");
        }
        function ErrorExportar() {
            alert("Error al Exportar la data");
        }
        function CamposVacios() {
            alert("Has dejado campos vacios que son necesarios para realizar la consulta, favor de verificar");
        }
        function ValidarFechaDesde() {
       
        }

         function ValidarFechaHasta() {
        
        }
        function ValidarCodigoIntermediario() {
            $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
         }

        function CampoAnoVacio() {
            alert("El campo año no puede estar vaicio, favor de verificar");
            $("#<%=txtAno.ClientID%>").css("border-color", "red");
        }
    </script>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Producción Diaria (Contabilidad)"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbTipoReporte" runat="server" Text="Tipo de Reporte" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoReporte" runat="server" ToolTip="Seleccionar Tipo de Reporte" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSeleccionarTipoReporte_SelectedIndexChanged">
                    <asp:ListItem Value="1">Producción</asp:ListItem>
                    <asp:ListItem Value="2">Cobros</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
       
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarMes" runat="server" Text="Seleccionar Mes" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarMes" runat="server" ToolTip="Seleccionar el mes a validar" CssClass="form-control">
                </asp:DropDownList>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbAno" runat="server" Text="Año" CssClass="LetrasNegrita"></asp:Label>
                 <asp:TextBox ID="txtAno" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                   <asp:Label ID="lbRamo" runat="server" Text="Seleccionar Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

             

             <div class="form-group col-md-3">
                  <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="form-group col-md-3">
                   <asp:Label ID="lbLlevaIntermediario" runat="server" Text="Lleva Intermediario" CssClass="LetrasNegrita"></asp:Label>
                 <asp:DropDownList ID="ddlLlevaIntermediario" runat="server" ToolTip="Lleva Intermediario" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlLlevaIntermediario_SelectedIndexChanged">
                     <asp:ListItem Value="1">NO</asp:ListItem>
                     <asp:ListItem Value="2">SI</asp:ListItem>
                   </asp:DropDownList>
            </div>

            <div class="form-group col-md-3">
                   <asp:Label ID="lbIntermediario" Visible="false" runat="server" Text="Codigo Intermediario" CssClass="LetrasNegrita"></asp:Label>
                 <asp:TextBox ID="txtCodigoIntermediario" Visible="false" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbTodosLosIntermediarios" runat="server" Visible="false" Text="Todos los Intermediarios" AutoPostBack="true" ToolTip="Mostrar todos los intermediarios" OnCheckedChanged="cbTodosLosIntermediarios_CheckedChanged" /><br />
                <asp:Label ID="lbLetreroTodosIntermediairos" runat="server" Visible="false" Text="La consulta con todos los intermediarios puede tardar hasta 5 minutos debido a la cantidad de registros y calculos de primas." CssClass="LetrasNegrita" ForeColor="Red"></asp:Label>
            </div>
        </div>

        <!--BOTONES-->
        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExportar_Click" />
        </div>

        <br />
          <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvGridSinIntermediario" runat="server" AllowPaging="true" OnPageIndexChanging="gvGridSinIntermediario_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Descripcion" HeaderText="Ramo" />
                    <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="FacturadoMes" HeaderText="Total" />
                </Columns  >
                  <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" HorizontalAlign="Center" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
    </div>
    <!--FIN DEL GRID-->

          <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvGridConIntermediario" runat="server" AllowPaging="true" Visible="false" OnPageIndexChanging="gvGridConIntermediario_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Intermediario" HeaderText="Intermediario" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Ramo" />
                    <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="FacturadoMes" HeaderText="Total" />
                </Columns  >
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" HorizontalAlign="Center" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
    </div>
    <!--FIN DEL GRID-->
        <br />
         <div align="center">
            <asp:Label ID="lbFacturadoHoyTitulo" runat="server" Text="Facturado Hoy ( " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbFacturadoHoyVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbFacturadoHoyCerrar" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>

             <asp:Label ID="Label1" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="lbTotalDebitosTitulo" runat="server" Text="Cantidad de Debitos ( " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbCantidadDebitosVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbCantidadDebitosCerrar" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="Label2" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>

             <asp:Label ID="lbTotalCreditosTitulo" runat="server" Text="Cantidad de Creditos ( " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbTotalCretitoVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbCantidadCreditosCerrar" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>

            <br />

            <asp:Label ID="lbOtrosTitulo" runat="server" Text="Otros ( " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbOtrosVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbOtrosCerrar" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="Label3" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>

             <asp:Label ID="lbTotalTitulo" runat="server" Text="Total ( " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="LablbTotalVariableel7" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="Label8" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="Label9" runat="server" Text="," CssClass="LetrasNegrita"></asp:Label>

               <asp:Label ID="lbMesAnteriorTitulo" runat="server" Text="Total Mes Anterior ( " CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbMesAnteriorvariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="Label4" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>


        </div>
    </div>
</asp:Content>
