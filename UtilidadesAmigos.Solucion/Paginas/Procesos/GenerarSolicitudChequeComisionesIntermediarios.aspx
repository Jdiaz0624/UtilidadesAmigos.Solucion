<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarSolicitudChequeComisionesIntermediarios.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarSolicitudChequeComisionesIntermediarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style type="text/css">
        .btn-sm{width:100px;}
        .LetrasNegrita {font-weight:bold;}
        th {
            background-color: dodgerblue;
            color: white;
        }
    </style>

    <script type="text/javascript">
        function CamposFechaVacios() {
            alert("Los campos Fecha no pueden estar vacios para realizar esta operación, favor de verificar.");
        }
        function CampoFechaDesdeVacio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }
        function CampoFechaHastaVacio() {
            $("#<%=txtFechaHasta.ClientID%>").css("border-color", "red");
        }

        $(document).ready(function () {
            //VALIDAMOS EL BOTON CONSULTA
            $("#<%=btnConsultar.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para consultar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para consultar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para consultar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            //VALIDAMOS EL BOTON EXPORTAR
            $("#<%=btnExportar.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para exportar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para exportar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para exportar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            //VALIDAMOS EL BOTON PROCESAR
            $("#<%=btnProcesar.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para procesar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para procesar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para procesar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            //VALIDAMOS EL BOTON PRIMERO DE LA PAGINACION
            $("#<%=LinkPrimeraPagina.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para Consultar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para Consultar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para Consultar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            //VALIDAMOS EL BOTON ANTERIOR DE LA PAGINACION
            $("#<%=LinkAnterior.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para Consultar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para Consultar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para Consultar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            //VALIDAMOS EL BOTON SIGUIENTE DE LA PAGINACION
            $("#<%=LinkSiguiente.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para Consultar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para Consultar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para Consultar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            //VALIDAMOS EL BOTON ULTIMO DE LA PAGINACION
            $("#<%=LinkUltimo.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para Consultar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para Consultar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para Consultar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

            //VALIDAMOS LOS NUMEROS DEL CENTRO
            $("#<%=dtPaginacion.ClientID%>").click(function () {
                var CodigoIntermediario = $("#<%=txtCodigoIntermediario.ClientID%>").val().length;
                if (CodigoIntermediario < 1) {
                    alert("El campo codigo de intermediario no puede estar vacio para Consultar esta informción, favor de verificar.");
                    $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Tasa = $("#<%=txttasa.ClientID%>").val().length;
                    if (Tasa < 1) {
                        alert("El campo tasa no puede estar vacio para Consultar esta información, favor de verificar.");
                        $("#<%=txttasa.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var MontoMinimo = $("#<%=txtMontoMinimo.ClientID%>").val().length;
                        if (MontoMinimo < 1) {
                            alert("El campo monto minimo no puede estar vacio para Consultar esta información, favor de verificar.");
                            $("#<%=txtMontoMinimo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });

        })
    </script>
    <div class="container-fluid">
        <br /><br />
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:RadioButton ID="rbNoEndosable" runat="server" Text="No Endosable" GroupName="TipoCheque" ToolTip="Generar el tipo de cheque de manera no endosable." CssClass="form-check-input LetrasNegrita" />
                 <asp:RadioButton ID="rbEndosable" runat="server" Text="Endosable" GroupName="TipoCheque" ToolTip="Generar el tipo de cheque de manera endosable." CssClass="form-check-input LetrasNegrita" />
            </div>
        </div>
        <br />
         <div class="form-check-inline">
            <div class="form-group form-check">
              <asp:CheckBox ID="cbGenerarSolicitudPorLote" runat="server" Text="Generar Solicitudes por Lote" CssClass="form-check-input LetrasNegrita" AutoPostBack="true" OnCheckedChanged="cbGenerarSolicitudPorLote_CheckedChanged" ToolTip="Generar las solicitudes de cheques por lotes" />
             <asp:Label ID="lbLetreroRojo" runat="server" Text="Este proceso puede tardar 5 Minutos o mas dependiendo de la cantidad de registros a procesar" Visible="false" CssClass="LetrasNegrita" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <br />

        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbTomarCuentaMontosAcmulativos" runat="server" Text="Tomar en cuenta montos acumulativos" CssClass="form-check-input LetrasNegrita" ToolTip="Tomar en cuenta los montos acumulados de las comisiones pasadas." />
            </div>
        </div>
        <br /><br />
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediario" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarBanco" runat="server" Text="Seleccionar Banco" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarBanco" runat="server" ToolTip="Seleccionar Banco" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Seleccionar Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarRamo" runat="server" Text="Seleccionar Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-2">
                <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txttasa" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
            </div>

             <div class="form-group col-md-2">
                <asp:Label ID="lbMontoMinimo" runat="server" Text="Monto Minimo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtMontoMinimo" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultar_Click" ToolTip="Consultar Información por pantalla." />
             <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnExportar_Click" ToolTip="Exportar Información a Excel." />
             <asp:Button ID="btnProcesar" runat="server" Text="Procesar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnProcesar_Click" ToolTip="Realizar Proceso de Solicitud de cheques." />
            <br />
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text=" 0 " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" ) " CssClass="LetrasNegrita"></asp:Label>
            <br />
        </div>

        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:10%" align="left"> <asp:Label ID="lbGenerarSolicitudHeaderRepeater" runat="server" Text="Generar" CssClass="LetrasNegrita" > </asp:Label></th>
                        <th style="width:40%" align="left"> <asp:Label ID="lbNombreIntermediarioHeaderRepeater" runat="server" Text="Nombre" CssClass="LetrasNegrita" ></asp:Label> </th>
                        <th style="width:20%" align="left"> <asp:Label ID="lbBancoHeaderRepeater" runat="server" Text="Banco" CssClass="LetrasNegrita" ></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbMontoHeaderRepeater" runat="server" Text="Monto" CssClass="LetrasNegrita" ></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbAcumuladoAnteriorHeaderRepeater" runat="server" Text="Acumulado" CssClass="LetrasNegrita" ></asp:Label> </th>
                        <th style="width:10%" align="left"> <asp:Label ID="lbTotalHeaderRepeater" runat="server" Text="Total" CssClass="LetrasNegrita" ></asp:Label> </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoRegistrosComisiones" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfCodigoIntermediario" runat="server" Value='<%# "CodigoIntermediario" %>' />
                                <td style="width:10%"> <asp:Button ID="btnSeleccionarSeleccionarRegistro" runat="server" Text="Generar" ToolTip="Generar solicitud de chqeue" OnClick="btnSeleccionarSeleccionarRegistro_Click" CssClass="btn btn-outline-secondary btn-sm" /> </td>
                                <td style="width:40%"> <%# Eval("NombreIntermediario") %> </td>
                                <td style="width:20%"> <%# Eval("Banco") %> </td>
                                <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Monto")) %> </td>
                                <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Acumulado")) %> </td>
                                <td style="width:10%"> <%#string.Format("{0:n2}", Eval("Total")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

         <div align="center">
                <asp:Label ID="lbPaginaActualTitulo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavle" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTitulo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariable" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPagina" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPagina_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnterior" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnterior_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguiente" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguiente_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimo" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimo_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
    </div>
</asp:Content>
