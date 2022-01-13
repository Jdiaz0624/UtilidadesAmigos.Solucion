<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SacarCarteraIntermediariosSupervisor.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Consulta.SacarCarteraIntermediariosSupervisor" %>
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
            background-color: #1E90FF;
            color: #000000;
        }
          .BotonImagen {
              width: 40px;
              height: 40px;
          }
    </style>

    <br />
    <div class="form-check-inline">
        <asp:RadioButton ID="rbCarteraIntermediarios" runat="server" Text="Cartera de Intermediarios" CssClass="form-check-input LetrasNegrita" ToolTip="Sacar la cartera de Intermediarios" AutoPostBack="true" OnCheckedChanged="rbCarteraIntermediarios_CheckedChanged" GroupName="Cartera" />
         <asp:RadioButton ID="rbCarteraSupervisores" runat="server" Text="Cartera de Supervisores" CssClass="form-check-input LetrasNegrita" AutoPostBack="true" ToolTip="Sacar la cartera de Supervisores" OnCheckedChanged="rbCarteraSupervisores_CheckedChanged" GroupName="Cartera" />
    </div>
    <div id="DivBloqueIntermediarios" runat="server">
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermedairio" runat="server"  AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtCodigoIntermedairio_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="col-md-6">
                <asp:Label ID="lbNombre" runat="server" Text="Nombre Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediario" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Enabled="false" ></asp:TextBox>
            </div>

             <div class="col-md-3">
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
       
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Poliza </th>
                        <th scope="col"> Estatus </th>
                        <th scope="col"> Cliente </th>
                        <th scope="col"> Facturado </th>
                        <th scope="col"> Cobrado </th>
                        <th scope="col"> Balance </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpCarteraIntermediario" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td> <%# Eval("Poliza") %> </td>
                                <td> <%# Eval("EstatusPoliza") %> </td>
                                <td> <%# Eval("Cliente") %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Facturado")) %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Cobrado")) %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Balance")) %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
      
       
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
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaCarteraIntermediario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaCarteraIntermediario_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorCarteraIntermediario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorCarteraIntermediario_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionCarteraIntermediario" runat="server" OnItemCommand="dtPaginacionCarteraIntermediario_ItemCommand" OnItemDataBound="dtPaginacionCarteraIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteCarteraIntermediario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteCarteraIntermediario_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoCarteraIntermediario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoCarteraIntermediario_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        

        
    </div>


    <div id="DivBloqueSupervisores" runat="server">
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbCodigoSupervisor" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSupervisor" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbNombreSupervisor" runat="server" Text="Codigo de Supervisor" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lbCodigoIntermediarioSupervisor" runat="server" Text="Codigo de Intermediario" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediarioSupervisor" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioSupervisor_TextChanged" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="col-md-3">
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
        
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> CODIGO </th>
                         <th scope="col"> NOMBRE </th>
                         <th scope="col"> ESTATUS </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpCarteraSupervisor" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td> <%# Eval("IdIntermediario") %> </td>
                                <td> <%# Eval("NombreIntermediario") %> </td>
                                <td> <%# Eval("EstatusVendedor") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
  
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
                    <td> <asp:ImageButton ID="btnPrimeraPaginaCarteraSupervisor" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPaginaCarteraSupervisor_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorCarteraSupervisor" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorCarteraSupervisor_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>

                    <td align="center" >
                        <asp:DataList ID="dtPaginacionCarteraSupervisor" runat="server" OnItemCommand="dtPaginacionCarteraSupervisor_ItemCommand" OnItemDataBound="dtPaginacionCarteraSupervisor_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralCarteraSupervisores" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteCarteraSupervisor" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteCarteraSupervisor_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoCarteraSupervisor" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoCarteraSupervisor_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>

                </tr>
            </table>
        </div>
        </div>
                           <br />
    </div>
</asp:Content>
