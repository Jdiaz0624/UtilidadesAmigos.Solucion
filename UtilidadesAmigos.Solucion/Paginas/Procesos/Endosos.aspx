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
    <div class="container-fluid">
        <asp:ScriptManager ID="ScripManagerEndosos" runat="server"></asp:ScriptManager>
        <br />
        <div class="row">
           <div class="col-md-6">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
            <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
             <div class="col-md-6">
                <asp:Label ID="lbNumeroItemConsulta" runat="server" Text="Item No." CssClass="LetrasNegrita"></asp:Label>
            <asp:TextBox ID="txtNumeroItenComsulta" runat="server" CssClass="form-control"></asp:TextBox>
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
             </div>
             <div class="col-md-3">
                  <asp:Label ID="lbClienteDetalleFijo" runat="server" Text="Cliente: " CssClass="LetrasNegrita"></asp:Label>
                 <asp:Label ID="lbClienteDetalleVariable" runat="server" Text="Dato"></asp:Label>
             </div>
                
        </div>
             <br />
        <div class="form-check-inline">
            <asp:Label ID="lbOperacionREalizar" runat="server" Text="Operación a Realizar: " CssClass="LetrasNegrita"></asp:Label>
            <asp:RadioButton ID="rbHistoricoEndoso" runat="server" Text="Historico" AutoPostBack="true" OnCheckedChanged="rbHistoricoEndoso_CheckedChanged" GroupName="TipoOperacion" />
            <asp:RadioButton ID="rbGenerarNuevoEndoso" runat="server" Text="Nuevo Registro" AutoPostBack="true" OnCheckedChanged="rbGenerarNuevoEndoso_CheckedChanged" GroupName="TipoOperacion" />
        </div>
        <br />
        </div>
        <br />
        <div id="DIVBloqueHistorico" runat="server">
            <br />
             <div align="center">
            <asp:ImageButton ID="btnNuevoRegistro" runat="server" ToolTip="Nuevo Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Agregar (2).png" OnClick="btnNuevoRegistro_Click" />
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Reporte de Impresión de Endoso" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
        </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                         <th scope="col"> Endoso </th>
                         <th scope="col"> Poliza </th>
                         <th scope="col"> Item </th>
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
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
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
                        <td><b>Endosos Creados:  </b><asp:Label ID="lbTotalEndosos" runat="server" Text="0"></asp:Label></td>
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
            <div class="form-check-inline">
                <asp:Label ID="lbTipoEndosoGenerar" runat="server" Text="Tipo de Endoso a Generar" CssClass="LetrasNegrita"></asp:Label><br />
                <asp:RadioButton ID="rbEndosoAclaratorio" runat="server" Text="Endoso Aclaratorio" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso Aclaratorio" OnCheckedChanged="rbEndosoAclaratorio_CheckedChanged" />
                <asp:RadioButton ID="rbEndosoLicenciaExtragero" runat="server" Text="Endoso de Licencia de Extragero" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso De Licencia de Extragero" OnCheckedChanged="rbEndosoLicenciaExtragero_CheckedChanged" />
                <asp:RadioButton ID="rbEndosoAclaratorioPAraCodundorUnico" runat="server" Text="Endoso de Conductor Unico" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso Para Conductor Unico" OnCheckedChanged="rbEndosoAclaratorioPAraCodundorUnico_CheckedChanged" />
                <asp:RadioButton ID="rbENdosoAuxilioVial" runat="server" Text="Endoso Auxilio Vial" GroupName="TipoEndoso" AutoPostBack="true" ToolTip="Generar Endoso de Auxilio Vial" OnCheckedChanged="rbENdosoAuxilioVial_CheckedChanged" />
            </div>
            <br />
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lbNumeroLicenciaExtrajero" runat="server" Text="Licencia Extrajero" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroLicenciaExtranjero" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbNombreConductorUnico" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreConductorUnico" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbCedulaConductorUnico" runat="server" Text="Cedula" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCedulaConductorUnico" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="txtCedulaConductorUnico" Mask="999-9999999-9"
                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                MaskType="Number" InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                ErrorTooltipEnabled="True"  ID="MaskedEditExtender1" />
            </div>
        </div>
         <div align="center">
            <asp:ImageButton ID="btnCompletar" runat="server" ToolTip="Completar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Completar.png" OnClick="btnCompletar_Click" />
            <asp:ImageButton ID="btnVolverAtras" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/Imagenes/volver-flecha.png" OnClick="btnVolverAtras_Click" />
        </div>
            <br />
       
    </div>

</asp:Content>
