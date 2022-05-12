<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="EliminarBalancePoliza.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.EliminarBalancePoliza" %>
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
            text-align:center;
            padding:25px;
        }
          .btn-sm{
            width:90px;
        }
    </style>
    <div class="container-fluid">
        <div class="jumbotron">
            <asp:Label ID="lbEliminarBalance" runat="server" Text="Eliminar Balance Poliza"></asp:Label>
    </div>
        <br />
    <!--COLOCAMOS LOS RADIOS -->
        <div class="form-check-inline">
            <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGenerarTodo" runat="server" GroupName="Data" Text="Generar Todo" ToolTip="Generar Toda la data ingresada en la data" CssClass="form-check-input"></asp:RadioButton>
            </div>
            <div class="form-group form-check">
                <asp:RadioButton ID="rbGenerarPolizaEspesifica" runat="server" GroupName="Data" Text="Generar Mediante Filtro" ToolTip="Eliminar Balance filtrando mediante la poliza" CssClass="form-check-input"></asp:RadioButton>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbPoliza" Text="Poliza" runat="server"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Buscar registros" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Procesar registros" />
        </div>

        <!--COLOCAMOS EL GRID-->
         <asp:GridView id="gbPolizasGuardadas" runat="server" AllowPaging="True" OnPageIndexChanging="gbPolizasGuardadas_PageIndexChanging" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" OnSelectedIndexChanged="gbPolizasGuardadas_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance" />
                    <asp:CommandField ButtonType="Button" HeaderText="Detalle" SelectText="Ver" ControlStyle-CssClass="btn btn-outline-primary btn-sm" ShowSelectButton="True" />
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
</asp:Content>
