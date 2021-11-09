<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarReporteFianzas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarReporteFianzas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">
       .jumbotron{
            color:#000000; 
            background:#1E90FF;
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
        table {
            border-collapse: collapse;
        }
        

        th {
            background-color: #1E90FF;
            color: #000000;
        }
          .BotonImagen {
              width: 50px;
              height: 50px;
          }
    </style>
    <script type="text/javascript">
        function MensajeConsulta() {
            alert("Error al realizar la consulta, favor de verificar el rango de fecha ingresado");
        }

        function FechaDesdeError() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }

        function FechaHastaError() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }



   
    </script>
    <div class="container-fluid">
        <br /><br />
        <div align="center">
            <asp:Label ID="lbCantidadEncontradaTitulo" runat="server" Text="Cantidad de registros encontrados ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistros" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCerrarParentesis" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtpolizaConsulta" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbSeleccionarSubramo" runat="server" Text="SubRamo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarSubramo" runat="server" CssClass="form-control" ToolTip="Seleccionar Subramo"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" TextMode="Date" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
        
            </div>
           <div class="col-md-3">
               <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" TextMode="Date" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultarNuevo" runat="server" ToolTip="Consultar Registros en Pantalla" OnClick="btnConsultarNuevo_Click" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" />
            <asp:ImageButton ID="btnExportarExelPrincipal" runat="server" ToolTip="Exportar Registros a Excel" OnClick="btnExportarExelPrincipal_Click" CssClass="BotonImagen" ImageUrl="~/Imagenes/excel.png" />


           <br />
            <button type="button" id="btnHistorico" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".bd-example-modal-xl">Historico</button>

           
        </div>
        <br />
     
               <table class="table table-striped">
                   <thead>
                       <tr>
                           <th scope="col"> No. Factura </th>
                           <th scope="col"> Poliza </th>
                           <th scope="col"> Estatus </th>
                           <th scope="col"> SubRamo </th>
                           <th scope="col"> Cliente </th>
                           <th scope="col"> Intermediario </th>
                           <th scope="col">Fecha</th>
                       </tr>
                   </thead>
                   <tbody>
                       <asp:Repeater ID="rpListadoFianzas" runat="server">
                           <ItemTemplate>
                               <tr>
                                   <td> <%# Eval("NoFactura") %> </td>
                                   <td> <%# Eval("Poliza") %> </td>
                                   <td> <%# Eval("Estatus") %> </td>
                                   <td> <%# Eval("SubRamo") %> </td>
                                   <td> <%# Eval("Cliente") %> </td>
                                   <td> <%# Eval("Intermediario") %> </td>
                                   <td> <%# Eval("FechaFacturacion") %> </td>
                               </tr>
                           </ItemTemplate>
                       </asp:Repeater>
                   </tbody>
               </table>


         <div align="center">
                <asp:Label ID="lbPaginaActualTituloFianzas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableFianzas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloFianzas" runat="server" Text="De " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableFianzas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>

             <div id="DivPaginacionListadoPrincipalFianzas" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:LinkButton ID="LinkPrimeraPaginaFianzas" runat="server" Text="Primero" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaFianzas_Click" CssClass="btn btn-outline-success btn-sm"  ></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkPaginaAnteriorFianzas" runat="server" Text="Anterior" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkPaginaAnteriorFianzas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td>
                                <asp:DataList ID="dtPaginacionFianzas" runat="server" OnCancelCommand="dtPaginacionFianzas_CancelCommand" OnItemDataBound="dtPaginacionFianzas_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkIndiceFianzas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="NuevaPagina" Text='<%# Eval("TextoPagina")%>' Width="20px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:LinkButton ID="LinkSiguientePaginaFianzas" runat="server" Text="Siguiente" ToolTip="Ir la Siguiente pagina del listado" OnClick="LinkSiguientePaginaFianzas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkUltimaPaginaFianzas" runat="server" Text="Ultmo" ToolTip="Ir a la Ultima Pagina del listado" OnClick="LinkUltimaPaginaFianzas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
    </div>

    <div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
    
         <div class="jumbotron" align="center">
             <asp:Label ID="lbHistoricFinzas" runat="server" Text="Historico de Fianzas"></asp:Label>
         </div>
      
         <div class="container-fluid">
         <asp:ScriptManager ID="ScriptHistoricoPoliza" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanelHistoricoPoliza" runat="server">
             <ContentTemplate>
                   <div align="center">
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros (" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
             <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
        </div>
                 <div class="row">
                     <div class="col-md-3">
                         <asp:Label ID="lbPolizaHistoricoPoliza" runat="server" Text="Poliza"  CssClass="LetrasNegrita"></asp:Label>
                         <asp:TextBox ID="txtPolizaHistoricoPoliza" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled"></asp:TextBox>
                     </div>

                     <div class="col-md-3">
                         <asp:Label ID="lbSubRanoHistoriclPoliza" runat="server" Text="Sub Ramo"  CssClass="LetrasNegrita"></asp:Label>
                         <asp:DropDownList ID="ddlSeleccionarSubramHistoriclPoliza" runat="server" CssClass="form-control" ToolTip="Seleccionar Sub Ramo"></asp:DropDownList>
                     </div>

                     <div class="col-md-3">
                         <asp:Label ID="lbFecgaDesdeHistoricl" runat="server" Text="Fecha Desde"  CssClass="LetrasNegrita"></asp:Label>
                         <asp:TextBox ID="txtFechaDesdeHistoricoPoliza" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>

                      <div class="col-md-3">
                         <asp:Label ID="lbFechaHastaHistoricoPoliza" runat="server" Text="Fecha Hasta"  CssClass="LetrasNegrita"></asp:Label>
                         <asp:TextBox ID="txtFechaHAstaHistoricoPoliza" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>

                 </div>
                 <!--BOTONES-->
                 <div align="center">
                     <asp:ImageButton ID="btnConsultarHistoricoNuevo" runat="server" ToolTip="Consultar Historico de Fianzas" CssClass="BotonImagen" OnClick="btnConsultarHistoricoNuevo_Click" ImageUrl="~/Imagenes/Buscar.png" />
                 </div>
                 <!--BOTONES-->
                 <br />
         
                       <table class="table table-striped">
                           <thead>
                               <tr>
                                   <th scope="col"> Poliza </th>
                                   <th scope="col"> Cliente </th>
                                   <th scope="col"> SubRamo</th>
                                   <th scope="col"> Concepto</th>
                                   <th scope="col"> Valor</th>
                                   <th scope="col"> Fecha</th>
                               </tr>
                           </thead>
                           <tbody>
                               <asp:Repeater ID="rpListadoHistoricoFianzas" runat="server">
                                   <ItemTemplate>
                                       <tr>
                                           <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                           <td style="width:20%"> <%# Eval("Cliente") %> </td>
                                           <td style="width:20%"> <%# Eval("SubRamo") %> </td>
                                           <td style="width:30%"> <%# Eval("Concepto") %> </td>
                                           <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Valor")) %> </td>
                                           <td style="width:10%"> <%# Eval("Fecha") %> </td>
                                       </tr>
                                   </ItemTemplate>
                               </asp:Repeater>
                           </tbody>
                       </table>
            
                  <div align="center">
                <asp:Label ID="lbPaginaActualTituloHistoricoFianzas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableHistoricoFianzas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloHistoricoFianzas" runat="server" Text="De " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableHistoricoFianzas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>

             <div id="DivPaginacionListadoPrincipalHistoricoFianzas" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:LinkButton ID="LinkPrimeraPaginaHistoricoFianzas" runat="server" Text="Primero" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaHistoricoFianzas_Click" CssClass="btn btn-outline-success btn-sm"  ></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkPaginaAnteriorHistoricoFianzas" runat="server" Text="Anterior" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkPaginaAnteriorHistoricoFianzas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td>
                                <asp:DataList ID="dtPaginacionHistoricoFianzas" runat="server" OnCancelCommand="dtPaginacionHistoricoFianzas_CancelCommand" OnItemDataBound="dtPaginacionHistoricoFianzas_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkIndiceHistoricoFianzas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="NuevaPagina" Text='<%# Eval("TextoPagina")%>' Width="20px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:LinkButton ID="LinkSiguientePaginaHistoricoFianzas" runat="server" Text="Siguiente" ToolTip="Ir la Siguiente pagina del listado" OnClick="LinkSiguientePaginaHistoricoFianzas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkUltimaPaginaHistoricoFianzas" runat="server" Text="Ultmo" ToolTip="Ir a la Ultima Pagina del listado" OnClick="LinkUltimaPaginaHistoricoFianzas_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>

               
             </ContentTemplate>
         </asp:UpdatePanel>
             <br />
               <!--BOTONES-->
                 <div align="center">
                     <asp:ImageButton ID="btnExportarHistorialPolizaNuevo" runat="server" ToolTip="Exportar Información" CssClass="BotonImagen" OnClick="btnExportarHistorialPolizaNuevo_Click" ImageUrl="~/Imagenes/excel.png" />

                 </div>
             <br />
                 <!--BOTONES-->
     </div>
    </div>
  </div>
</div>
</asp:Content>
