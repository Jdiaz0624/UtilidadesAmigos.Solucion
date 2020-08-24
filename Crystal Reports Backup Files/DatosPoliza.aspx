<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="DatosPoliza.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.DatosPoliza" %>
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
            width:100px;
        }
          .LetrasNegrita {
          font-weight:bold;
          }


    </style>
    <script type="text/javascript">
        function CamposVacios() {
            alert("Has dejado campos vacios que son necesarios para realizar esta operación");
        }
        function RegistroNoEncontrado() {
            alert("El registro ingresado no se encuentra registrado");
        }
        function PrimaVacia() {
            $("#<%=txtPrimaNueva.ClientID%>").css("border-color", "red");
        }
        function InciioVigencia() {
            $("#<%=txtInicioVigencia.ClientID%>").css("border-color", "red");
        }
        function FInVigenciaVacio() {
            $("#<%=txtFInVigencia.ClientID%>").css("border-color", "red");
        }
        function SeleccionaOpcion() {
            alert("Favor de seleccionar una opcion a realziar");
            $("#<%=cbModificarPrima.ClientID%>").css("border-color", "red");
            $("#<%=cbModificarVigencia.ClientID%>").css("border-color", "red");
        }
        function RegistroNoEncontrado() {
            alert("Registro no encontrado, favor de verificar los parametros ingresados");
        }
        function ErrorCambio() {
            alert("Error al realizar el cambio, favor de verificar los parametros ingresados o comuniquese con tecnologia");
        }
   

        function LimpiarControlesCoberturas() {
            $("#<%=txtCoberturaSeleccionada.ClientID%>").val("");
            $("#<%=txtMontoInformativo.ClientID%>").val("");
            $("#<%=txtPorciendoDeducible.ClientID%>").val("");
            $("#<%=txtMinimoDeducible.ClientID%>").val("");
            $("#<%=txtPorcientoCobertura.ClientID%>").val("");

            $("#btnCoberturas").attr("disabled", "disabled");
        }
   
        $(document).ready(function () {
            $("#<%=btnConsultar.ClientID%>").click(function () {
                var ValidarCampoPoliza = $("#<%=txtIngresarPoliza.ClientID%>").val().length;
                if (ValidarCampoPoliza < 1) {
                    alert("Favor ingresar la poliza para buscar un registro");
                    $("#<%=txtIngresarPoliza.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ValidarItem = $("#<%=txtIngresarItem.ClientID%>").val().length;
                    if (ValidarItem < 1) {
                        alert("Favor ingresar el numero de Item para buscar un registro");
                        $("#<%=txtIngresarItem.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }

            });

            //EVENTO DEL BOTON MODIFICAR
            $("#<%=btnModificar.ClientID%>").click(function () {
                var Cobertura = $("#<%=txtCoberturaSeleccionada.ClientID%>").val().length;
                if (Cobertura < 1) {
                    alert("El campo cobertura no puede estar vacio para modificar este registro, favor de verificar");
                    $("#<%=txtCoberturaSeleccionada.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var MontoInformativo = $("#<%=txtMontoInformativo.ClientID%>").val().length;
                    if (MontoInformativo < 1) {
                        alert("El campo monto informativo no puede estar vacio para modificar este registro, favor de verificar");
                        $("#<%=txtMontoInformativo.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var PorcientoDeducible = $("#<%=txtPorciendoDeducible.ClientID%>").val().length;
                        if (PorcientoDeducible < 1) {
                            alert("El campo % deducible no puede estar vacio para modificar este registro, favor de verificar");
                            $("#<%=txtPorciendoDeducible.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var MinimoDeducible = $("#<%=txtMinimoDeducible.ClientID%>").val().length;
                            if (MinimoDeducible < 1) {
                                alert("El campo Minimo Deducible no puede estar vacio para modificar este registro, favor de verificar");
                                $("#<%=txtMinimoDeducible.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var PorcientoCobertura = $("#<%=txtPorcientoCobertura.ClientID%>").val().length;
                                if (PorcientoCobertura < 1) {
                                    alert("El campo % de cobertura no puede estar vacio para modificar este registro, favor de verificar");
                                    $("#<%=txtPorcientoCobertura.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                                else {
                                    var ValorPorcientoDeducible = $("#<%=txtPorciendoDeducible.ClientID%>").val();
                                    if (ValorPorcientoDeducible > 100) {
                                        alert("El % de deducible no puede ser mayor a 100, favor de verificar");
                                        $("#<%=txtPorciendoDeducible.ClientID%>").css("border-color", "blue");
                                        return false;
                                    }
                                    else {
                                        var ValorPorcientoCobertura = $("#<%=txtPorcientoCobertura.ClientID%>").val();
                                        if (ValorPorcientoCobertura > 100) {
                                            alert("El % de cobertura no puede ser mayor a 100, favor de verificar");
                                            $("#<%=txtPorcientoCobertura.ClientID%>").css("border-color", "blue");
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });

            //EVENTO DEL BOTON CONSULTAR OTROS FILTROS
            $("#<%=btnCFonsultarOtrosRegistros.ClientID%>").click(function () {
                var ValidarCampo = $("#<%=txtDatoOtrosFiltros.ClientID%>").val().length;
                if (ValidarCampo < 1) {
                    alert("Favor de ingresar el dato a buscar");
                    $("#<%=txtDatoOtrosFiltros.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        });
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbDatoPoliza" runat="server" Text="Datos Poliza"></asp:Label>
            <asp:Label ID="lbIdRamo" runat="server" Visible="false" Text="Datos Poliza"></asp:Label>
             <asp:Label ID="lbCotizacion" runat="server" Visible="false" Text="Cotizacion"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbIngresaPoliza" runat="server" Text="Ingresar Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtIngresarPoliza" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
            </div>
              <div class="form-group col-md-6">
                <asp:Label ID="lbIngresarItem" runat="server" Text="Ingresar Item" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtIngresarItem" runat="server" CssClass="form-control" TextMode="Number" MaxLength="20"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
            <button type="button" id="btnCoberturas" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".ModificarCoberturas">Coberturas</button>
            <button type="button" id="btnOtrosFiltros" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".OtrosFiltros">Otros Filtros</button>
        </div>
        <br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbModificarPrima" runat="server" AutoPostBack="true" Text="Cambio de Valor" OnCheckedChanged="cbModificarPrima_CheckedChanged" CssClass="form-check-input" ToolTip="Cambiar el valor a un item de una poliza" />
            </div>
             <div class="form-group form-check">
                <asp:CheckBox ID="cbModificarVigencia" runat="server" AutoPostBack="true" OnCheckedChanged="cbModificarVigencia_CheckedChanged" Text="Cambio de Vigencia" CssClass="form-check-input" ToolTip="Cambiar la Vigencia de Una poliza" />
            </div>
        </div>
        <br />
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtRamo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbSubramo" runat="server" Text="Sub Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtSubramo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbTipoVegiculo" runat="server" Text="Tipo de Vehiculo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtTipoVehiculo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbMarca" runat="server" Text="Marca" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtMarca" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbModelo" runat="server" Text="Modelo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtModelo" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbColor" runat="server" Text="Color" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtColor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbChasis" runat="server" Text="Chasis" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtChasis" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbPlaca" runat="server" Text="Placa" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPlaca" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbValorAsegurado" runat="server" Text="Valor Asegurado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtValorAsegurado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbFianza" runat="server" Text="Fianza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFianza" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbAsegurado" runat="server" Text="Asegurado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtAsegurado" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbCliente" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbPrimaActual" runat="server" Text="Prima Actual" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPromaActual" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lbPrimaNueva" runat="server" Text="Prima Nueva" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPrimaNueva" runat="server" TextMode="Number" step="any" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <asp:Label ID="lbInicioVigencia" runat="server" Text="Inicio de Vigencia" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtInicioVigencia" runat="server"  TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group col-md-6">
                <asp:Label ID="lbFinVigencia" runat="server" Text="Fin de Vigencia" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFInVigencia" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
         <div align="center">
             <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Guardar Registro" OnClick="btnGuardar_Click" />
              <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Regresar" OnClick="btnRegresar_Click" />
        </div>
        <br />
    </div>

     <div class="modal fade bd-example-modal-xl ModificarCoberturas" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezadoMantenimiento" runat="server" Text="Modificar Coberturas"></asp:Label>
        </div>
       <asp:ScriptManager ID="ScripManagerDatoPoliza" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelDatoPoliza" runat="server">
            <ContentTemplate>
                 <div align="center">
            <asp:Label ID="lbPolizaConsultadaTitulo" runat="server" Text="Poliza: " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbPolizaConsultaVariable" runat="server" Text="Dato" CssClass="LetrasNegrita"></asp:Label>

              <asp:Label ID="Label1" runat="server" Text=" - " CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="lbItemSeleccionadoTitulo" runat="server" Text="Item Seleccionado: " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbItemSeleccionadoVariable" runat="server" Text="Dato" CssClass="LetrasNegrita"></asp:Label>

              <asp:Label ID="Label2" runat="server" Text=" - " CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="lbEstatusPolizaTitulo" runat="server" Text="Estatus: " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbEstatusPolizaVariableVariable" runat="server" Text="Dato" CssClass="LetrasNegrita"></asp:Label>
            <br />

                <asp:Label ID="lbInicioVigenciaTitulo" runat="server" Text="Inicio de Vigencia: " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbInicioVigenciaVariable" runat="server" Text="Dato" CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="Label3" runat="server" Text=" - " CssClass="LetrasNegrita"></asp:Label>

            <asp:Label ID="lbFinVigenciaTitulo" runat="server" Text="Fin de Vigencia: " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbFinVigenciaVariable" runat="server" Text="Dato" CssClass="LetrasNegrita"></asp:Label>
        </div>

                <asp:Label ID="lbCodigoCobertura" runat="server" Text="Dato" Visible="false" CssClass="LetrasNegrita"></asp:Label>
        <br />
        <div align="center">
            <asp:Label ID="lbSeleccionarCobertura" runat="server" Text="Seleccionar Cobertura" CssClass="LetrasNegrita"></asp:Label>
        </div>

            <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvCoberturasPoliza" runat="server" AllowPaging="true" OnPageIndexChanging="gvCoberturasPoliza_PageIndexChanging" OnSelectedIndexChanged="gvCoberturasPoliza_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="Secuencia" HeaderText="ID" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Cobertura" />
                    <asp:BoundField DataField="MontoInformativo" HeaderText="Limite" />
                    <asp:BoundField DataField="PorcDeducible" HeaderText="% Deducible" />
                    <asp:BoundField DataField="MinimoDeducible" DataFormatString="{0:N2}" HtmlEncode="false" HeaderText="Minimo"  />
                    <asp:BoundField DataField="PorcCobertura" HeaderText="% Cobertura" />
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
                <br />
                <!-- MOSTRAMOS LOS CONTROLES PARA MODIFICAR EL REGISTRO SELECCIONADO-->

                <div class="container-fluid">
                    <div class="form-row">
                    <div class="form-group col-md-12">
                        <asp:Label ID="lbCoberturaSeleccionada" runat="server" Text="Cobertura" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtCoberturaSeleccionada" runat="server" Enabled="false" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    </div>

                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label ID="lbMontoInformativoSeleccionado" runat="server" Text="Limite" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtMontoInformativo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label ID="lbPorcientoDeducibleSeleccionado" runat="server" Text="% Deducible" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtPorciendoDeducible" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                          <asp:Label ID="lbMinimoDeducibleSeleccionado" runat="server" Text="Minimo Deducible" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtMinimoDeducible" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label ID="lbPorcientoCobertura" runat="server" Text="% Cobertura" CssClass="LetrasNegrita"></asp:Label>
                        <asp:TextBox ID="txtPorcientoCobertura" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                </div>

                  <div align="center">
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Modificar Registro" OnClick="btnModificar_Click" />
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
      
        <br />
    </div>
  </div>
</div>






         <div class="modal fade bd-example-modal-xl OtrosFiltros" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="Label4" runat="server" Text="Otros Filtros Poliza"></asp:Label>
        </div>
        <asp:UpdatePanel ID="UpdatePanelOtrosFiltros" runat="server">
            <ContentTemplate>
               <div class="container-fluid">
                    <div align="center">
                    <asp:Label ID="lbSeleccionarTipoOpcion" runat="server" Text="Seleccionar Tipo de Consulta" CssClass="LetrasNegrita"></asp:Label>
                </div>
                <div  align="center">
                     <div class="form-check-inline">
                    <div class="form-group form-check">
                        <asp:RadioButton ID="rbBuscarChasis" runat="server" GroupName="OtrosFiltros" Text="Buscar por Chasis" ToolTip="Seleccionar para buscar mediante el chasis" CssClass="form-check-input" />
                        <asp:RadioButton ID="rbBuscarPorPlaca" runat="server" GroupName="OtrosFiltros" Text="Buscar por Placa" ToolTip="Seleccionar para buscar mediante la placa" CssClass="form-check-input" />
                    </div>
                </div>

                    
                </div>
                <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Label ID="lbIngresarOtroFiltro" runat="server" Text="Ingresar Dato" CssClass="LetrasNegrita"></asp:Label>
                            <asp:TextBox ID="txtDatoOtrosFiltros" runat="server" CssClass="form-control"></asp:TextBox>
                          
                        </div>
                    </div>
                     <asp:Button ID="btnCFonsultarOtrosRegistros" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" OnClick="btnCFonsultarOtrosRegistros_Click" ToolTip="Consultar"/>
               </div>
               <br />
                  <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvOtrosFiltros" runat="server" AllowPaging="true" OnPageIndexChanging="gvOtrosFiltros_PageIndexChanging" OnSelectedIndexChanged="gvOtrosFiltros_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Ver"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
                    <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                    <asp:BoundField DataField="Item" HeaderText="Item" />
                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
                    <asp:BoundField DataField="Cotizacion" HeaderText="Cotizacion" />
                    <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
                    <asp:BoundField DataField="Subramo" HeaderText="% Cobertura" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
      
        <br />
    </div>
  </div>
</div>

</asp:Content>
