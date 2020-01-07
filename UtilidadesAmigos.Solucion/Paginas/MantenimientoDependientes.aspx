<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoDependientes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoDependientes" %>
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
            <asp:Label ID="ldTituloConsulta" runat="server" Text="Consulta de Dependientes"></asp:Label>
            <asp:Label ID="lbNumeroCotizacionPoliza" runat="server" Text="NumeroCotizacion" Visible="false"></asp:Label>
        </div>
        <!--INICIO DE LOS CONTROLES PARA REALIZAR LA CONSULTA-->
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbNumeroPoliza" runat="server" CssClass="LetrasNegrita" Text="Poliza"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
               
            </div>
           
            
        </div>
         <div>
                 <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
             <button type="button" id="btnAgregarDependiente" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-lg">Agregar</button>
             <button type="button" id="btnQuitarDependiente" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-lg">Quitar</button>
            </div>

         <div>
            <asp:GridView ID="gvDependientes" runat="server" AllowPaging="true" OnPageIndexChanging="gvDependientes_PageIndexChanging" OnSelectedIndexChanged="gvDependientes_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="IdAsegurado" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Parentezco" HeaderText="Parentezco" />
                    <asp:BoundField DataField="NumeroId" HeaderText="No. Identificación" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="PorcPrima" HeaderText="Prima" />
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
        <!--FIN DE LOS CONTROLES PARA REALIZAR LA CONSULTA-->
    </div>

    <!--INICIO DE LOS CONTROLES DE MANTENIMIENTO -->
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="TituloMantenimiento" runat="server" Text="Mantenimiento de Dependientes"></asp:Label>
          </div>
          <div class="form-row">
              <div class="form-group col-md-6">
                  <asp:Label ID="lbNombreMantenimiento" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtNombreMantenimiento" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                    <asp:Label ID="lbParentezco" runat="server" Text="Parentezco" CssClass="LetrasNegrita"></asp:Label>
                   <asp:DropDownList ID="ddlSeleccionarParentezzcoMantenimiento" runat="server" ToolTip="Seleccionar Parentezco" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbNumeroID" runat="server" Text="Cedula" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtCedula" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                   <asp:Label ID="lbFechaNacimiento" runat="server" Text="Fecha Nacimiento" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbSexoMantenimiento" runat="server" Text="Sexo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:DropDownList ID="ddlSeleccionarSexoMantenimiento" runat="server" ToolTip="Seleccionar Sexo" CssClass="form-control"></asp:DropDownList>
              </div>
              <div class="form-group col-md-6">
                       <asp:Label ID="lbProma" runat="server" Text="Prima" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtPrima" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
          <div align="center">
              <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Guardar Registros" OnClick="btnGuardar_Click" />
              <asp:Button ID="btnQuitar" runat="server" Text="Quitar" CssClass="btn btn-outline-primary btn-sm" ToolTip="quitar Registros" OnClick="btnQuitar_Click" />
          </div>
          <br />
      </div>
    </div>
  </div>
</div>
</asp:Content>
