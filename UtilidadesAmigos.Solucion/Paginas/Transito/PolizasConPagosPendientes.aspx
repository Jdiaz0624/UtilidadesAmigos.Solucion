<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="PolizasConPagosPendientes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Transito.PolizasConPagosPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />
   <div class="container-fluid">
       <br />
       <div class="row">
           <div class="col-md-3">
               <label class="Letranegrita"> Fecha Desde</label>
               <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date" ></asp:TextBox>
           </div>
           <div class="col-md-3">
               <label class="Letranegrita"> Fecha Hasta</label>
               <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
           </div>
           <div class="col-md-3">
               <label class="Letranegrita">Poliza</label>
               <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="ListadoPorPantalla" AutoCompleteType="Disabled"></asp:TextBox>
           </div>
           <div class="col-md-3">
               <label class="Letranegrita">Oficina</label>
               <asp:DropDownList ID="ddlOficina" runat="server" ToolTip="Seleccionar oficina" CssClass="form-control"></asp:DropDownList>
           </div>
           <div class="col-md-2">
               <label class="Letranegrita">Cliente</label>
               <asp:TextBox ID="txtCliente" runat="server" TextMode="Number" CssClass="form-control" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtCliente_TextChanged"></asp:TextBox>
           </div>
           <div class="col-md-4">
               <label class="Letranegrita">Nombre</label>
               <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
           </div>
           <div class="col-md-3">
               <label class="Letranegrita">Ramo</label>
               <asp:DropDownList ID="ddlRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged"></asp:DropDownList>
           </div>
           <div class="col-md-3">
               <label class="Letranegrita">Sub Ramo</label>
               <asp:DropDownList ID="ddlSubRamo" runat="server" ToolTip="Seleccionar Sub Ramo" CssClass="form-control"></asp:DropDownList>
           </div>
            <div class="col-md-2">
               <label class="Letranegrita">Intermediario</label>
                <asp:TextBox ID="txtCodigoIntermediario" runat="server" TextMode="Number" CssClass="form-control" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtCodigoIntermediario_TextChanged"></asp:TextBox>
           </div>
           <div class="col-md-4">
               <label class="Letranegrita">Nombre</label>
               <asp:TextBox ID="txtNombreIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
           </div>
            <div class="col-md-2">
               <label class="Letranegrita">Supervisor</label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" TextMode="Number" CssClass="form-control" AutoPostBack="true" AutoCompleteType="Disabled" OnTextChanged="txtCodigoSupervisor_TextChanged"></asp:TextBox>
           </div>
           <div class="col-md-4">
               <label class="Letranegrita">Nombre</label>
               <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
           </div>
       </div>
       <br />
       <div class="form-check-inline">
           <label class="Letranegrita">Formato de Reporte:</label>
           <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="FormaPago" ToolTip="Generar el Reporte en PDF" />
           <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="FormaPago" ToolTip="Exportar a Excel" />
       </div>
       <br />
       <div class="ContenidoCentro">
           <asp:ImageButton ID="btnConsultar" runat="server" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultar_Click" CssClass="BotonImagen" />
           <asp:ImageButton ID="btnReporte" runat="server" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporte_Click" CssClass="BotonImagen" />

       </div>
       <br />
       <div class="table-responsive">
           <table class="table table-striped">
               <thead class="table-dark">
                   <tr>
                       <th scope="col"> Poliza </th>
                       <th scope="col"> Ramo </th>
                       <th scope="col"> Proceso </th>
                       <th scope="col"> Inicio </th>
                       <th scope="col"> Fin </th>
                       <th scope="col"> Valor Poliza </th>
                       <th scope="col"> Cobrado </th>
                       <th scope="col"> Balance </th>
                   </tr>
               </thead>
               <tbody>
                   <asp:Repeater ID="rpListado" runat="server">
                       <ItemTemplate>
                           <tr>
                               <td> <%# Eval("Poliza") %> </td>
                               <td> <%# Eval("Ramo") %> </td>
                               <td> <%# Eval("FechaProceso") %> </td>
                               <td> <%# Eval("IncioVigencia") %> </td>
                               <td> <%# Eval("FinVigencia") %> </td>
                               <td> <%#string.Format("{0:N2}", Eval("ValorPoliza")) %> </td>
                               <td> <%#string.Format("{0:N2}", Eval("Cobrado")) %> </td>
                               <td> <%#string.Format("{0:N2}", Eval("MontoPendiente")) %> </td>
                           </tr>
                       </ItemTemplate>
                   </asp:Repeater>
               </tbody>
           </table>
           <table class="table">
               <tfoot class="table-light">
                   <tr>
                       <td class="ContenidoDerecha">
                           <label class="Letranegrita">Pagina</label> <asp:Label ID="lbPaginaActual" runat="server" Text="0"></asp:Label>
                           <label class="Letranegrita">De</label> <asp:Label ID="lbCantidadPagina" runat="server" Text="0"></asp:Label>
                       </td>
                   </tr>
               </tfoot>
           </table>
       </div>
         <div id="DivPaginacion" class="table-responsive" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />  </td>
                    <td class="ContenidoCentro">
                        <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
   </div>
</asp:Content>
