<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarReporteAntiguedadSaldo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarReporteAntiguedadSaldo" %>
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
        function CampoFechaCorteVacio() {
            alert("El campo Fecha de Corte no puede estar vacio para buscar esta información, favor de verificar.");
            $("#<%=txtFechaCorte.ClientID%>").css("border-color", "red");
        }
    </script>

    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbFechaCorte" runat="server" Text="Fecha de Corte" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaCorte" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbNumeroFactura" runat="server" Text="No. Factura" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroFactura" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPoliza" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbRamo" runat="server" Text="Ramo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlRamo" runat="server" ToolTip="Seleccionar Ramo para la consulta" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbTasa" runat="server" Text="Tasa" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtTasa" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbTipo" runat="server" Text="Tipo" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlTipo" runat="server" ToolTip="Seleccionar Tipo para la consulta" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbCodigoCliente" runat="server" Text="No. Cliente" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoCliente" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoCliente_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbNombreCliente" runat="server" Text="Cliente" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreCliente" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="No. Vendedor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediario" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbNombreIntermediario" runat="server" Text="Vendedor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="No. Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbNombreSupervisor" runat="server" Text="Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisor" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbOficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlOficina" runat="server" ToolTip="Seleccionar Oficina    para la consulta" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="col-md-3">
                <asp:Label ID="lbMoneda" runat="server" Text="Moneda" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlMoneda" runat="server" ToolTip="Seleccionar Moneda para la consulta" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div align="center">
             <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Informacón por Pantalla" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
             <asp:ImageButton ID="btnGenerarExcel" runat="server" ToolTip="Consultar Informacón por Pantalla" CssClass="BotonImagen" ImageUrl="~/Imagenes/excel.png" OnClick="btnGenerarExcel_Click" />
            <br />
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Registros Encontrados (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <br />
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col"> Asegurado </th>
                    <th scope="col"> Tipo </th>
                    <th scope="col"> Poliza </th>
                    <th scope="col"> Facturado </th>
                    <th scope="col"> Cobrado </th>
                    <th scope="col"> Balance </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoAntiguedad" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td> <%# Eval("Asegurado") %> </td>
                            <td> <%# Eval("DescripcionTipo") %> </td>
                            <td> <%# Eval("Poliza") %> </td>
                            <td> <%#string.Format("{0:N2}", Eval("ValorFactura")) %> </td>
                            <td> <%#string.Format("{0:N2}", Eval("ValorPagado")) %> </td>
                            <td> <%#string.Format("{0:N2}", Eval("Balance")) %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        
         <div align="center">
                <asp:Label ID="lbPaginaActualTituloListadoAntiguedadSaldo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableListadoAntiguedadSaldo" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloListadoAntiguedadSaldo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableListadoAntiguedadSaldo" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionListadoAntiguedadSaldo" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaListadoAntiguedadSaldo" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaListadoAntiguedadSaldo_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorListadoAntiguedadSaldo" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorListadoAntiguedadSaldo_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionListadoAntiguedadSaldo" runat="server" OnItemCommand="dtPaginacionListadoAntiguedadSaldo_ItemCommand" OnItemDataBound="dtPaginacionListadoAntiguedadSaldo_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteListadoAntiguedadSaldo" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteListadoAntiguedadSaldo_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoListadoAntiguedadSaldo" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoListadoAntiguedadSaldo_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
    </div>

 
</asp:Content>
