<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MontoAfianzadoFianzas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Correcciones.MontoAfianzadoFianzas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <div class="container-fluid">

        <script type="text/javascript">

            function PolizaNoExiste() {
                alert("El numero de Poliza ingresado no es valido, favor de verificar.");
            }

            function PrrocesoCompletado() {
                alert("Proceso Completado con Exito.");
            }

            $(function () {

                $("#<%=btnValidar.ClientID%>").click(function () {

                    var Poliza = $("#<%=txtPolizaValidacion.ClientID%>").val().length;
                    if (Poliza < 1) {
                        alert("El campo Poliza no puede estar vacio para buscar este registro, favor de verificar.");
                        $("#<%=txtPolizaValidacion.ClientID%>").css("border-color", "red");
                        return false;
                    }
                });

                $("#<%=btnGuardar.ClientID%>").click(function () {

                    var MontoAfianzado = $("#<%=txtMontoAfianzadoNuevo.ClientID%>").val().length;
                    if (MontoAfianzado < 1) {

                        alert("El campo monto Afianzado es obligatorio para completar esta proceso, favor de verificar.");
                        $("#<%=txtMontoAfianzadoNuevo.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var ConceptoModificacion = $("#<%=txtConceptoModificacion.ClientID%>").val().length;
                        if (ConceptoModificacion < 1) {

                            alert("El campo Concepto es obligatorio para completar esta proceso, favor de verificar.");
                            $("#<%=txtConceptoModificacion.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                });
            })
        </script>
    
       <div id="DivBloqueConsulta" runat="server">
           <br />
           <div class="form-check form-switch">
               <input type="checkbox" id="cbNoAgregarRangoFecha" runat="server" class="form-check-input" />
               <label class="form-check-label">No Agregar Rango de Fecha a la Consulta</label>
           </div>
           <br />
            <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
                <div class="col-md-4">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
                <div class="col-md-4">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date" ></asp:TextBox>
            </div>
        </div>
           <br />
           <div class="ContenidoCentro">
               <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultar_Click" />
                <asp:ImageButton ID="btnNuevoRegistro" runat="server" ToolTip="Nuevo Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" OnClick="btnNuevoRegistro_Click" />
           </div>
           <br />
           <table class="table table-striped">
               <thead class="table-dark">
                   <tr>
                       <th scope="col"> Poliza </th>
                       <th scope="col"> Anterior </th>
                       <th scope="col"> Cambio </th>
                       <th scope="col"> Concepto </th>
                       <th scope="col"> Usuario </th>
                       <th scope="col"> Fecha </th>
                       <th scope="col"> Hora </th>
                   </tr>
               </thead>
               <tbody>
                   <asp:Repeater ID="rpListadoModificaciones" runat="server">
                       <ItemTemplate>
                           <tr>
                               <td> <%# Eval("Poliza") %> </td>
                               <td> <%#string.Format("{0:N2}", Eval("Anterior")) %> </td>
                               <td> <%#string.Format("{0:N2}", Eval("Cambio")) %> </td>
                               <td> <%# Eval("Concepto") %> </td>
                               <td> <%# Eval("CreadoPor") %> </td>
                               <td> <%# Eval("Fecha") %> </td>
                               <td> <%# Eval("Hora") %> </td>
                           </tr>
                       </ItemTemplate>
                   </asp:Repeater>
               </tbody>
           </table>
            <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha"><b>Pagina</b>
                            <asp:Label ID="lbPaginaActualVariable" runat="server" Text=" 0 "></asp:Label>
                            <b> De </b>
                            <asp:Label ID="lbCantidadPaginaVariable" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
            <div id="DivPaginacion_Header" runat="server" align="center">
                <div style="margin-top: 20px;">
                    <table style="width: 600px">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btnPrimeraPagina" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnPaginaAnterior" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />
                            </td>
                            <td class="ContenidoCentrado">
                                <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td>
                                <asp:ImageButton ID="btnSiguientePaginar" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePaginar_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnUltimaPagina" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
    <br />
       </div>



        <div id="DIVBloqueModificacion" runat="server">

            <div id="SubBloqueConsulta" runat="server">
                <br />
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="lbPolizaValidacion" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                        <asp:TextBox ID="txtPolizaValidacion" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>

                <br />
           <div class="ContenidoCentro">
               <asp:ImageButton ID="btnValidar" runat="server" ToolTip="Validar Poliza" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Completado.png" OnClick="btnValidar_Click" />
                <asp:ImageButton ID="btnVolverValidacion" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverValidacion_Click" />
           </div>
            </div>
             <div id="SubBloqueModificar" runat="server">
                 <br />
                 <div class="row">
                     <div class="col-md-4">
                         <asp:Label ID="lbPolizaDetalle" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtPolizaDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4">
                         <asp:Label ID="lbEstatusDetalle" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtEstatusDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4"></div>

                     <div class="col-md-4">
                         <asp:Label ID="lbClienteDetalle" runat="server" Text="Cliente" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtClienteDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4">
                         <asp:Label ID="lbDeudorDetalle" runat="server" Text="Deudor" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtDeudorDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4">
                         <asp:Label ID="lbIntermediarioDetalle" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtIntermediarioDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>

                     <div class="col-md-4">
                         <asp:Label ID="lbRamoDetalle" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtRamoDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4">
                         <asp:Label ID="lbSubRamoDetalle" runat="server" Text="Sub Ramo" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtSubramoDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4"></div>

                     <div class="col-md-4">
                         <asp:Label ID="lbPrimaDetalle" runat="server" Text="Prima" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtPrimaDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4">
                         <asp:Label ID="lbMontoAfianzadoDetalle" runat="server" Text="Monto Afianzado" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtMontoAfianzadaDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4"></div>

                     <div class="col-md-4">
                         <asp:Label ID="lbFacturadoDetalle" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtFacturadoDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4">
                         <asp:Label ID="lbCobradoDetalle" runat="server" Text="Cobrado" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtCobradoDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-4">
                         <asp:Label ID="lbBalanceDetalle" runat="server" Text="Balance" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtBalanceDetalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                     </div>

                     <div class="col-md-4">
                         <asp:Label ID="lbMontoAfianzadoNuevo" runat="server" Text="Monto Afianzado Nuevo" CssClass="Letranegrita"></asp:Label>
                          <asp:Label ID="Label1" runat="server" Text=" * " ForeColor="Red" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtMontoAfianzadoNuevo" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-8">
                         <asp:Label ID="lbConceptoModificacion" runat="server" Text="Concepto de Modificación" CssClass="Letranegrita"></asp:Label>
                         <asp:Label ID="lbAsterisco" runat="server" Text=" * " ForeColor="Red" CssClass="Letranegrita"></asp:Label>
                         <asp:TextBox ID="txtConceptoModificacion" runat="server"  CssClass="form-control"></asp:TextBox>
                     </div>
                 </div>
                 <br />
                  <div class="ContenidoCentro">
               <asp:ImageButton ID="btnGuardar" runat="server" ToolTip="Guardar Información" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" OnClick="btnGuardar_Click" />
                <asp:ImageButton ID="btnVolver2" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolverValidacion_Click" />
           </div>
                 <br />
             </div>
        </div>
    </div>
</asp:Content>
