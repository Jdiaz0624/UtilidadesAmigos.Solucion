<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarMarbetes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarMarbetes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        $(function () {

           
        })
    </script>
    <div class="container-fluid">
        <asp:HiddenField ID="hfPolizaSeleccionada" runat="server" />
        <asp:HiddenField ID="hfNumeroItemSeleccionado" runat="server" />

        <div id="DIVBloqueConsulta" runat="server">
            <br />
            <div class="row">
                 <div class="col-md-3">
                    <label class="Letranegrita">Fecha Desde</label>
                     <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox>
                </div>
                 <div class="col-md-3">
                    <label class="Letranegrita">Fecha Hasta</label>
                     <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="Letranegrita">Poliza</label>
                    <asp:TextBox ID="txtPolizaConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="Letranegrita">No. Item</label>
                     <asp:TextBox ID="txtNumeroItem" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number"></asp:TextBox>
                </div>
                 <div class="col-md-2">
                    <label class="Letranegrita">Supervisor</label>
                     <asp:TextBox ID="txtSupervisor" runat="server" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtSupervisor_TextChanged" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label class="Letranegrita">Nombre</label>
                     <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" AutoCompleteType="Disabled" Enabled="false" ></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <label class="Letranegrita">Vendedor</label>
                     <asp:TextBox ID="txtVendedor" runat="server" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtVendedor_TextChanged" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label class="Letranegrita">Nombre</label>
                     <asp:TextBox ID="txtNombreVendedor" runat="server" CssClass="form-control" AutoCompleteType="Disabled" Enabled="false" ></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="Letranegrita">Oficina</label>
                    <asp:DropDownList ID="ddlOficina" runat="server" CssClass="form-control" ToolTip="Seleccionar Oficina"></asp:DropDownList>
                </div>
                <div class="col-md-12">
                    <label class="Letranegrita">Seleccionar Impresora</label>
                    <asp:DropDownList ID="ddlImpresoras" runat="server" ToolTip="Seleccionar Impresora" CssClass="form-control"></asp:DropDownList> 
                </div>
            </div>
            <br />
            <div class="form-check form-switch">
                <input type="checkbox" id="cbImprimirDirectoImpresora" runat="server" class="form-check-input" />
                <label class="Letranegrita">Imprimir Directo a la Impresora Seleccionada</label>
            </div>
            <br />
            <div class="form-check-inline">
                 <label class="Letranegrita">Estatus de Polizas</label>
                 <asp:RadioButton ID="rbTodos" runat="server" Text="Todos" GroupName="EstatusPoliza" ToolTip="Mostrar Todos los Registros" />
                 <asp:RadioButton ID="rbImpresos" runat="server" Text="Impresos" GroupName="EstatusPoliza" ToolTip="Mostrar Solo Registros Impresos" />
                 <asp:RadioButton ID="rbNoImpresos" runat="server" Text="No Impresos" GroupName="EstatusPoliza" ToolTip="Mostrar Solo Registros No Impresos" />
            </div>
            <br />
            <div class="ContenidoCentro">
                <asp:ImageButton ID="btnConsultarInformacion" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" OnClick="btnConsultarInformacion_Click" />
                <asp:ImageButton ID="btnImprimir" runat="server" ToolTip="Imprimir" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/impresora-de-papel.png" OnClick="btnImprimir_Click" />
            </div>
            <br />
            <div class="table-responsive">
                <table class="table table-striped">
                    <thead class="table-dark">
                        <tr>
                            <th scope="col"> Poliza </th>
                            <th scope="col"> Item </th>
                            <th scope="col"> Fecha </th>
                            <th scope="col"> Hora </th>
                            <th scope="col"> Impresa </th>
                            <th scope="col"> Cant </th>
                            <th class="ContenidoDerecha" scope="col"> Imprimir </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListado" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                                    <asp:HiddenField ID="hfSecuencia" runat="server" Value='<%# Eval("NumeroItem") %>' />


                                    <td> <%# Eval("Poliza") %> </td>
                                    <td> <%# Eval("NumeroItem") %> </td>
                                    <td> <%# Eval("Fecha") %> </td>
                                    <td> <%# Eval("Hora") %> </td>
                                    <td> <%# Eval("Impresa") %> </td>
                                    <td> <%#string.Format("{0:N0}", Eval("CantidadImpresiones")) %> </td>
                                    <td class="ContenidoDerecha"> <asp:ImageButton ID="btnImpresionUnica" runat="server" ToolTip="Imprimir" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/impresora-de-papel.png" OnClick="btnImpresionUnica_Click" /> </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <table class="table">
                    <tfoot class="table-light">
                        <tr>
                            <td class="ContenidoDerecha">
                                <label class="Letranegrita">Pagina</label> <asp:Label ID="lbPaginaactuall" runat="server" Text="0"></asp:Label>
                                <label class="Letranegrita">De</label> <asp:Label ID="lbCantidadPagina" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
             <div id="DivPaginacion" class="table-responsive" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_Listado" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Listado_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_Listado" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Listado_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" />  </td>
                    <td class="ContenidoCentro">
                        <asp:DataList ID="dtPaginacion_Listado" runat="server" OnItemCommand="dtPaginacion_Listado_ItemCommand" OnItemDataBound="dtPaginacion_Listado_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_Listado" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_Listado" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_Listado_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_Listado" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Listado_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>
    </div>

   
</asp:Content>
