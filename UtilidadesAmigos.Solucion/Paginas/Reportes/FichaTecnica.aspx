<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="FichaTecnica.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.FichaTecnica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">

        .btn-sm{
            width:90px;
        }

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        .BotonImagen {
               width:50px;
               height:50px;
           }
    </style>

    <script type="text/javascript">
        function CamposFechaVacios() {
            alert("Los campos de fecha no pueden estar vacio para realizar este proceso, favor de verificar.");
        }
        function FechaDesdeVacio() {
            $("#<%=txtFechaDesde.ClientID%>").css("border-color", "red");
        }
        function FechaHastaVacio() {
            $("#<%=txtFechaTasta.ClientID%>").css("border-color", "red");
        }
    </script>

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-md-6">
                 <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaTasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
               <div class="col-md-2">
                 <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" ></asp:TextBox>
            </div>
            <div class="col-md-6">
                 <asp:Label ID="lbNombreSupervisor" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>
            <div class="col-md-4">
                 <asp:Label ID="lbOficina" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddloficina" runat="server" CssClass="form-control" ToolTip="Seleccionar Oficina Para Filtro"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Por Pantalla" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
            <asp:ImageButton ID="btnReporteGeneral" runat="server" ToolTip="Reporte General de Supervisores" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporteGeneral_Click" />
        </div>
        <br /><br />
        <table class="table table-striped">
            <thead class="table-dark">
                <tr>
                    <th scope="col"> Codigo </th>
                    <th scope="col"> Supervisor </th>
                    <th  scope="col">  </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoSupervisores" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td> <%# Eval("CodigoSupervisor") %> </td>
                            <td> <%# Eval("Nombre") %> </td>
                            <td align="right" > <asp:ImageButton ID="btnReporteUnico" runat="server" ToolTip="Reporte Unico de Supervisores" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporteUnico_Click" /> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
         <table class="table">
                 <tfoot class="table-light">
                    <tr>
                         <td align="right">Pag <asp:Label ID="lbPaginaActual" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> de <asp:Label ID="lbCantidadPaginas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
           
            <div id="DivPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Click" ImageUrl="~/Imagenes/Anterior.png" />  </td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_Click" ImageUrl="~/Imagenes/Siguiente.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
    </div>
</asp:Content>
