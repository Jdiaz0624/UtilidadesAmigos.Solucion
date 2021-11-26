<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoDependientes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoDependientes" %>
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
        
        .BotonEspecial {
           width:100%;
           font-weight:bold;
          }

        th {
            background-color: #1E90FF;
            color: #000000;
        }

        .BotonSolicitud {
                width:50px;
               height:50px;
           }
        .BotonImagen {
                width:50px;
               height:50px;
           }
    </style>


    <script type="text/javascript">
        function OpcionNoDisponible() { alert("Esta Opción esta en desarrollo por el momento."); }

        $(document).ready(function () {

            $("#<%=btnConsultarRegistros.ClientID%>").click(function () {
                var Poliza = $("#<%=txtNumeroPolizaConuslta.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo Poliza no puede estar vacio para buscar dependientes, favor de verificar.");
                    $("#<%=txtNumeroPolizaConuslta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

            $("#<%=btnExportarInformacion.ClientID%>").click(function () {
                var Poliza = $("#<%=txtNumeroPolizaConuslta.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("El campo Poliza no puede estar vacio para Exportar dependientes, favor de verificar.");
                    $("#<%=txtNumeroPolizaConuslta.ClientID%>").css("border-color", "red");
                    return false;
                }
            });
        })
    </script>
    <div class="container-fluid">
        <div id="DIVBloqueCOnsulta" runat="server">
            <br />
            <div class="row">
                <div class="d-inline-flex col-md-6">
                    <asp:Label ID="lbNumeroPolizaConsulta" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroPolizaConuslta" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:ImageButton ID="btnConsultarRegistros" runat="server" OnClick="btnConsultarRegistros_Click" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" />
                    <asp:ImageButton ID="btnExportarInformacion" runat="server" OnClick="btnExportarInformacion_Click" CssClass="BotonImagen" ImageUrl="~/Imagenes/excel.png" />
                    <asp:ImageButton ID="btnAgregarDependiente" runat="server" Visible="false" OnClick="btnAgregarDependiente_Click" CssClass="BotonImagen" ImageUrl="~/Imagenes/Agregar (2).png" />
                </div>
            </div>
            <br />
            <div id="DivEstatusPoliza" runat="server" align="center">
                <asp:Label ID="lbEstatusPolizaTitulo" runat="server" Text="Estatus (" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbEstatusPolizaVariable" runat="server" Text=" " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbEstatusPolizaCerrar" runat="server" Text=")" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbSeparador1" runat="server" CssClass="Letranegrita" Text=" | "></asp:Label>

                <asp:Label ID="lbRamoTitulo" runat="server" Text="Ramo (" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbRamoVariable" runat="server" Text=" " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbRamoCerrar" runat="server" Text=")" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbSeparador2" runat="server" CssClass="Letranegrita" Text=" | "></asp:Label>

                <asp:Label ID="lbSubRamoTitulo" runat="server" Text="Sub Ramo (" CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbSubRamoVariable" runat="server" Text=" " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbSubRamoCerrar" runat="server" Text=")" CssClass="Letranegrita"></asp:Label>
            </div>
            <hr />
            <br />
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Nombre </th>
                        <th scope="col"> Parentezco </th>
                        <th scope="col"> Cedula </th>
                        <th scope="col"> Fecha Nac </th>
                        <th scope="col"> Sexo </th>
                        <th scope="col"> Prima </th>
                        <th scope="col"> Editar </th>
                        <th scope="col"> Borrar </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadodepenientes" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroCotizacion" runat="server" Value='<%# Eval("Cotizacion") %>' />
                                <asp:HiddenField ID="hfIdAsegurao" runat="server" Value='<%# Eval("IdAsegurado") %>' />

                                <td> <%# Eval("Nombre") %> </td>
                                <td> <%# Eval("Parentezco") %> </td>
                                <td> <%# Eval("Cedula") %> </td>
                                <td> <%# Eval("FechaNacimiento") %> </td>
                                <td> <%# Eval("Sexo") %> </td>
                                <td> <%#string.Format("{0:N2}", Eval("PorcPrima")) %> </td>
                                <td> <asp:ImageButton ID="btnEditarRegistro" runat="server" ToolTip="Editar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Editar.png" OnClick="btnEditarRegistro_Click" /> </td>
                                <td> <asp:ImageButton ID="btnBorrarRegistro" runat="server" ToolTip="Borrar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Eliminar.png" OnClick="btnBorrarRegistro_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
              <div align="center">
                <asp:Label ID="lbPaginaActualTituloDependientes" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableDependientes" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloDependientes" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableDependientes" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionDependientes" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaDependientes" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaDependientes_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorDependientes" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorDependientes_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionDependientes" runat="server" OnItemCommand="dtPaginacionDependientes_ItemCommand" OnItemDataBound="dtPaginacionDependientes_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralDependientes" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteDependientes" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteDependientes_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoDependientes" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoDependientes_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        </div>
        <div id="DIVBloqueMantenimiento" runat="server"></div>
    </div>

</asp:Content>
