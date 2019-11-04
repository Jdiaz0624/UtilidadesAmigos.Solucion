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
    </style>



    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title">Validation Errors List for HP7 Citation</h4>
            </div>
            <div class="modal-body">
            </div>
            <div class="modal-footer">
                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
            </div>
        </div>
    </div>
</div>




        <div class="page-header">
  <h1 align="center" > <small>Generar Cartera Supervisor</small></h1>
            <h2 align ="center"> <small><asp:Label ID="lbNombreSupervisor" runat="server" Visible="false"></asp:Label></small></h2>
</div>
    <hr class="h-divider" />
    <main>
     

        <div class="form-row">
           <div class="container-fluid">
                <div class="form-group col-md-6">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo de Supervisor"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" PlaceHolder="Ingrese Codigo" Width="300px" CssClass="form-control" MaxLength="6" TextMode="Number"></asp:TextBox>
           
           </div>
        
                    <div class="form-check">
                        <asp:CheckBox ID="cbComicion" runat="server" AutoPostBack="true" OnCheckedChanged="cbComicion_CheckedChanged" Text="Generar Comicion" CssClass="form-check-input" />
                    </div>
               <br />
               <br />
               
           </div>
            <div class="container-fluid">
                <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" Width="200px" TextMode="Date" CssClass="form-control" Visible="false"></asp:TextBox>
                </div>
                  <div class="form-group col-md-6">
                      <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" Visible="false"></asp:Label>
                      <asp:TextBox ID="txtFechaHasta" runat="server" Width="200px" TextMode="Date" CssClass="form-control" Visible="false"></asp:TextBox>
                </div>
            </div>
            </div>
            <br />
            <br />
               <div class="container">
            <asp:Button ID="btnConsultar"  runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary" OnClick="btnConsultar_Click" />
                   <asp:Button ID="btnExportar"  runat="server" Text="Exportar" ToolTip="Exportar Registros a Exel" CssClass="btn btn-success" OnClick="btnExportar_Click" />
        </div>
            <br />
            <br />

          </div>
    </main>
   <%-- Agregamos el Grid para mostrar la data de las coberturas--%>
     <div align="center">
            <asp:GridView id="gbListadoCarteraSupervisor" runat="server" AllowPaging="True" OnPageIndexChanging="gbListadoCarteraSupervisor_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="98%" OnSelectedIndexChanged="gbListadoCarteraSupervisor_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Intermediario" HeaderText="Intermediario" ControlStyle-Width="16%" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" ControlStyle-Width="16%" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" ControlStyle-Width="20%" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" ControlStyle-Width="16%" />
                    <asp:BoundField DataField="OficinaSupervisor" HeaderText="Oficina" ControlStyle-Width="16%" />
                    <asp:CommandField ButtonType="Button" HeaderText="Detalle" SelectText="Ver" ControlStyle-CssClass="btn btn-primary" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>


        </div>

</asp:Content>
