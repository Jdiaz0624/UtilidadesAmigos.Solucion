<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SacarCarteraIntermediariosSupervisor.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Consulta.SacarCarteraIntermediariosSupervisor" %>
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
          .BotonImagen {
              width: 50px;
              height: 50px;
          }
    </style>

    <br />
    <div class="form-check-inline">
        <div class="form-group form-check">
            <asp:RadioButton ID="rbCarteraIntermediarios" runat="server" Text="Cartera de Intermediarios" CssClass="form-check-input LetrasNegrita" ToolTip="Sacar la cartera de Intermediarios" AutoPostBack="true" OnCheckedChanged="rbCarteraIntermediarios_CheckedChanged" GroupName="Cartera" />
             <asp:RadioButton ID="rbCarteraSupervisores" runat="server" Text="Cartera de Supervisores" CssClass="form-check-input LetrasNegrita" AutoPostBack="true" ToolTip="Sacar la cartera de Supervisores" OnCheckedChanged="rbCarteraSupervisores_CheckedChanged" GroupName="Cartera" />
        </div>
    </div>
    <div id="DivBloqueIntermediarios" runat="server">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermedairio" runat="server"  AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtCodigoIntermedairio_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                <asp:Label ID="lbNombre" runat="server" Text="Nombre Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>

             <div class="form-group col-md-3">
                <asp:Label ID="lbSeleccionarEstatusIntermediario" runat="server" Text="Seleccionar Estatus de Poliza" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarEstatusPoliza" runat="server" CssClass="form-control" ToolTip="Seleccionar el Estatus de Poliza"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultarIntermediario" runat="server" ToolTip="Buscar Intermediarios" CssClass="BotonImagen" OnClick="btnConsultarIntermediario_Click" ImageUrl="~/Imagenes/Buscar.png" />
            <asp:ImageButton ID="ExportarInformacionIntermediario" runat="server" ToolTip="Exportar Información a Excel" CssClass="BotonImagen" OnClick="ExportarInformacionIntermediario_Click" ImageUrl="~/Imagenes/excel.png" />
             <br />
            <asp:Label ID="lbCantidadPolizasActivasTitulo" runat="server" Text="Polizas Activas (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasActivasVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasActivasCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbSeparador" runat="server" Text=" | " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasCanceladasTitulo" runat="server" Text="Polizas Canceladas (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasCanceladasVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasCanceladasCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbSeparador2" runat="server" Text=" | " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasTransitoTitulo" runat="server" Text="Polizas En Transito (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasTransitoVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbSeparador3" runat="server" Text=" | " CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolziasExcluidasTitulos" runat="server" Text="Polizas En Exclusión (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasExcluidasVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadPolizasExcluidasCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <br />
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:10%" align="left"> POLIZA </th>
                        <th style="width:10%" align="left"> ESTATUS </th>
                        <th style="width:20%" align="left"> ASEGURADO </th>
                        <th style="width:20%" align="left"> FACTURADO </th>
                        <th style="width:20%" align="left"> COBRADO </th>
                        <th style="width:20%" align="left"> BALANCE </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpCarteraIntermediario" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width:10%" align="left"> <%# Eval("Poliza") %> </td>
                                <td style="width:10%" align="left"> <%# Eval("EstatusPoliza") %> </td>
                                <td style="width:20%" align="left"> <%#string.Format("{0:n2}", Eval("SumaAsegurada")) %> </td>
                                <td style="width:20%" align="left"> <%#string.Format("{0:n2}", Eval("Facturado")) %> </td>
                                <td style="width:20%" align="left"> <%#string.Format("{0:n2}", Eval("Cobrado")) %> </td>
                                <td style="width:20%" align="left"> <%#string.Format("{0:n2}", Eval("Balance")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
       
         <div align="center">
                <asp:Label ID="lbPaginaActualCarteraIntermediario" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableCarteraIntermediario" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloCarteraIntermediario" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableCarteraIntermediario" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionCarteraIntermediario" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaCarteraIntermediario" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaCarteraIntermediario_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorCarteraIntermediario" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorCarteraIntermediario_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionCarteraIntermediario" runat="server" OnItemCommand="dtPaginacionCarteraIntermediario_ItemCommand" OnItemDataBound="dtPaginacionCarteraIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralCarteraIntermediario" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteCarteraIntermediario" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteCarteraIntermediario_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoCarteraIntermediario" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoCarteraIntermediario_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        

        
    </div>


    <div id="DivBloqueSupervisores" runat="server">
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbNombreSupervisor" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoIntermediarioSupervisor" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediarioSupervisor" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioSupervisor_TextChanged" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbNombreIntermediarioSupervisor" runat="server" Text="Nombre de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediarioSupervisor" runat="server" Enabled="false" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>

        <div align="center">
            <asp:ImageButton ID="btnBuscarSupervisores" runat="server" ToolTip="Buscar Información" CssClass="BotonImagen" OnClick="btnBuscarSupervisores_Click" ImageUrl="~/Imagenes/Buscar.png" />
            <asp:ImageButton ID="btnExportarSupervisores" runat="server" ToolTip="Exportar Información" CssClass="BotonImagen" OnClick="btnExportarSupervisores_Click" ImageUrl="~/Imagenes/excel.png" />
            <br />
            <asp:Label ID="lbCantidadIntermediariosTitulo" runat="server" Text="Cantidad de Intermediarios (" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadIntermediariosVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
            <asp:Label ID="lbCantidadIntermediariosCerrar" runat="server" Text=")" CssClass="LetrasNegrita"></asp:Label>
        </div>
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:20%" align="left"> CODIGO </th>
                         <th style="width:70%" align="left"> NOMBRE </th>
                         <th style="width:10%" align="left"> ESTATUS </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpCarteraSupervisor" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width:20%" align="left"> <%# Eval("IdIntermediario") %> </td>
                                <td style="width:70%" align="left"> <%# Eval("NombreIntermediario") %> </td>
                                <td style="width:10%" align="left"> <%# Eval("EstatusVendedor") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
          <div align="center">
                <asp:Label ID="lbPaginaActualCarteraSupervisor" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableCarteraSupervisor" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloCarteraSupervisor" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableCarteraSupervisor" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionCarteraSupervisor" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaCarteraSupervisor" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaCarteraSupervisor_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorCarteraSupervisor" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorCarteraSupervisor_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionCarteraSupervisor" runat="server" OnItemCommand="dtPaginacionCarteraSupervisor_ItemCommand" OnItemDataBound="dtPaginacionCarteraSupervisor_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralCarteraSupervisor" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteCarteraSupervisor" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteCarteraSupervisor_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoCarteraSupervisor" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoCarteraSupervisor_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
    </div>
</asp:Content>
