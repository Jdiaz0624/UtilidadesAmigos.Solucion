<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReciboDigital.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.ReciboDigital" %>
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
        <br />
        <div id="DIVBloqueReciboDigitalConsulta" runat="server">
            <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lbCodigoIntermediarioConsulta" runat="server" Text="Intermediario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermedirioConsulta" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoIntermedirioConsulta_TextChanged"></asp:TextBox>
                </div>
                  <div class="col-md-4">
                    <asp:Label ID="lbNombreIntermediarioCOnsulta" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediarioConsulta" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                 <div class="col-md-3">
                    <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="Desde" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesdeCosulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                 <div class="col-md-3">
                    <asp:Label ID="lbFechaHAstaCOnsulta" runat="server" Text="HAsta" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHastaConsulta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                  <div class="col-md-2">
                    <asp:Label ID="lbSupervisorConsulta" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtSupervisorConsulta"  runat="server"  AutoCompleteType="Disabled" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtSupervisorConsulta_TextChanged" ></asp:TextBox>
                </div>

                  <div class="col-md-4">
                    <asp:Label ID="lbNombreSupervisorConsulta" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisorConsulta" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                  <div class="col-md-4">
                    <asp:Label ID="lbTipoPagoConsulta" runat="server" Text="Tipo de Pago" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlTipoPagoConsulta" runat="server" ToolTip="Seleccionar el Tipo de Pago" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="form-check-inline">
                <asp:Label ID="lbTipoReporte" runat="server" Text="Formato de Reporte: " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="FormatoReporte" ToolTip="Generar Reporte en PDF" />
                <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="FormatoReporte" ToolTip="Generar Reporte en Excel" />
                <asp:RadioButton ID="rbExcelPlano" runat="server" Text="Excel Plano" GroupName="FormatoReporte" ToolTip="Generar Reporte en Excel Plano" />
            </div>
            <br />
      
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
                <asp:ImageButton ID="btnNuevoRegistro" runat="server" ToolTip="Crear Nuevo registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Agregar (2).png" OnClick="btnNuevoRegistro_Click" />
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
                <asp:ImageButton ID="btnRestablecer" runat="server" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" ImageUrl="~/Imagenes/auto.png" OnClick="btnRestablecer_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead class="table table-dark">
                    <tr>
                        <th scope="col"> No. </th>
                        <th scope="col"> Fecha </th>
                        <th scope="col"> Hora </th>
                        <th scope="col"> Intermediario </th>
                        <th scope="col"> Valor </th>
                        <th scope="col"> Tipo </th>
                        <th scope="col">  </th>
                        <th scope="col">  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoREcibos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroRecibo" runat="server" Value='<%# Eval("NumeroRecibo") %>' />

                                <td> <%# Eval("NumeroRecibo") %> </td>
                                <td> <%# Eval("Fecha") %> </td>
                                <td> <%# Eval("Hora") %> </td>
                                <td> <%# Eval("Intermediario") %> </td>
                                <td> <%#string.Format("{0:N2}", Eval("ValorRecibo")) %> </td>
                                <td> <%# Eval("TipoPago") %> </td>
                                <td align="right">  <asp:ImageButton ID="btnRecibo" runat="server" ToolTip="Generar Recibo" CssClass="BotonImagen" ImageUrl="~/Imagenes/pdf.png" OnClick="btnRecibo_Click" /> </td>
                                <td align="right">  <asp:ImageButton ID="DirectoImpresora" runat="server" ToolTip="Imprimir Directo a la Impresora" CssClass="BotonImagen" ImageUrl="~/Imagenes/impresora.png" OnClick="DirectoImpresora_Click" /> </td>
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

        <div id="BloqueReciboDigitalMantenimiento" runat="server">
            <asp:Label ID="lbIdRegistroSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
             <asp:Label ID="lbAccionTomar" runat="server" Text="" Visible="false"></asp:Label>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Intermediario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediario"  runat="server"  AutoCompleteType="Disabled" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" ></asp:TextBox>
                </div>

                  <div class="col-md-4">
                    <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                 <div class="col-md-2">
                    <asp:Label ID="lbValorAplicar" runat="server" Text="Valor" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtValorAplicar" runat="server" step="0.01" CssClass="form-control" TextMode="Number" ></asp:TextBox>
                </div>
                 <div class="col-md-4">
                    <asp:Label ID="lbTipoPago" runat="server" Text="Tipo de pago" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarTipoPago" runat="server" ToolTip="Seleccionar el Tipo de Pago" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-12">
                    <asp:Label ID="lbDetalle" runat="server" Text="Detalle" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtDetalle" runat="server" Height="50px" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                </div>

               

            </div>
            <br />
             <div align="center">
                <asp:ImageButton ID="btnGuardar" runat="server" ToolTip="Guardar Información" CssClass="BotonImagen" ImageUrl="~/Imagenes/salvar.png" OnClick="btnGuardar_Click" />
                <asp:ImageButton ID="btnVolver" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/Imagenes/volver-flecha.png" OnClick="btnVolver_Click" />

            </div>
            <br />
        </div>
    </div>
</asp:Content>
