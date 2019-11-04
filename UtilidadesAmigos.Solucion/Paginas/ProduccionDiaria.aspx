<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionDiaria.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionDiaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Estilos/EstilosPaginas.css" rel="stylesheet" type="text/css" />
    <header class="Encabezado">

    <div  align="center">
        <h1><asp:Label ID="llbENcabezado" class="Label-Encabezado" Text="Produccion Diaria" runat="server"></asp:Label></h1>
    </div>
    <hr />
</header>
    <main class="Cuerpo">
        <div class="Box">

        <div>
            <asp:Label ID="lbNombreArchivo" runat="server" Text="Nombre del Archivo" CssClass="Label"></asp:Label>
            <asp:TextBox ID="txtNombreArchivo" runat="server" placeholder="Nombre del archivo" CssClass="Caja-Texto-Login"></asp:TextBox>
        </div>
       <div class="prueba">
           
           <asp:Label ID="llbFechaDesde" class="Label" runat="server" Text="Fecha Desde"></asp:Label>
           <asp:TextBox ID="txtFechaDesde" class="Texbox-Fecha" runat="server" Text="Fecha Desde" TextMode="Date"></asp:TextBox>
           <asp:Label ID="llbFechaHasta" class="Label" runat="server" Text="Fecha Hasta"></asp:Label>
           <asp:TextBox ID="txtFechaHasta" class="Texbox-Fecha" runat="server" Text="Fecha Hasta" TextMode="Date"></asp:TextBox>
       </div>
                <div>
                    <asp:RadioButton ID="rbConRamo" GroupName="Radio-Grupo1" runat="server" Text="Especificar Ramo" class="Radio" ToolTip="Selecciona esta opcion si quieres espesificar el ramo para la consulta" OnCheckedChanged="rbConRamo_CheckedChanged" AutoPostBack="True"  />
                    <asp:RadioButton ID="rbSinRamo" GroupName="Radio-Grupo1" runat="server" Text="No Especificar Ramo" class="Radio" ToolTip="Selecciona esta opcion si no quieres espesificar el ramo para la consulta" OnCheckedChanged="rbSinRamo_CheckedChanged" AutoPostBack="True" />

                </div>
            <div>
                <asp:Label ID="llbConcepto" runat="server" Text="Concepto" Visible="False"></asp:Label>
                <asp:Label ID="llbRamo" runat="server" Text="Ramo" Visible="False"></asp:Label>
            </div>
        <div>
            <asp:Label ID="llbSeleccionar" class="Label" runat="server" Text="Seleccionar Ramo"></asp:Label>
            <asp:DropDownList ID="ddlRamo" class="combobox" runat="server" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:Label ID="lbConcepto" runat="server" Text="Concepto" Visible="false"></asp:Label>
            <asp:Label ID="lbRamo" runat="server" Text="Ramo" Visible="false"></asp:Label>
        </div>

            
                
         
            </div>
        <div>
            <asp:Button ID="btnBuscar" class="Botones" ToolTip="Buscar registros" runat="server" Text="Buscar Registros" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnExportarExel" ToolTip="Exportar a excel" class="Botones" runat="server" Text="Exportar a Exel" OnClick="btnExportarExel_Click" />
            <asp:Button ID="btnAtras" ToolTip="Atras" CssClass="Botones" runat="server" Text="Atras" OnClick="btnAtras_Click" Visible="false" />
        </div>
        <div>
           
               


            
            <asp:GridView id="gbListado" runat="server" AllowPaging="True" OnPageIndexChanging="gbListado_PageIndexChanging" OnSelectedIndexChanged="gbListado_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="98%">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:BoundField DataField="FacturadoPesos" HeaderText="Facturado Pesos" />
                    <asp:BoundField DataField="FacturadoDollar" HeaderText="Facturado Dollar" />
                    <asp:BoundField DataField="facturadoTotal" HeaderText="Facturado Total" />
                    <asp:BoundField DataField="FacturadoNeto" HeaderText="Facturado Neto" />
                    <asp:CommandField ButtonType="Button" HeaderText="Detalle" SelectText="Ver" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>


            <asp:GridView id="gbProduccionDiariaDetalle" runat="server" Class="grilla" AllowPaging="True" OnSelectedIndexChanged="gbProduccionDiariaDetalle_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" Width="100%" Visible="False">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
                    <asp:BoundField DataField="Subramo" HeaderText="Sub Ramo" />
                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="FacturadoPesos" HeaderText="Facturado Pesos" />
                    <asp:BoundField DataField="FacturadoDollar" HeaderText="Facturado Dollar" />
                    <asp:BoundField DataField="FacturadoTotal" HeaderText="Facturado Total" />
                    <asp:BoundField DataField="FacturadoNeto" HeaderText="Facturado Neto" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
            <div align="center">
                <asp:Button ID="btnprueba" runat="server" ToolTip="Exportar a Exel" Text="Exportar Detalle a Exel" CssClass="Botones" OnClick="btnprueba_Click" Visible="False" /><br />
                <asp:Label ID="lbNombreArchivoDetalle" runat="server" Text="Nombre Archivo" CssClass="Label" ForeColor="Red" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label>
            </div>

            <%--Este Grid Solo es para exportar los datos a exel, hasta que se encuentre otra forma de bajar los datos sin la
            necesidad de utilizar un grid oculto para realizar esta accion.--%>


        </div>
    </main>
    </asp:Content>

