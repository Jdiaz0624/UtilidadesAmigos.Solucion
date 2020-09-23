<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoPorcientoComisionPorDefecto.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoPorcientoComisionPorDefecto" %>
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

        .letraNegrita {
        font-weight:bold;
            }
        .Custom{
            width: 78px;
        }
    </style>


    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Mantenimiento de Comisiones por defecto"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScripmanagerPorcientoComision" runat="server">
           
        </asp:ScriptManager>

      
        <div class="form-row">

            <div class="form-group col-md-3">
               <asp:UpdatePanel ID="UpdatePanelRamo" runat="server">
                   <ContentTemplate>
                        <asp:Label ID="lbCodigoRamoConsulta" runat="server" Text="Codigo de Ramo" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoRamoConsulta" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true"></asp:TextBox>
                   </ContentTemplate>
               </asp:UpdatePanel>
            </div>
             <div class="form-group col-md-3">
                <asp:Label ID="lbDescripcionRamoConsulta" runat="server" Text="Descripción de Ramo" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtDescripcionRamoConsulta" Enabled="false" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>

              <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSubramoConsulta" runat="server" Text="Codigo de SubRamo" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSubramoConsulta" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                <asp:Label ID="lbDescripcionSunramoConsulta" runat="server" Text="Descripción de SubRamo" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtDescripcionSubramoConsulta" Enabled="false" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar" CssClass="btn btn-outline-primary btn-sm Custom"/>
        </div>
        
        
        <br />
            <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvEmpleados" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdRegistro" HeaderText="ID" />
                    <asp:BoundField DataField="CodRamo" HeaderText="CodRamo" />
                    <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
                    <asp:BoundField DataField="CodSubramo" HeaderText="CodSubramo" />
                    <asp:BoundField DataField="Subramo" HeaderText="SubRamo" />
                    <asp:BoundField DataField="PorcientoComision" HeaderText="% de Comisión" />
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
    </div>
</asp:Content>
