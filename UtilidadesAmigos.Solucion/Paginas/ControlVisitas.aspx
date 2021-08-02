<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ControlVisitas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ControlVisitas" %>
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
        

        th {
            background-color: dodgerblue;
            color: white;
        }
          .auto-style1 {
              width: 70%;
              height: 36px;
          }
          .auto-style2 {
              width: 10%;
              height: 36px;
          }
    </style>

    <br />
    <div id="DivBloqueCOnsulta" runat="server">
        <div class="form-check-inline">
            <div class="form-group form-check">
                <asp:CheckBox ID="cbAgregarRangoFecha" runat="server" Text="Agregar Rango Fecha" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="cbAgregarRangoFecha_CheckedChanged" />
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbTipoProcesoConsulta" runat="server" Text="Tipo de Proceso" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoProcesoCOnsulta" runat="server" ToolTip="Seleccionar el Tipo de Proceso" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbNombreConsulta" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbRemitenteConsulta" runat="server" Text="Remitente" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtRemitenteConsulta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="form-group col-md-4">
                <asp:Label ID="lbDestinatarioConsulta" runat="server" Text="Destinatario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtDestinatario" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="form-group col-md-4" id="DivFechaDesde" runat="server">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>

             <div class="form-group col-md-4" id="DivFechaHAsta" runat="server">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHAsta" runat="server" TextMode="Date" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultar_Click" />
             <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ToolTip="Crear Nuevo Registro" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnNuevo_Click" />
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" ToolTip="Modificar Registros" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnModificar_Click" />
             <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" ToolTip="Eliminar Registros" CssClass="btn btn-outline-danger btn-sm" OnClick="btnEliminar_Click" />
        </div>
        <br />

        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th style="width:10%" align="left">SELECT</th>
                        <th style="width:20%" align="left">NOMBRE</th>
                        <th style="width:20%" align="left">RNC</th>
                        <th style="width:15%" align="left">TIPO PROC</th>
                        <th style="width:20%" align="left">REMITENTE</th>
                        <th style="width:15%" align="left">DESTINATARIO</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoControlVisitas" runat="server">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfNoRegistro" runat="server" Value='<%# Eval("NoRegistro") %>' />

                            <tr>
                                <td style="width:10%" align="left"><asp:Button ID="btnSeleccionarRegistros" runat="server" Text="Seleccionar" ToolTip="Seleccionar Registros" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnSeleccionarRegistros_Click" /> </td>
                                <td style="width:20%" align="left"><%# Eval("Nombre") %> </td>
                                <td style="width:20%" align="left"><%# Eval("NumeroIdentificacion") %></td>
                                <td style="width:15%" align="left"><%# Eval("TipoProceso") %></td>
                                <td style="width:20%" align="left"><%# Eval("Remitente") %></td>
                                <td style="width:15%" align="left"><%# Eval("Destinatario") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>


         <div align="center">
                <asp:Label ID="lbPaginaActualTituloControlVisistas" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableControlVisistas" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloControlVisistas" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableControlVisistas" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionControlVisistas" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaControlVisistas" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaControlVisistas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorControlVisistas" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorControlVisistas_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionControlVisistas" runat="server" OnItemCommand="dtPaginacionControlVisistas_ItemCommand" OnItemDataBound="dtPaginacionControlVisistas_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralControlVisistas" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteControlVisistas" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteControlVisistas_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoControlVisistas" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoControlVisistas_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
        <br />
    </div>
</asp:Content>
