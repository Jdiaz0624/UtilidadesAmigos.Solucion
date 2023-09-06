<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MatrizRiesgo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.CumplimientoLegal.MatrizRiesgo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <div class="container-fluid">
        <div id="DivBloqueConsulta" runat="server">
            <br />
            <div class="row">
                <div class="col-md-3">
                    <label class="Letranegrita"> Nombre </label>
                    <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-md-3">
                    <label class="Letranegrita"> No. Identificación </label>
                      <asp:TextBox ID="txtNumeroIdentificacionConsulta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                 <div class="col-md-3">
                    <label class="Letranegrita"> Area </label>
                     <asp:DropDownList ID="ddlAreaConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Area"></asp:DropDownList>
                </div>
                 <div class="col-md-3">
                    <label class="Letranegrita"> Posición </label>
                     <asp:DropDownList ID="ddlPosicionConsulta" runat="server" CssClass="form-control" ToolTip="Seleccionar Posicion"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="ContenidoCentro">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultar_Click" />
                 <asp:ImageButton ID="btnNuevo" runat="server" ToolTip="Crear Nuevo Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" OnClick="btnNuevo_Click" />
            </div>
            <br />
            <div class="table-responsive">
                <table class="table table-striped">
                    <thead class="table-dark">
                        <tr>
                            <th scope="col"> Nombre </th>
                            <th scope="col"> Tipo </th>
                            <th scope="col"> Identificacion </th>
                            <th scope="col"> Area </th>
                            <th scope="col"> Posición </th>
                            <th scope="col"> Riesgo </th>
                            <th scope="col" class="ContenidoDerecha"> Editar </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListado" runat="server">
                            <ItemTemplate>
                                <tr>
                                     <asp:HiddenField ID="hfIdRegistro" runat="server" Value='<%# Eval("") %>' />

                                    <td> <%# Eval("") %> </td>
                                    <td> <%# Eval("") %> </td>
                                    <td> <%# Eval("") %> </td>
                                    <td> <%# Eval("") %> </td>
                                    <td> <%# Eval("") %> </td>
                                    <td> <%# Eval("") %> </td>
                                    <td class="ContenidoDerecha">  <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar Registro" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" OnClick="btnEditar_Click" /> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <table class="table">
                    <tfoot class="table-light">
                        <tr>
                            <td class="ContenidoDerecha">
                                <label class="Letranegrita"> Pagina</label> <asp:Label ID="lbPaginaActual" runat="server" Text="0"></asp:Label>
                                <label class="Letranegrita"> De</label> <asp:Label ID="lbCantidadPAgina" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <div id="DivPaginacion" class="table-responsive" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />  </td>
                    <td class="ContenidoCentro">
                        <asp:DataList ID="dtPaginacion" runat="server" OnItemCommand="dtPaginacion_ItemCommand" OnItemDataBound="dtPaginacion_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>
        <div id="DIVBloqueMatriz" runat="server">
            <br />
            <asp:HiddenField ID="hfIdRegistroSeleccionado" runat="server" />

            <div class="row">
                <div class="col-md-2">
                    <label class="Letranegrita">Nombre</label>
                </div>
                 <div class="col-md-3">
                     <asp:TextBox ID="txtNombre_Matriz" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                 </div>
                <div class="col-md-7"></div>

                <div class="col-md-2">
                    <label class="Letranegrita">Tipo de Identificación</label>
                </div>
                 <div class="col-md-3">
                    <asp:DropDownList ID="ddlTipoIdentificacion_Matriz" runat="server" ToolTip="Seleccionar Tipo de Identificación" CssClass="form-control"></asp:DropDownList>
                 </div>
                <div class="col-md-7"></div>

                <div class="col-md-2">
                    <label class="Letranegrita">Numero de Identificación</label>
                </div>
                 <div class="col-md-3">
                     <asp:TextBox ID="txtNumeroidentificacion" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                 </div>
                <div class="col-md-7"></div>
            </div>
            <br />
           <div class="table-responsive">
                <table class="table table-active">
                <thead class="table-dark">
                    <tr>
                        <th class="ContenidoCentro" scope="col"> Clasificación </th>
                        <th class="ContenidoCentro" scope="col"> Seleccione y / o Complete </th>
                        <th class="ContenidoCentro" scope="col"> Nivel de Riesgo </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">TIPO DE TERCERO </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlTipoTercero_Matriz" runat="server" ToolTip="Seleccionar Tipo de Tercero" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRIesgo_TipoRiesgo_MAtriz" runat="server" ToolTip="Nivel de Riesgo del Tipo de Tercero" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">AREA </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlArea_Matriz" runat="server" ToolTip="Seleccionar Area" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_Area_Matriz" runat="server" ToolTip="Nivel de Riesgo del Area" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>
                </tbody>
            </table>
           </div>
        </div>
    </div>
</asp:Content>
