<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Endosos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.Endosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">

        .btn-sm{
            width:90px;
        }

        .LetrasNegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        
       .BotonImagen {
         width:40px;
         height:40px;
       
       }
    </style>

    <script type="text/javascript">
        function RegistroNoEncontrado() {
            alert("Los datos ingresados no concuerdan con algun registro en el sistema, favor de verificar los datos de entrada.");
        }
        function PolizaCancelada() {
            alert("No es posible sacar esta información por que esta poliza esta cancelada.");
        }
        function PolizaNoAplica() {
            alert("Esta poliza no aplica para ningun endoso, favor de verificar las condiciones Particulares.");
        }
        function LicenciaExtrajero() {
            alert("El campo de Licencia de Extrajero es obligatoria para generar este endoso, favor de verificar.");
            $("#<%=txtNumeroLicenciaExtranjero.ClientID%>").css("border-color", "red");
        }

        function CamposVaciosConductorUnico() {
            alert("El campo nombre o el campo cedula no pueden estar vacios para generar este endoso, favor de verificar.");
        }
        function CampoNombreVacioConductorUnico() { $("#<%=txtNombreConductorUnico.ClientID%>").css("border-color", "red"); }
        function CampoCedulaVacioConductorUnico() { $("#<%=txtCedulaConductorUnico.ClientID%>").css("border-color", "red"); }
        $(function () {
            
            //VALIDAR EL BOTON BUSCAR
            $("#<%=btnConsultar.ClientID%>").click(function () {
                var Poliza = $("#<%=txtPolizaConsulta.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo poliza no puede estar vacio para buscar un registro, favor de verificar.");
                    $("#<%=txtPolizaConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Item = $("#<%=txtNumeroItenComsulta.ClientID%>").val().length;
                    if (Item < 1) {
                        alert("El campo Item no puede estar vacio para buscar un registro, favor de verificar.");
                        $("#<%=txtNumeroItenComsulta.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }
            });
        })
    </script>
    <div class="container-fluid">
        <div class="progress">
  <asp:UpdateProgress ID="progress" runat="server"></asp:UpdateProgress>
</div>
        <asp:Label ID="lbIdPerfil" runat="server" Visible="false" Text="0" ></asp:Label>
        <asp:ScriptManager ID="ScripManagerEndosos" runat="server"></asp:ScriptManager>
        <br />
        <div class="row">
           <div class="col-md-6">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
            <asp:TextBox ID="txtPolizaConsulta" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
           </div>
             <div class="col-md-6">
                <asp:Label ID="lbNumeroItemConsulta" runat="server" Text="Item No." CssClass="LetrasNegrita"></asp:Label>
            <asp:TextBox ID="txtNumeroItenComsulta" runat="server" AutoCompleteType="Disabled" TextMode="Number" CssClass="form-control"></asp:TextBox>
           </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
            <asp:ImageButton ID="btnRestablecerPantalla" runat="server" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" ImageUrl="~/Imagenes/auto.png" OnClick="btnRestablecerPantalla_Click" />
        </div>
        <br />

        <div id="DIVBloqueDetallePoliza" runat="server">
            <div class="row">
             <div class="col-md-3">
                 <asp:Label ID="lbPolizaDetalleFijo" runat="server" Text="Poliza: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbPolizaDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                 <asp:Label ID="lbItemNoDetalleFijo" runat="server" Text="Item No: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbItemNoDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                 <asp:Label ID="lbInicioVigenciaDetalleFijo" runat="server" Text="Inicio de Vigencia: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbInicioVigenciaDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                 <asp:Label ID="lbFinVigenciaDetalleFijo" runat="server" Text="Fin de Vigencia: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbFinVIgenciaDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                 <asp:Label ID="lbSupervisorDetalleFijo" runat="server" Text="Supervisor: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbSupervisorDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                 <asp:Label ID="lbIntermediarioDetalleFijo" runat="server" Text="Intermediario: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbIntermediarioDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                  <asp:Label ID="lbEstatusDetalleFijo" runat="server" Text="Estatus: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbEstatusDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                  <asp:Label ID="lbRamosDetalleFijo" runat="server" Text="Ramo: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbRamoDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                  <asp:Label ID="lbSubRamoDetalleFijo" runat="server" Text="Sub Ramo: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbSubRamoDetalleVariable" runat="server" Text="Dato"></asp:Label>
                 <asp:Label ID="LBCodigoSubramoVariable" Visible="false" runat="server" Text="Dato"></asp:Label>
             </div>
             <div class="col-md-3">
                  <asp:Label ID="lbClienteDetalleFijo" runat="server" Text="Cliente: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbClienteDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
                <div class="col-md-3">
                  <asp:Label ID="lbTipoSeguroFijo" runat="server" Text="Tipo: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbTipoSeguroVariable" runat="server" Text="Dato"></asp:Label>
             </div>
                </div>
                <div class="col-md-3">
                  <asp:Label ID="lbGruaFijo" runat="server" Text="Grua: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbGruaVariable" runat="server" Text="Dato"></asp:Label>
                    <asp:Label ID="lbCodigoGruaVariable" runat="server" Visible="false" Text="Dato"></asp:Label>
             </div>
                
        </div>
            <div id="DIVBloqueOperacionRealizar" runat="server">
                 <br />
        <div class="form-check-inline">
            <asp:Label ID="lbOperacionREalizar" runat="server" Text="Operación a Realizar: " CssClass="LetrasNegrita"></asp:Label>
            <asp:RadioButton ID="rbHistoricoEndoso" runat="server" Text="Historico" AutoPostBack="true" OnCheckedChanged="rbHistoricoEndoso_CheckedChanged" GroupName="TipoOperacion" />
            <asp:RadioButton ID="rbGenerarNuevoEndoso" runat="server" Text="Nuevo Registro" AutoPostBack="true" OnCheckedChanged="rbGenerarNuevoEndoso_CheckedChanged" GroupName="TipoOperacion" />
        </div>
        <br />
        <br />
            </div>
        <div id="DIVBloqueHistorico" runat="server">
            <br />
             <div align="center">
           
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Reporte de Impresión de Endoso" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
        </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                         <th scope="col"> Endoso </th>
                         <th scope="col"> Poliza </th>
                         <th scope="col"> Item </th>
                        <th scope="col"> Secuencia </th>
                         <th scope="col"> Fecha </th>
                         <th scope="col"> Hora </th>
                         <th scope="col"> Usuario </th>
                         <th scope="col">  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoEndososImpresos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                                <asp:HiddenField ID="hfItem" runat="server" Value='<%# Eval("Item") %>' />
                                <asp:HiddenField ID="hfIdUsuario" runat="server" Value='<%# Eval("IdUsuario") %>' />
                                <asp:HiddenField ID="hfCodigoTipoEndoso" runat="server" Value='<%# Eval("CodigoTipoEndoso") %>' />
                                <asp:HiddenField ID="hfSecuencia" runat="server" Value='<%# Eval("Secuencia") %>' />



                                <td> <%# Eval("TipoEndoso") %> </td>
                                <td> <%# Eval("Poliza") %> </td>
                                <td> <%#string.Format("{0:N0}", Eval("Item")) %> </td>
                                <td> <%# Eval("Secuencia") %> </td>
                                <td> <%# Eval("Fecha") %> </td>
                                <td> <%# Eval("Hora") %> </td>
                                <td> <%# Eval("CreadoPor") %> </td>
                                <td align="right"> <asp:ImageButton ID="btnReImprimirEndoso" runat="server" ToolTip="GenerarEndoso" CssClass="BotonImagen" ImageUrl="~/Imagenes/impresora.png" OnClick="btnReImprimirEndoso_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
             <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina </b> <asp:Label ID="lbPaginaActual" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> <b>De </b>   <asp:Label ID="lbCantidadPagina" runat="server" Text="0" CssClass="Letranegrita"></asp:Label> </td>
                    </tr>
                    <tr>
                        <td><b>Endosos Aclaratorios:  </b><asp:Label ID="lbTotalEndososAclaratorios" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Endosos Licencia de Extrajeros:  </b><asp:Label ID="lbTotalEndososLicenciaExtrajero" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Endosos Conductor Unico:  </b><asp:Label ID="lbTotalEndososConductorUnico" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Endosos Auxilio Vial:  </b><asp:Label ID="lbTotalEndososAuxilioVial" runat="server" Text="0"></asp:Label></td>
                    </tr>
                
                </tfoot>
            </table>
              <div id="DivPaginacionListadoPrincipal" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnterior_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipal" runat="server" OnCancelCommand="dtPaginacionListadoPrincipal_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipal_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
        <br />
        </div>
        <div id="DIVBloqueNuevoRegistro" runat="server">
            <br />
            <div class="form-check-inline" id="DIVBloqueTiposEndosos" runat="server">
                <asp:Label ID="lbTipoEndosoGenerar" runat="server" Text="Tipo de Endoso a Generar" CssClass="LetrasNegrita"></asp:Label><br />
                <asp:RadioButton ID="rbEndosoAclaratorio" runat="server" Text="Endoso Aclaratorio" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso Aclaratorio" OnCheckedChanged="rbEndosoAclaratorio_CheckedChanged" /><br />
                <asp:RadioButton ID="rbEndosoLicenciaExtragero" runat="server" Text="Endoso de Licencia de Extragero" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso De Licencia de Extragero" OnCheckedChanged="rbEndosoLicenciaExtragero_CheckedChanged" /><br />
                <asp:RadioButton ID="rbEndosoAclaratorioPAraCodundorUnico" runat="server" Text="Endoso de Conductor Unico" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso Para Conductor Unico" OnCheckedChanged="rbEndosoAclaratorioPAraCodundorUnico_CheckedChanged" /><br />
                <asp:RadioButton ID="rbENdosoAuxilioVial" runat="server" Text="Endoso Auxilio Vial" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso de Auxilio Vial" OnCheckedChanged="rbENdosoAuxilioVial_CheckedChanged" /><br />
                <asp:RadioButton ID="rbEndosoCasaConductor" runat="server" Text="Casa Del Conductor" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso de Casa Del Conductor" OnCheckedChanged="rbEndosoCasaConductor_CheckedChanged" /><br />
                <asp:RadioButton ID="rbEndosoDVL" runat="server" Text="Endoso de DVL" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso DVL" OnCheckedChanged="rbEndosoDVL_CheckedChanged" />
            </div>
             <br />
        <div class="row">
            <div class="col-md-4" id="DIVBloqueLicenciaExtrajero" runat="server">
                <asp:Label ID="lbNumeroLicenciaExtrajero" runat="server" Text="Licencia Extrajero" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroLicenciaExtranjero" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
            <div class="col-md-4" id="DIVBloqueNombre" runat="server">
                <asp:Label ID="lbNombreConductorUnico" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreConductorUnico" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
            <div class="col-md-4" id="DIVBloqueCedula" runat="server">
                <asp:Label ID="lbCedulaConductorUnico" runat="server" Text="Cedula" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCedulaConductorUnico" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="txtCedulaConductorUnico" Mask="999-9999999-9"
                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                MaskType="Number" InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                ErrorTooltipEnabled="True"  ID="MaskedEditExtender1" />
            </div>
        </div>
        <br />
         <div align="center">
            <asp:ImageButton ID="btnCompletar" runat="server" ToolTip="Completar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Completar.png" OnClick="btnCompletar_Click" />
        </div>
        </div>
       
            <br />
       
    </div>

</asp:Content>
