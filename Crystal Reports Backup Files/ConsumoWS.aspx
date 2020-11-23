<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ConsumoWS.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ConsumoWS" %>
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
    <div class="container-fluid">
            <asp:GridView ID="gvListadoPantalla" runat="server" AllowPaging="true" OnPageIndexChanging="gvListadoPantalla_PageIndexChanging" OnSelectedIndexChanged="gvListadoPantalla_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:BoundField DataField="Poliza" HeaderText="ID" />
                    <asp:BoundField DataField="Item" HeaderText="Sucursal" />
                    <asp:BoundField DataField="Cliente" HeaderText="Oficina" />
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
    </div>
</asp:Content>
