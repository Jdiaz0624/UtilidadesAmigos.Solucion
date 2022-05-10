<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Modulos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Seguridad.Modulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">
     

        .btn-sm{
            width:90px;
        }

          .BotonEspecoal {
           width:100%;
             font-weight:bold;
          }

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
       
       
          .auto-style1 {
              width: 70%;
              height: 36px;
          }
          .auto-style2 {
              width: 10%;
              height: 36px;
          }
        .BotonImagen {
            width: 40px;
            height: 40px;
        }
    </style>

    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lbModuloConsulta" runat="server" Text="Modulo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtModuloConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Reporte de Modulos" CssClass="BotonImagen" ImageUrl="~/Imagenes/excel.png" OnClick="btnReporte_Click" />
        </div>
        <br />
        <table class="table table-striped">
            <thead class="table-dark">
                <tr>
                    <th scope="col">Modulo</th>
                    <th scope="col">Estatus</th>
                    <th scope="col"> </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoModulos" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfIdModulo" runat="server" Value='<%# Eval("IdModulo") %>' />
                        <asp:HiddenField ID="hfEstatusModulo" runat="server" Value='<%# Eval("Estatus0") %>' />
                   <tr>
                    <td> <%# Eval("Modulo") %> </td>
                    <td> <%# Eval("Estatus") %> </td>
                    <td align="right"> <asp:ImageButton ID="btnEditarRegistro" runat="server" ToolTip="Editar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Editar.png" OnClick="btnEditarRegistro_Click" /> </td>
                </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <table class="table table-striped">
            <tfoot class="table-light">
                <tr>
                    <td align="right" >Pagina <asp:Label ID="lbPaginaActual" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> de <asp:Label ID="lbCantidadPagina" runat="server" Text="0" CssClass="Letranegrita"></asp:Label></td>
                </tr>
            </tfoot>
        </table>

             <div id="divPaginacionTarjetaAcceso" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPagina_Click" /> </td>
                    <td> <asp:ImageButton ID="btnAnterior" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnAnterior_Click" /> </td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguiente" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguiente_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimo" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimo_Click" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
    </div>

</asp:Content>
