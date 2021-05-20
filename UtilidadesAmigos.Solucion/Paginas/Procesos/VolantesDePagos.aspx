<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="VolantesDePagos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.VolantesDePagos" %>
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
            background-color: dodgerblue;
            color: white;
        }
    </style>

    <br />
    <div class="container-fluid">
        <div id="DivBloqueProceso" runat="server">
        <div class="form-row">
            <div class="form-group col-md-2">
                <asp:Label ID="lbCodigoEmpleado" runat="server" Text="Codigo de Empleado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoEmpleado" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Placeholder="Opcional" AutoPostBack="true" OnTextChanged="txtCodigoEmpleado_TextChanged" TextMode="Number"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                <asp:Label ID="lbNombreEmpleado" runat="server" Text="Nombre de Empleado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreEmpleado" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" CssClass="form-control" ToolTip="Seleccionar la Oficina correspondiente para el filtro"></asp:DropDownList>
            </div>

              <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarTipoNomina" runat="server" Text="Tipo de Nomina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlTipoNomina" runat="server" CssClass="form-control" Enabled="false" ToolTip="Seleccionar El tipo de Nomina"></asp:DropDownList>
            </div>

            <div class="form-group col-md-2">
                <asp:Label ID="lbAno" runat="server" Text="Año" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtAno" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="form-group col-md-2">
                <asp:Label ID="lbMes" runat="server" Text="Mes" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtMes" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            
            <div class="form-group form-check">
                <asp:Label ID="lbTipoNominaLetrero" runat="server" Text="Seleccionar Tipo de Nomina" CssClass="LetrasNegrita"></asp:Label><br />
                 <asp:RadioButton ID="rbPrimeraQuincena" runat="server" Text="Primera Quincena" CssClass="form-check-input" GroupName="TipoNomina" />
                 <asp:RadioButton ID="rbSegundaQuincena" runat="server" Text="Segunda Quincena" CssClass="form-check-input" GroupName="TipoNomina" />
            </div>
           
        </div>
            <br />
            <div align="center">
                <asp:Button ID="btnProcesar" runat="server" Text="Procesar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Generar Volantes de Pagos" OnClick="btnProcesar_Click" />
                <asp:Button ID="btnCodigos" runat="server" Text="Codigos"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Buscar Codigos de Empleados" OnClick="btnCodigos_Click" />
                
            </div>
            <br />
    </div>

        <div id="DivBloqueBuscarCodigo" runat="server">
            <br />
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="lbNombreEmpleadoConsulta" runat="server" Text="Nombre de Empleado" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreEmpleadoConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <br />
             <div align="center">
                <asp:Button ID="btnBuscarCodigo" runat="server" Text="Buscar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Buscar Codigos" OnClick="btnBuscarCodigo_Click" />
                 <asp:Button ID="btnVolverVolantePago" runat="server" Text="Volver"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Volver Atras" OnClick="btnVolverVolantePago_Click" />
            </div>
            <br />
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="width:10%" align="left"> SELECCIONAR </th>
                             <th style="width:10%" align="left"> CODIGO </th>
                             <th style="width:30%" align="left"> NOMBRE </th>
                             <th style="width:20%" align="left"> OFICINA </th>
                            <th style="width:20%" align="left"> DEPARTAMENTO </th>
                            <th style="width:10%" align="left"> ESTATUS </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoCodigos" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfCodigoEmpleado" runat="server" Value='<%# Eval("CodigoEmpleado") %>' />
                                    <td style="width:10%" align="left"> <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Seleccionar el Codigo" OnClick="btnSeleccionar_Click" /> </td>
                                    <td style="width:10%" align="left"> <%# Eval("CodigoEmpleado") %> </td>
                                    <td style="width:30%" align="left"> <%# Eval("Nombre") %> </td>
                                    <td style="width:20%" align="left"> <%# Eval("DescSucursal") %> </td>
                                    <td style="width:20%" align="left"> <%# Eval("DescDepto") %> </td>
                                    <td style="width:10%" align="left"> <%# Eval("Estatus") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

             <div align="center">
               <asp:Label ID="lbPaginaActualTituloVolantePago" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleVolantePago" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloVolantePago" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableVolantePago" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacionVolantePago" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaVolantePago" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaVolantePago_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorVolantePago" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorVolantePago_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionVolantePago" runat="server" OnItemCommand="dtPaginacionVolantePago_ItemCommand" OnItemDataBound="dtPaginacionVolantePago_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralVolantePago" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteVolantePago" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteVolantePago_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoVolantePago" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoVolantePago_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>
    </div>

</asp:Content>
