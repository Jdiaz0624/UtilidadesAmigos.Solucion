﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ComisionesSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ComisionesSupervisores" %>
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
            <asp:Label ID="lbComisionSupervisorsTitulo" runat="server" Text="Generar Comisiones de Supervisores"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbFechaHastaConsulta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSupervisorConsulta" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisorConsulta" runat="server" CssClass="form-control" TextMode="Number" MaxLength="4"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="ldSeleccionarSucursalConsulta" runat="server" Text="Seleccionar Sucursal" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSucursalConsulta" runat="server" ToolTip="Seleccionar Sucursal" CssClass="form-control"></asp:DropDownList>
            </div>
             <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarOficinaConsulta" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficinaConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div align="center">
            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:Label ID="lbSeleccionarTipoReporte" runat="server" Text="Seleccionar Tipo de Reporte" CssClass="LetrasNegrita"></asp:Label>
                    <asp:RadioButton ID="rbReporteResumido" runat="server" Text="Resumido" CssClass="form-check-input LetrasNegrita" GroupName="Supervisor" />
                    <asp:RadioButton ID="rbReporteDetalle" runat="server" Text="Detalle" CssClass="form-check-input LetrasNegrita" GroupName="Supervisor" />
                </div>
            </div>
            <br />
            
            
            
        </div>
        <div align="center">
              <asp:Button ID="btnConsultarComisiones" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultarComisiones_Click"  />
              <asp:Button ID="btnExortarComisiones" runat="server" Text="Exportar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Exportar Registros" OnClick="btnExortarComisiones_Click" />
              <asp:Button ID="btnReporteCOmisiones" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm" ToolTip="Reporte de Comisiones" OnClick="btnReporteCOmisiones_Click" />
          </div>
          <br />
                      <asp:GridView ID="gvComisionSupervisor" runat="server" AllowPaging="true" OnPageIndexChanging="gvComisionSupervisor_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="Supervisor" HeaderText="Supervisor" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Bruto" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Bruto" />
                    <asp:BoundField DataField="Neto" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Neto" />
                    <asp:BoundField DataField="PorcientoComision" HeaderText="% Comisión" />
                       <asp:BoundField DataField="Comision" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Comisión" />
                       <asp:BoundField DataField="Retencion" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Retención" />
                       <asp:BoundField DataField="AvanceComision" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Avance" />
                       <asp:BoundField DataField="ALiquidar" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="A Liquidar" />
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

          <br />

    </div>
</asp:Content>
