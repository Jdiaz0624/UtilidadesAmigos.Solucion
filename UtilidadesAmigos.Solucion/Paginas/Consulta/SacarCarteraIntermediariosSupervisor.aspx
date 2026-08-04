<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="SacarCarteraIntermediariosSupervisor.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Consulta.SacarCarteraIntermediariosSupervisor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/EstilosComunes.css" rel="stylesheet" />

    <script type="text/javascript">
        $(function () {

            $("#<%=btnConsultarIntermediario.ClientID%>").click(function () {

                var Codigo = $("#<%=txtCodigoIntermedairio.ClientID%>").val().length;
                if (Codigo < 1) {
                    alert("El campo Codigo de Intermediario no puede estar vacio para realizar esta busqueda, favor de verificar.");
                    $("#<%=txtCodigoIntermedairio.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

            $("#<%=ExportarInformacionIntermediario.ClientID%>").click(function () {

                var Codigo = $("#<%=txtCodigoIntermedairio.ClientID%>").val().length;
                if (Codigo < 1) {
                    alert("El campo Codigo de Intermediario no puede estar vacio para exportar esta información, favor de verificar.");
                    $("#<%=txtCodigoIntermedairio.ClientID%>").css("border-color", "red");
                     return false;
                 }
            });
        })
    </script>
 

    <br />
    <div class="form-check">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <asp:RadioButton ID="rbCarteraIntermediarios" runat="server" Text="Cartera de Intermediarios" CssClass="LetrasNegrita" ToolTip="Sacar la cartera de Intermediarios" AutoPostBack="true" OnCheckedChanged="rbCarteraIntermediarios_CheckedChanged" GroupName="Cartera" />
         <asp:RadioButton ID="rbCarteraSupervisores" runat="server" Text="Cartera de Supervisores" CssClass="LetrasNegrita" AutoPostBack="true" ToolTip="Sacar la cartera de Supervisores" OnCheckedChanged="rbCarteraSupervisores_CheckedChanged" GroupName="Cartera" />
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
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnConsultarIntermediario" runat="server" ToolTip="Buscar Intermediarios" CssClass="BotonImagen" OnClick="btnConsultarIntermediario_Click" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" />
            <asp:ImageButton ID="ExportarInformacionIntermediario" runat="server" ToolTip="Exportar Información a Excel" CssClass="BotonImagen" OnClick="ExportarInformacionIntermediario_Click" ImageUrl="~/ImagenesBotones/Excel.png" />
            
        </div>
        <br />
       
           <div class="card shadow-lg border-0 rounded-3 mb-4">
    <!-- Encabezado -->
    <div class="card-header bg-primary text-white">
        <h5 class="mb-0">
            <i class="fa fa-briefcase"></i> Cartera de Intermediario
        </h5>
    </div>

    <!-- Tabla principal -->
    <div class="card-body p-0">
        <div class="table-responsive">
            <table class="table table-striped table-hover align-middle mb-0">
                <thead class="table-dark">
                    <tr>
                        <th scope="col">Poliza</th>
                        <th scope="col">Estatus</th>
                        <th scope="col">Cliente</th>
                        <th scope="col" class="ContenidoDerecha">Facturado</th>
                        <th scope="col" class="ContenidoDerecha">Cobrado</th>
                        <th scope="col" class="ContenidoDerecha">Balance</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpCarteraIntermediario" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Poliza") %></td>
                                <td><%# Eval("EstatusPoliza") %></td>
                                <td><%# Eval("Cliente") %></td>
                                <td class="ContenidoDerecha"><%# string.Format("{0:n2}", Eval("Facturado")) %></td>
                                <td class="ContenidoDerecha"><%# string.Format("{0:n2}", Eval("Cobrado")) %></td>
                                <td class="ContenidoDerecha"><%# string.Format("{0:n2}", Eval("Balance")) %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

    <!-- Pie de tabla -->
    <div class="card-footer bg-light border-top">
        <div class="row">
            <!-- Paginación -->
            <div class="col-md-12 text-end mb-2">
                <b>Página </b>
                <asp:Label ID="lbPaginaActualVariableCarteraIntermediario" runat="server" Text="0" CssClass="fw-bold text-primary"></asp:Label>
                <b> de </b>
                <asp:Label ID="lbCantidadPaginaVAriableCarteraIntermediario" runat="server" Text="0" CssClass="fw-bold text-primary"></asp:Label>
            </div>
        </div>

        <hr />

        <!-- Totales -->
        <div class="row text-start">
            <div class="col-md-6 mb-2">
                <b>✔️ Polizas Activas: </b>
                <asp:Label ID="lbCantidadPolizasActivasVariable" runat="server" Text="0" CssClass="fw-bold text-success"></asp:Label>
            </div>
            <div class="col-md-6 mb-2">
                <b>❌ Polizas Canceladas: </b>
                <asp:Label ID="lbCantidadPolizasCanceladasVariable" runat="server" Text="0" CssClass="fw-bold text-danger"></asp:Label>
            </div>
            <div class="col-md-6 mb-2">
                <b>⏳ Polizas En Tránsito: </b>
                <asp:Label ID="lbCantidadPolizasTransitoVariable" runat="server" Text="0" CssClass="fw-bold text-warning"></asp:Label>
            </div>
            <div class="col-md-6 mb-2">
                <b>🚫 Polizas En Exclusión: </b>
                <asp:Label ID="lbCantidadPolizasExcluidasVariable" runat="server" Text="0" CssClass="fw-bold text-secondary"></asp:Label>
            </div>
        </div>
    </div>
</div>
      
     
             <div id="divPaginacionCarteraIntermediario" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnkPrimeraPaginaCarteraIntermediario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnkPrimeraPaginaCarteraIntermediario_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorCarteraIntermediario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorCarteraIntermediario_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" /> </td>
                    <td align="center" >
                        <asp:DataList ID="dtPaginacionCarteraIntermediario" runat="server" OnItemCommand="dtPaginacionCarteraIntermediario_ItemCommand" OnItemDataBound="dtPaginacionCarteraIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteCarteraIntermediario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteCarteraIntermediario_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoCarteraIntermediario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoCarteraIntermediario_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" /> </td>
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
        <br />
        <div class="ContenidoCentro">
            <asp:ImageButton ID="btnBuscarSupervisores" runat="server" ToolTip="Buscar Información" CssClass="BotonImagen" OnClick="btnBuscarSupervisores_Click" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" />
            <asp:ImageButton ID="btnExportarSupervisores" runat="server" ToolTip="Exportar Información" CssClass="BotonImagen" OnClick="btnExportarSupervisores_Click" ImageUrl="~/ImagenesBotones/Excel.png" />
        </div>
        <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col"> Codigo </th>
                         <th scope="col"> Nombre </th>
                         <th scope="col"> Estatus </th>
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
        <table class="table">
            <thead class="table-light">
                <tr>
                    <th class="ContenidoDerecha">
                        <b>Pagina </b> <asp:Label ID="lbPaginaActualVariableCarteraSupervisor" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> <b> De </b> <asp:Label ID="lbCantidadPaginaVAriableCarteraSupervisor" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
                    </th>
                </tr>
                <tr>
                    <th class="ContenidoIzquierda">
                        <b>Cantidad de Intermediarios: </b> <asp:Label ID="lbCantidadIntermediariosVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
                    </th>
                </tr>
            </thead>
        </table>
 
             <div id="divPaginacionCarteraSupervisor" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPaginaCarteraSupervisor" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPaginaCarteraSupervisor_Click" ImageUrl="~/ImagenesBotones/PrimeraPagina_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorCarteraSupervisor" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnAnteriorCarteraSupervisor_Click" ImageUrl="~/ImagenesBotones/Anterior_Nuevo.png" /> </td>

                    <td align="center" >
                        <asp:DataList ID="dtPaginacionCarteraSupervisor" runat="server" OnItemCommand="dtPaginacionCarteraSupervisor_ItemCommand" OnItemDataBound="dtPaginacionCarteraSupervisor_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralCarteraSupervisores" runat="server" CssClass="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteCarteraSupervisor" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguienteCarteraSupervisor_Click" ImageUrl="~/ImagenesBotones/Siguiente_Nuevo.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoCarteraSupervisor" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimoCarteraSupervisor_Click" ImageUrl="~/ImagenesBotones/UltimaPagina_Nuevo.png" /> </td>

                </tr>
            </table>
        </div>
        </div>
                           <br />
    </div>
</asp:Content>
