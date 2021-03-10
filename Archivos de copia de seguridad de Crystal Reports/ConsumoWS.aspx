<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ConsumoWS.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ConsumoWS" %>
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


    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Consultar Información de Polizas"></asp:Label>
        </div>

        <asp:Label ID="lbSeleccionarConsulta" runat="server" Text="Seleccionar Tipo de Consulta" CssClass="LetrasNegrita"></asp:Label><br />
        <div class="form-check-inline">
            <div class="form-group form-check">
               <asp:RadioButton ID="rbBuscarRamoPoliza" runat="server" Text="Identificar ramo de poliza" GroupName="WS" ToolTip="Ver a que ramo pertenece una poliza" AutoPostBack="true" OnCheckedChanged="rbBuscarRamoPoliza_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosVehiculoMotor" runat="server" Text="Vehiculo de Motor" GroupName="WS" ToolTip="Consultar datos en el ramo de Vehiculo de Motor" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosVehiculoMotor_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosFianzas" runat="server" Text="Fianzas" GroupName="WS" ToolTip="Consultar datos en el ramo de Fianzas" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosFianzas_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosFidelidad" runat="server" Text="Fidelidad" GroupName="WS" ToolTip="Consultar datos en el ramo de Fidelidad" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosFidelidad_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosIncendioAliadas" runat="server" Text="Incendio y Lineas Aliadas" GroupName="WS" ToolTip="Consultar datos en el ramo de Incendio y Aliadas" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosIncendioAliadas_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosNavesMaritimasAereas" runat="server" Text="Naves Maritimas y Aereas" GroupName="WS" ToolTip="Consultar datos en el ramo de Naves Maritimas y Aereas" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosNavesMaritimasAereas_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosRamosTecnicos" runat="server" Text="Ramos Tecnicos" GroupName="WS" ToolTip="Consultar datos en el ramo de Ramos Tecnicos" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosRamosTecnicos_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosSalud" runat="server" Text="Salud" ToolTip="Consultar datos en el ramo de Salud" GroupName="WS" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosSalud_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosTransporteCarga" runat="server" Text="Transporte de Carga" GroupName="WS" ToolTip="Consultar datos en el ramo de Transporte de Carga" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosTransporteCarga_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosVidaIndividual" runat="server" Text="Vida Individual" GroupName="WS" ToolTip="Consultar datos en el ramo de vida Individual" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosVidaIndividual_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosVidaColectivo" runat="server" Text="Vida Colectivo" GroupName="WS" ToolTip="Consultar datos en el ramo de Vida Colectivo" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosVidaColectivo_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosOdontologico" runat="server" Text="Odontologico" GroupName="WS" ToolTip="Consultar datos en el ramo de Odontologia" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosOdontologico_CheckedChanged" CssClass="form-check-input LetrasNegrita" /><br />
                <asp:RadioButton ID="rbBuscarDatosDependientes" runat="server" GroupName="WS" Text="Consultar Dependientes" ToolTip="Consultar Dependientes" AutoPostBack="true" OnCheckedChanged="rbBuscarDatosDependientes_CheckedChanged"  CssClass="form-check-input LetrasNegrita" /><br />
             <%--   <asp:RadioButton ID="RadioButton13" runat="server" Text="Identificar ramo de poliza" ToolTip="Ver a que ramo pertenece una poliza" CssClass="form-check-input LetrasNegrita" /><br />--%>
            </div>
        </div>
        <hr />
        <div align="center">
            <asp:Label ID="lbRamoPoliza" runat="server" Text="" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                 <asp:Label ID="lbNumeroPolizaControl" runat="server" Text="Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaControl" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbNumeroItemControl" runat="server" Text="Item" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtItemControl" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Number" MaxLength="10"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbNombreClienteControl" runat="server" Text="Nombre de Cliente" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreCLienteControl" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbNumeroIdentificacionControl" runat="server" Text="Numero Identificación" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroIdentificacionControl" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbAseguradoCOntrol" runat="server" Text="Nombre de Asegurado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreAseguradoCOntrol" AutoCompleteType="Disabled" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbMArcaControl" runat="server" Text="Marca" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtMarcaControl" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbModeloControl" runat="server" Text="Modelo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtModeloControl" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbChasisControl" runat="server" Text="Chasis" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtChasisControl" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
             <div class="form-group col-md-3">
                 <asp:Label ID="lbPlacaControl" runat="server" Text="Placa" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtPlacaControl" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <br />
        
        <div align="center">
         <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click" />
            <asp:Button ID="btnExportar" runat="server" Text="Buscar" ToolTip="Exportar Registros" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnExportar_Click" />
        </div>
        <br />

          <!--INICIO DEL GRID-->
        <div align="center">
            <asp:Label ID="lbTituloConsultaRamoPoliza" runat="server" Text="CONSULTAR EL RAMO DE UNA POLIZA" CssClass="Letranegrita"></asp:Label>
        </div>
    <div id="DivBloqueIdentificarRamoPoliza" runat="server">
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:50%"> <asp:Label ID="lbPolizaHeaderConsultaRamo" runat="server" Text="Poliza" CssClass="Letranegrita"  ></asp:Label> </th>
                        <th style="width:50%"> <asp:Label ID="lbRamoGeaderConsultaPoliza" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label> </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpConsultaRamoPoliza" runat="server">
                        <ItemTemplate>
                            <tr class="Letranegrita">
                                <td style="width:50%"> <%# Eval("Poliza") %> </td>
                                <td style="width:50%"> <%# Eval("Ramo") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

        <div id="DivBloqueConsultaVehiculoMotor" runat="server">
             <div align="center">
            <asp:Label ID="Label1" runat="server" Text="CONSULTAR DATOS EN VEHICULO DE MOTOR" CssClass="Letranegrita"></asp:Label>
                 <br />
                 <asp:Label ID="lbCantidadregistrosTituloVehiculomotor" runat="server" Text="Cantidad de registros ( " CssClass="Letranegrita"></asp:Label>
                 <asp:Label ID="lbCantidadregistrosvariableVehiculomotor" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                 <asp:Label ID="lbCantidadregistrosCerrarVehiculomotor" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>
                 <br />
        </div>
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th align="center" style="width:10%"> <asp:Label ID="lbDetalleVehiculoMoor" runat="server" Text="Detalle" CssClass="Letranegrita"></asp:Label> </th>
                            <th align="center" style="width:10%"> <asp:Label ID="lbPolizaVehiculoMotor" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label> </th>
                            <th align="center" style="width:35%"> <asp:Label ID="lbClienteVehiculoMotor" runat="server" Text="Cliente" CssClass="Letranegrita"></asp:Label> </th>
                            <th align="center" style="width:10%"> <asp:Label ID="lbInicioVehiculoMotor" runat="server" Text="Inicio" CssClass="Letranegrita"></asp:Label> </th>
                            <th align="center" style="width:10%"> <asp:Label ID="lbFinVehiculoMotor" runat="server" Text="Fin" CssClass="Letranegrita"></asp:Label> </th>
                            <th align="center" style="width:5%"> <asp:Label ID="lbEstatusVehiculoMotor" runat="server" Text="Estatus" CssClass="Letranegrita"></asp:Label> </th>
                            <th align="center" style="width:10%"> <asp:Label ID="lbChasisVehiculoMotor" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label> </th>
                            <th align="center" style="width:10%"> <asp:Label ID="lbPlacavehiculoMotor" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label> </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListadoVehiculomotor" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfPolizaVehiculoMotor" runat="server" Value='<%# Eval("Poliza") %>' />
                                    <asp:HiddenField ID="hfItenVehiculoMotor" runat="server" Value='<%# Eval("Item") %>' />
                                    <asp:HiddenField ID="hfNombreClienteVehiculoMotor" runat="server" Value='<%# Eval("Cliente") %>' />
                                    <asp:HiddenField ID="hfNumeroIdentificacionVehiculomotor" runat="server" Value='<%# Eval("RNC") %>' />
                                    <asp:HiddenField ID="hfNombreAseguradoVehiculoMotor" runat="server" Value='<%# Eval("Nombre_Asegurado") %>' />
                                    <asp:HiddenField ID="hfChasisVehiculoMotor" runat="server" Value='<%# Eval("Chasis") %>' />
                                    <asp:HiddenField ID="hfPlacaVehiculoMotor" runat="server" Value='<%# Eval("Placa") %>' />

                                     <td style="width:10%"> <asp:Button ID="btnDetalleVehiculoMotor" runat="server" Text="Detalle" ToolTip="Mostrar el Detalle de Vehiculo de Motor" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnDetalleVehiculoMotor_Click" />  </td>
                                     <td style="width:10%"> <%# Eval("Poliza") %> </td>
                                     <td style="width:35%"> <%# Eval("Cliente") %> </td>
                                     <td style="width:10%"> <%# Eval("Inicio") %> </td>
                                     <td style="width:10%"> <%# Eval("Fin") %> </td>
                                     <td style="width:5%"> <%# Eval("Estatus") %>  </td>
                                     <td style="width:10%"> <%# Eval("Chasis") %> </td>
                                     <td style="width:10%"> <%# Eval("Placa") %> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

             <div align="center">
                <asp:Label ID="lbPaginaActualTituloVehiculoMotor" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableVehiculoMotor" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloVehiculoMotor" runat="server" Text="De " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableVehiculoMotor" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>

             <div id="DivPaginacionVehiculoMotor" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:LinkButton ID="LinkPrimeraVehiculoMotor" runat="server" Text="Primero" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraVehiculoMotor_Click" CssClass="btn btn-outline-success btn-sm"  ></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkAnteriorVehiculoMotor" runat="server" Text="Anterior" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorVehiculoMotor_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td>
                                <asp:DataList ID="dtPaginacionVehiculoMotor" runat="server" OnCancelCommand="dtPaginacionVehiculoMotor_CancelCommand" OnItemDataBound="dtPaginacionVehiculoMotor_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkIndiceVehiculoMotor" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="NuevaPagina" Text='<%# Eval("TextoPagina")%>' Width="20px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:LinkButton ID="LinkSiguienteVehiculoMotor" runat="server" Text="Siguiente" ToolTip="Ir la Siguiente pagina del listado" OnClick="LinkSiguienteVehiculoMotor_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                            <td> <asp:LinkButton ID="LinkUltimoVehiculoMotor" runat="server" Text="Ultmo" ToolTip="Ir a la Ultima Pagina del listado" OnClick="LinkUltimoVehiculoMotor_Click" CssClass="btn btn-outline-success btn-sm"></asp:LinkButton> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
            <br />
        </div>
        <br /><br />
    <!--FIN DEL GRID-->
    </div>
</asp:Content>
