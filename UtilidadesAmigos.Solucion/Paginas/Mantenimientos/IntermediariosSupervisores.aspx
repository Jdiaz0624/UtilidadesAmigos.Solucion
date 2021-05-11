<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="IntermediariosSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.IntermediariosSupervisores" %>
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

  <div class="container-fluid">
        <div id="DivBloqueConsulta" runat="server">
            <br />
            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Label ID="lbCodigoIntermediarioConsulta" runat="server" Text="Codigo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediarioConsulta" runat="server" MaxLength="4" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-4">
                    <asp:Label ID="lbNombreIntermediarioCnsulta" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediarioConsulta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-4">
                    <asp:Label ID="lbOficinaConsulta" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarOficinaConsulta" runat="server" ToolTip="Seleccionar la Oficina para consultar" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
             <div align="center">
                 <asp:Button ID="btnConsultar" runat="server" Text="Consultar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
                 <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Crear nuevo registro" OnClick="btnNuevo_Click" />
                 <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar registro seleccionado" OnClick="btnModificar_Click" />
                 <asp:Button ID="btnComisiones" runat="server" Text="Comisiones"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Mostrar las comisiones del registro seleccionado" OnClick="btnComisiones_Click" />
                 <asp:Button ID="btnRestabelcer" runat="server" Text="Restablecer"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Restabelcer Pantalla" OnClick="btnRestabelcer_Click" />
        </div>
            <br />
            <div class="table-responsive">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="width:10%" align="left">Seleccionar</th>
                            <th style="width:10%" align="left">Codigo</th>
                            <th style="width:35%" align="left">Nombre</th>
                            <th style="width:10%" align="left">Estatus</th>
                            <th style="width:15%" align="left">Oficina</th>
                            <th style="width:10%" align="left">Entrada</th>
                            <th style="width:10%" align="left">Licencia</th>
                        </tr>
                    </thead>
                    <tbody>
                     
                           <asp:Repeater ID="rpListado" runat="server">
                               <ItemTemplate>
                                      <tr>
                                   <asp:HiddenField ID="hfIdRegistroSeleccionado" runat="server" Value='<%# Eval("Codigo") %>' />
                                   <td style="width:10%" align="left"> <asp:Button ID="btnSeleccionarRegistro" runat="server" Text="Seleccionar" CssClass="btn btn-outline-secondary btn-sm" ToolTip="Seleccionar Registro" OnClick="btnSeleccionarRegistro_Click" />  </td>
                                   <td style="width:10%" align="left"> <%# Eval("Codigo") %> </td>
                                   <td style="width:35%" align="left"> <%# Eval("NombreVendedor") %> </td>
                                   <td style="width:10%" align="left"> <%# Eval("Estatus") %> </td>
                                   <td style="width:15%" align="left"> <%# Eval("NombreOficina") %> </td>
                                   <td style="width:10%" align="left"> <%# Eval("FechaEntrada") %> </td>
                                   <td style="width:10%" align="left"> <%# Eval("LicenciaSeguro") %> </td>
                                          </tr>
                               </ItemTemplate>
                           </asp:Repeater>
                        
                    </tbody>
                </table>
            </div>
            <br />
            <div align="center">
               <asp:Label ID="lbPaginaActualTituloIntermediariosSupervisores" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleIntermediariosSupervisores" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloIntermediariosSupervisores" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVariableIntermediariosSupervisores" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="DivPaginacion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaIntermediariosSupervisores" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaIntermediariosSupervisores_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorIntermediariosSupervisores" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorIntermediariosSupervisores_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionIntermediariosSupervisores" runat="server" OnItemCommand="dtPaginacionIntermediariosSupervisores_ItemCommand" OnItemDataBound="dtPaginacionIntermediariosSupervisores_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralIntermediariosSupervisores" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteIntermediariosSupervisores" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteIntermediariosSupervisores_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoIntermediariosSupervisores" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoIntermediariosSupervisores_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
    </div>

    <div id="DivBloqueMantenimiento" runat="server">

    </div>
  </div>
</asp:Content>
