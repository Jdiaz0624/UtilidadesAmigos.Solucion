<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="EstadisticaRenovacion.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Consulta.EstadisticaRenovacion" %>
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
              width: 40px;
              height: 40px;
          }
    </style>

    <script type="text/javascript">
        function CamposFechaVacios() {
            alert("Los campos fecha no pueden estar vacios para realizar este proceso, favor de verificar.");
        }
        function CampoFechaDesdeVacio() {

            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }

        function CampoFechaHastaVacio() {

            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }

        function CamposNoEncontrados() {
            alert("No se encontraron registros con los parametros ingresados favor de validar.");
        }
    </script>

    <div class="container-fluid">
        <br />
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <div id="DIVBloqueConsultaPrincipal" runat="server">
            <div class="row">
                 <div class="col-md-6">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                 <div class="col-md-6">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarRamo_SelectedIndexChanged" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbSeleccionarSubRamo" runat="server" Text="Sub Ramo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarSubramo" runat="server" ToolTip="Seleccionar Sub Ramo" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Id Intermediario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediario" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                 <div class="col-md-3">
                    <asp:Label ID="lbNombreIntermediario" runat="server" Text="Intermediario" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Id Supervisor" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisor" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                 <div class="col-md-3">
                    <asp:Label ID="lbNombreSupervisor" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisor" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                  <div class="col-md-3">
                    <asp:Label ID="lbCodigoCliente" runat="server" Text="Id Cliente" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoCliente" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoCliente_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbNombreCliente" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreCliente" runat="server" Enabled="false" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>

            <br />
            <div class="form-check-inline">
                <asp:Label ID="lbAgrupadoPor" runat="server" Text="Agrupado Por: " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbNoAgrupar" runat="server" Text="No Agrupar" GroupName="AgrupadoPor" ToolTip="No Agrupar Información" />
                <asp:RadioButton ID="rbOficina" runat="server" Text="Oficina"  GroupName="AgrupadoPor" ToolTip="Agrupar por Oficina" />
                <asp:RadioButton ID="rbRamo" runat="server" Text="Ramo"  GroupName="AgrupadoPor" ToolTip="Agrupar por Ramo" />
                <asp:RadioButton ID="rbSubRamo" runat="server" Text="Sub Ramo"  GroupName="AgrupadoPor" ToolTip="Agrupar por Sub Ramo" />
                <asp:RadioButton ID="rbIntermediario" runat="server" Text="Intermediario"  GroupName="AgrupadoPor" ToolTip="Agrupar por Intermediario" />
                <asp:RadioButton ID="rbSupervisor" runat="server" Text="Supervisor"  GroupName="AgrupadoPor" ToolTip="Agrupar por Supervisor" />
                <asp:RadioButton ID="rbDetalle" runat="server" Text="Detalle"  GroupName="AgrupadoPor" ToolTip="Mostrar Detalle" />
            </div>
            <br />
             <div class="form-check-inline">
                <asp:Label ID="lbFormatoReporte" runat="server" Text="Formato: " CssClass="LetrasNegrita"></asp:Label>
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF"  GroupName="Formato" ToolTip="Generar Reporte en PDF" />
                <asp:RadioButton ID="rbEXcel" runat="server" Text="Excel"  GroupName="Formato" ToolTip="Generar Reporte en Excel" />
                <asp:RadioButton ID="rbWord" runat="server" Text="Word"  GroupName="Formato" ToolTip="Generar Reporte en Word" />
            </div>
            <br />
            <div class="form-check-inline">
                <asp:CheckBox ID="cbExcluirMotores" runat="server" Text="Excluir Motores" AutoPostBack="true" CssClass="LetrasNegrita" OnCheckedChanged="cbExcluirMotores_CheckedChanged"  />
                <asp:CheckBox ID="cbRetenerInformacion" runat="server" CssClass="LetrasNegrita" Text="Retener Información" ToolTip="Retener la Data cargada" Visible="false" />
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnBuscar" runat="server" ToolTip="Buscar Información" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnBuscar_Click" />
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Entidad </th>
                         <th scope="col"> C. Renovaciones </th>
                         <th scope="col"> M. Renovaciones </th>
                         <th scope="col"> C. Renovadas </th>
                         <th scope="col"> M. Renovadas </th>
                         <th scope="col"> C. Canceladas </th>
                         <th scope="col"> M. Cancelado </th>
                        <th scope="col"> Cobrado </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpEstadisticaRenovacion" runat="server">
                        <ItemTemplate>
                            <tr>
                                 <td> <%# Eval("Entidad") %> </td>
                                 <td> <%#string.Format("{0:N0}", Eval("CantidadARenovar")) %> </td>
                                 <td> <%#string.Format("{0:N2}", Eval("MontoARenovar")) %> </td>
                                 <td> <%#string.Format("{0:N0}", Eval("CantidadRenovadas")) %> </td>
                                 <td> <%#string.Format("{0:N2}", Eval("MontoRenovado")) %> </td>
                                 <td> <%#string.Format("{0:N0}", Eval("CantidadCanceladas")) %> </td>
                                 <td> <%#string.Format("{0:N2}", Eval("MontoCancelado")) %> </td>
                                 <td> <%#string.Format("{0:N2}", Eval("Cobrado")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

             <div align="center">
                <asp:Label ID="lbPaginaActualEstadisticaRenovacion" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableEstadisticaRenovacion" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloEstadisticaRenovacion" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableEstadisticaRenovacion" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionEstadisticaRenovacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaEstadisticaRenovacion" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaEstadisticaRenovacion_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorEstadisticaRenovacion" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorEstadisticaRenovacion_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionEstadisticaRenovacion" runat="server" OnItemCommand="dtPaginacionEstadisticaRenovacion_ItemCommand" OnItemDataBound="dtPaginacionEstadisticaRenovacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteEstadisticaRenovacion" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteEstadisticaRenovacion_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoEstadisticaRenovacion" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoEstadisticaRenovacion_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        </div>
    </div>
</asp:Content>
