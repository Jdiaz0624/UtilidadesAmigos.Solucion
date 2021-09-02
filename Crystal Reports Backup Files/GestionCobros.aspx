<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GestionCobros.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Consulta.GestionCobros" %>
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

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        

        th {
            background-color: dodgerblue;
            color: white;
        }
    </style>

    <script type="text/javascript">
        function RegistroNoEncontrado() {
            alert("No se encontraron resultados con el numero de poliza ingresada, favor de verificar.");
        }

        function ErrorGenerarReporte() {
            alert("Estas usando la opción de uso de rango de fecha, favor de verificar si uno de esos campo no esa vacio, o marca la opción de no agregar rango de fecha.");
        }

        function RegistrosNoEncontrados() {
            alert("No se encontraron registros");
        }

        function CampoFechaDesdeVAcio() {
            $("#<%=txtFechaDesdeReporte.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHAstaReporte.ClientID%>").css("border-color", "red");
        }

        $(document).ready(function () {
            //VALIDAR EL BOTON BUSCAR
            $("#<%=btnCOnsultarPOliza.ClientID%>").click(function () {
                var Poliza = $("#<%=txtIngresarPoliza.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo poliza no puede estar vacio para buscar un registro, favor de verificar.");
                    $("#<%=txtIngresarPoliza.ClientID%>").css("border-color", "red");
                    return false;
                }
            });


            //FUNCION DEL BOTON GUARDAR
            $("#<%=btnGuardar.ClientID%>").click(function () {
                var Comentario = $("#<%=txtCoentario.ClientID%>").val().length;
                if (Comentario < 1) {
                    alert("El campo comentario no puede estar vacio para realizar esta operación.");
                    $("#<%=txtCoentario.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

        })
    </script>

    <br />
    <asp:Label ID="lbAccion" runat="server" Visible="false" Text="INSERT"></asp:Label>
    <asp:Label ID="LBid" runat="server" Visible="false" Text="0"></asp:Label>
    <div id="DivBloquePrincipal" runat="server" class="form-inline">
        <div  class="form-group col-md-6">
          <asp:Label ID="lbIngresarPoliza" runat="server" Text="Ingresar Poliza" CssClass="Letranegrita"></asp:Label>
            <asp:TextBox ID="txtIngresarPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            <asp:Button ID="btnCOnsultarPOliza" runat="server" Text="Buscar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnCOnsultarPOliza_Click" ToolTip="Buscar Registro" />
        </div>

     
    </div>
    <br />
        <div id="DivReporteCOmentarios" runat="server" class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbMostrarReporteCOmentarios" runat="server" Text="Reporte de Comentarios" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="cbMostrarReporteCOmentarios_CheckedChanged" ToolTip="Habilita la opción para generar los reportes de comentarios" />
            </div>
        </div>
        <div id="DivBloqueReporteCOmentario" runat="server">

            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:CheckBox ID="cbNoAgregarRangoFecha" runat="server" Text="No Agregar Rango de Fecha" CssClass="form-check-input Letranegrita" ToolTip="No agregar rango de fecha para gerenar el reporte." />
                </div>

                <div class="form-group form-check">
                    <asp:Label ID="lbGenerarReporteEn" runat="server" Text="Generar Reporte en: " CssClass="Letranegrita"></asp:Label>
                    <asp:RadioButton ID="rbPDF" runat="server" Text="PDF"  ToolTip="Genear Reporte en PDF" CssClass="form-check-input Letranegrita" GroupName="Reporte" />
                    <asp:RadioButton ID="rbExcel" runat="server" Text="Excel"  ToolTip="Generar Reporte en Excel" CssClass="form-check-input Letranegrita" GroupName="Reporte" />
                    <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano"  ToolTip="Generar Reporte en Excel Plano" CssClass="form-check-input Letranegrita" GroupName="Reporte" />
                </div>
            
            </div>
                <br />
            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label ID="lbPolizaReporte" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtPolizaReporte" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbFechaDesdeReporte" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesdeReporte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label ID="lbFechaHastaReporte" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHAstaReporte" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                 <div class="form-group col-md-3">
                    <asp:Label ID="lbSeleccionarUsuario" runat="server" Text="Seleccionar Usuario" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarUsuario" runat="server" ToolTip="Seleccionar Usuario" CssClass="form-control"></asp:DropDownList>
                </div>

            </div>
            <br />
            <div align="center">
                <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnReporte_Click" ToolTip="Generar Reporte" />
            </div>
        </div>

    <br />
    <div id="DivInformacionPolizaGeneral" visible="false" runat="server">
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbEstatus" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtEstatus" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lbRamo" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtRamp" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>


            <div class="form-group col-md-4">
                <asp:Label ID="lbCliente" runat="server" Text="Cliente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbTelefono" runat="server" Text="Telefonos" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="lbTelefonos" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbDireccion" runat="server" Text="Dirección" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbSupervisor" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtSupervisor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbIntermediario" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbLicencia" runat="server" Text="Licencia" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtLicencia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbFechaCreada" runat="server" Text="Fecha Creada" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaCreada" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbInicioVigencia" runat="server" Text="Inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtInicioVigencia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbFInVigencia" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFinVigencia" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbFacturado" runat="server" Text="Facturado" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFacturado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbCobrado" runat="server" Text="Cobrado" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCobrado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbBalance" runat="server" Text="Balance" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtBalance" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbTotalFActuras" runat="server" Text="Total de Facturas" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTotalFacturado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbTotalRecibos" runat="server" Text="Total de Recibos" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTotalRecibos" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbTtalReclamos" runat="server" Text="Total de Reclamos" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTotalRelcamos" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-12">
                <asp:Label ID="lbComentario" runat="server" Text="Comentario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCoentario" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div align="center">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnGuardar_Click" ToolTip="Guardar Registro" />
            <asp:Button ID="btnDeselccionar" runat="server" Text="Quitar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnDeselccionar_Click" ToolTip="Deseleccionar Registro" />
        </div>
       
        <br />
        <div align="center">
            <asp:Label ID="lbCantidadCOmentarios" runat="server" Text="Cantidad de Comentarios (" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadCOmentariosVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadCOmentariosCerrar" runat="server" Text=")" CssClass="Letranegrita"></asp:Label>
        </div>
        <br />
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <%--<th style="width:10%" align="left"> EDITAR </th>--%>
                        <th style="width:55%" align="left"> COMENTARIO </th>
                        <th style="width:25%" align="left"> USUARIO </th>
                        <th style="width:10%" align="left"> FECHA </th>
                        <th style="width:10%" align="left"> HORA </th>
                    </tr>
                </thead>
                <tbody>
                   <asp:Repeater ID="rpListadoCOmentarios" runat="server">
                       <ItemTemplate>

                            <tr>
                                <asp:HiddenField ID="HFID" runat="server" Value='<%# Eval("ID") %>' />
                                <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                        <%--<td style="width:10%" align="left"> <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnEditar_Click" ToolTip="Editar Registro" /> </td>--%>
                        <td style="width:55%" align="left"> <%# Eval("Comentario") %> </td>
                        <td style="width:25%" align="left"> <%# Eval("Usuario") %> </td>
                        <td style="width:10%" align="left"> <%# Eval("Fecha") %> </td>
                        <td style="width:10%" align="left"> <%# Eval("Hora") %> </td>
                    </tr>
                       </ItemTemplate>
                   </asp:Repeater>
                </tbody>
            </table>
        </div>

         <div align="center">
               <asp:Label ID="lbPaginaActualTituloGestionCobros" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleGestionCobros" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloGestionCobros" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableGestionCobros" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaGestionCobros" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaGestionCobros_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorGestionCobros" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorGestionCobros_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionGestionCobros" runat="server" OnItemCommand="dtPaginacionGestionCobros_ItemCommand" OnItemDataBound="dtPaginacionGestionCobros_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralGestionCobros" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteGestionCobros" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteGestionCobros_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoGestionCobros" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoGestionCobros_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        <div align="center">
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnVolver_Click" ToolTip="Volver Atras" />
        </div>
        <br />
    </div>
</asp:Content>
