<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Pantallas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Seguridad.Pantallas" %>
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
                <asp:Label ID="lbSeleccionarModulosConsulta" runat="server" Text="Modulo" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarModulo" runat="server" ToolTip="Seleccionar Modulo" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lbPantallaConsulta" runat="server" Text="Pantalla" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPantallaConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnBuscar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" OnClick="btnBuscar_Click" ImageUrl="~/Imagenes/Buscar.png" />
            <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Exportar Información" CssClass="BotonImagen" OnClick="btnReporte_Click" ImageUrl="~/Imagenes/excel.png" />
        </div>
        <br />
        <table class="table table-striped">
            <thead class="table-dark">
                <tr>
                    <th scope="col"> Modulo </th>
                    <th scope="col"> Pantalla </th>
                    <th scope="col"> Estatus </th>
                    <th scope="col">  </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoPantalla" runat="server">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hfIdModulo" runat="server" Value='<%# Eval("IdModulo") %>' />
                            <asp:HiddenField ID="hfIdPantalla" runat="server" Value='<%# Eval("IdPantalla") %>' />
                            <asp:HiddenField ID="hfEstatus" runat="server" Value='<%# Eval("Estatus0") %>' />

                            <td> <%# Eval("Modulo") %> </td>
                            <td> <%# Eval("Pantalla") %> </td>
                            <td> <%# Eval("Estatus") %> </td>
                            <td align="right" > <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar Registro" CssClass="BotonImagen" OnClick="btnEditar_Click" ImageUrl="~/Imagenes/Editar.png" /> </td>
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

             <div id="divPaginacionPantallas" runat="server" align="center">
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
