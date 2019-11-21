    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarCartera.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarCartera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style type="text/css">

                      .Contenedor{
    background:#ffffff;
    padding:10px;
    overflow:hidden;
    width:500px;
}

        .messagealert {
            width: 100%;
            position: fixed;
             top:0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }

          .jumbotron{
            color:#000000; 
            background:#7BC5FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }


        .Custom{
            width: 100px;
        }
    </style>

    <!--INICIO DEL ENCABEZADO-->
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezado" runat="server" Text="Cartera de Supervisores"></asp:Label><br />
            <asp:Label ID="lbNombreSupervisor" runat="server" Visible="false"></asp:Label>
        </div>
    </div>
    <!--FIN DEL ENCABEZADO-->


    <!--INICIO DE LOS CONTROLES DE BUSQUEDA-->

     
        <div class="container-fluid">
        <div class="form-row">
                <div class="form-group col-md-2">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo de Supervisor"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" PlaceHolder="Ingrese Codigo"  CssClass="form-control" MaxLength="6" TextMode="Number"></asp:TextBox>
           
           </div>
                   </div>
              <div class="form-group form-check">
                        <div class="form-check-inline">
                        <asp:CheckBox ID="cbComicion" runat="server" AutoPostBack="true" OnCheckedChanged="cbComicion_CheckedChanged" Text="Generar Comicion" CssClass="form-check-input" />

          </div>
                  <div class="form-check-inline">
                      <asp:CheckBox ID="cbAgregarOficina" runat="server" Text="Agregar oficina" CssClass="form-check-input" Visible="false" AutoPostBack="true" OnCheckedChanged="cbAgregarOficina_CheckedChanged" />
                  </div>
          </div>

               <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" Width="200px" TextMode="Date" CssClass="form-control" Visible="false"></asp:TextBox>
                </div>
                  <div class="form-group col-md-3">
                      <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" Visible="false"></asp:Label>
                      <asp:TextBox ID="txtFechaHasta" runat="server" Width="200px" TextMode="Date" CssClass="form-control" Visible="false"></asp:TextBox>
                </div>
                 
            </div>
            <div class="form-row">
                  <div class="form-group col-md-3">
                       <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Seleccionar Oficina" Visible="false"></asp:Label>
                       <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control" Visible="false"></asp:DropDownList>
                   </div>
            </div>
          </div>

               <div class="container-fluid">
                   <asp:Button ID="btnConsultar"  runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
                   <asp:Button ID="btnExportar"  runat="server" Text="Exportar" ToolTip="Exportar Registros a Exel" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
                   <asp:Button ID="btnExportarListadoCompleto" runat="server" Text="Exportar Todo" ToolTip="Exportar todo el listado de comisiones" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportarListadoCompleto_Click" />
        </div>
    <br />
<!--FIN DE LOS CONTROLES DE BUSQUEDA-->

 <!--INICIO DEL GRID-->

   <%-- Agregamos el Grid para mostrar la data  gbListadoCarteraSupervisor de las coberturas--%>
     <div class="container-fluid">
           

           <asp:GridView id="gbListadoCarteraSupervisor" runat="server" AllowPaging="True" OnPageIndexChanging="gbListadoCarteraSupervisor_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoCarteraSupervisor_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="CodIntermediario" HeaderText="IdIntermediario" />
                    <asp:BoundField DataField="Intermediario" HeaderText="Intermediario" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección"/>
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="OficinaSupervisor" HeaderText="Oficina" />
                    <asp:CommandField ButtonType="Button" HeaderText="Cliente" SelectText="Ver" ControlStyle-CssClass="btn btn-outline-primary btn-sm Custom" ShowSelectButton="True" />
                </Columns>
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

    <!--INICIO DEL GRID PARA MOSTRAR LAS COMISIONES-->
      <div class="container-fluid">
            <asp:GridView id="gbListadoComisiones" runat="server" Visible="false" AllowPaging="True" OnPageIndexChanging="gbListadoComisiones_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbListadoComisiones_SelectedIndexChanged" OnRowDataBound="gbListadoComisiones_RowDataBound">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Intermediario" HeaderText="Vendedor" />
                    <asp:BoundField DataField="Numero" HeaderText="Factura" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina"/>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="__Comision" HeaderText="% Comisión" />
                    <asp:BoundField DataField="ComisionPagar" HeaderText="Comision Pagar" />
                </Columns>
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
    <!--FIN DEL GRID PARA MOSTRAR LAS COMISIONES-->
</asp:Content>
