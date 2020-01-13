﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarCarteraIntermedirio.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarCarteraIntermedirio" %>
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
            width:90px;
        }
          .LetrasNegrita {
          font-weight:bold;
          }


    </style>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTituloCOnsulta" runat="server" Text="Generar Cartera de Intermediario"></asp:Label>

        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisorConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="5" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediario" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="5" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficinaConsulta" runat="server" ToolTip="Seleccionar la Oficina del Intermediario" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                 <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <div>
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
             <asp:Button ID="btnRestabelecer" runat="server" Text="Restablecer" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnRestabelecer_Click" />
             <button type="button" id="btnGenerarComision" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".GenerarComisionPOPO">Comisión</button>
            <button type="button" id="btnGenerarCartera" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".GenerarCarteraPOPO">Cartera</button>
            <button type="button" id="btnGenerarProduccion" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".GenerarProduccionPOPO">Producción</button>
            </div>
        <br />
           <div>
            <asp:GridView ID="gvListadoIntermediario" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoIntermediario_PageIndexChanging" OnSelectedIndexChanged="gvListadoIntermediario_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="CodSupervisor" HeaderText="CodSupervisor" />
                    <asp:BoundField DataField="Supervisor" HeaderText="Supervisor" />
                    <asp:BoundField DataField="Codigo" HeaderText="CodIntermediario" />
                    <asp:BoundField DataField="NombreVendedor" HeaderText="Intermediario" />
                    <asp:BoundField DataField="Oficina" HeaderText="Oficina" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                     <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
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
    </div>
</asp:Content>
