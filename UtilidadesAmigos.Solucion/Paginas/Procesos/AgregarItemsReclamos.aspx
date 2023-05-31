<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AgregarItemsReclamos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.AgregarItemsReclamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">
        function NombreReclamanteNovalido() {
            alert("El codigo de reclamante no existe, favor de verificar.");
            $("#<%=txtCodigoReclamante.ClientID%>").css("border-color", "red");
        }

        function ReclamacionNoEncontrada() {
            alert("El numero de reclamación ingresado no es valido, favor de valdiar.");
        }

        $(document).ready(function () {

            //VALIDAMOS EL CAMPO NUMERO DE RECLAMO
            $("#<%=btnConsultarReclamo.ClientID%>").click(function () {
                var NumeroReclamo = $("#<%=txtNumeroReclamoConsulta.ClientID%>").val().length;
                if (NumeroReclamo < 1) {
                    alert("El campo numero de reclamo no puede estar vacio para buscar un registro, favor de verificar.");
                    $("#<%=txtNumeroReclamoConsulta.ClientID%>").css("border-color", "red");
                    return false;
                }
            })


            //VALIDAMOS EL CAMPO RECLAMANTE EN EL BOTON GUARDAR
            $("#<%=btnGuardar.ClientID%>").click(function () {
                var Reclamante = $("#<%=txtCodigoReclamante.ClientID%>").val().length;
                if (Reclamante < 1) {
                    alert("El campo codigo de reclamante no puede estar vacio para guardar este registro, favor de verificar.");
                    $("#<%=txtCodigoReclamante.ClientID%>").css("border-color", "red");
                    return false;
                }
            })

            //VALIDAMOS EL CAMPO RECLAMANTE EN EL BOTON MODIFICAR
            $("#<%=btnModificar.ClientID%>").click(function () {
                var Reclamante = $("#<%=txtCodigoReclamante.ClientID%>").val().length;
                if (Reclamante < 1) {
                    alert("El campo codigo de reclamante no puede estar vacio para modificar este registro, favor de verificar.");
                     $("#<%=txtCodigoReclamante.ClientID%>").css("border-color", "red");
                     return false;
                 }
             })
        })
    </script>

    <br />
    <asp:Label ID="lbPolizaSeleccionadaProceso" runat="server" Text="Poliza" Visible="false"></asp:Label>
    <asp:Label ID="lbReclamoSeleccionadoProceso" runat="server" Text="Reclamo" Visible="false"></asp:Label>
    <asp:Label ID="lbSecuenciaSeleccionadaProceso" runat="server" Text="Secuencia" Visible="false"></asp:Label>
    <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lbAccion" runat="server" Text="Accion" Visible="false"></asp:Label>

   <div id="DivBloqueConsulta" runat="server">
        <div class="row">
        <div class="d-inline-flex col-md-6">
            <asp:Label ID="lbNumeroReclamoCOnsulta" runat="server" Text="Numero de Reclamo" CssClass="Letranegrita"></asp:Label>
            <asp:TextBox ID="txtNumeroReclamoConsulta" runat="server" TextMode="Number" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtNumeroReclamoConsulta_TextChanged" CssClass="form-control"></asp:TextBox>
            <asp:ImageButton ID="btnConsultarReclamo" runat="server" CssClass="BotonImagen" OnClick="btnConsultarReclamo_Click1" ToolTip="Buscar Registro" ImageUrl="~/ImagenesBotones/Lupa_Nuevo.png" />
        </div>
    </div>
    <br />

        <table class="table table-striped">
            <thead class="table-dark">
                <tr>
                    <th scope="col"> Poliza </th>
                    <th scope="col"> Reclamo </th>
                    <th class="ContenidoCentro" scope="col"> Secuencia </th>
                    <th scope="col"> Tipo </th>
                    <th scope="col"> Reclamante </th>
                    <th scope="col"> Fecha </th>
                    <th class="ContenidoDerecha" scope="col"> Nuevo </th>
                    <th class="ContenidoDerecha" scope="col"> Editar </th>
                    <th class="ContenidoDerecha" scope="col"> Borrar </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoReclamos" runat="server">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("Poliza") %>' />
                            <asp:HiddenField ID="hfReclamo" runat="server" Value='<%# Eval("Reclamacion") %>' />
                            <asp:HiddenField ID="hfsecuencia" runat="server" Value='<%# Eval("Secuencia") %>' />

                            <td> <%# Eval("Poliza") %> </td>
                            <td> <%# Eval("Reclamacion") %> </td>
                            <td class="ContenidoCentro" > <%# Eval("Secuencia") %> </td>
                            <td> <%# Eval("TipoReclamacion") %> </td>
                            <td> <%# Eval("Reclamante") %> </td>
                             <td> <%# Eval("Fecha") %> </td>
                            <td class="ContenidoDerecha" > <asp:ImageButton ID="btnAgregar" runat="server" CssClass="BotonImagen" OnClick="btnAgregar_Click" ToolTip="Agregar Nuevo Registro" ImageUrl="~/ImagenesBotones/Agregar_Nuevo.png" /> </td>
                            <td class="ContenidoDerecha" > <asp:ImageButton ID="btnEditarRegistro" runat="server" CssClass="BotonImagen" OnClick="btnEditarRegistro_Click" ToolTip="Editar Registro Seleccionado" ImageUrl="~/ImagenesBotones/Editar_Nuevo.png" /> </td>
                            <td class="ContenidoDerecha" > <asp:ImageButton ID="btnEliminar" runat="server" CssClass="BotonImagen" OnClick="btnEliminar_Click" ToolTip="Eliminar Registro Seleccionado" ImageUrl="~/ImagenesBotones/borrar.png" OnClientClick="return confirm('¿Quieres Borrar Este Registro?');" /> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

   <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td class="ContenidoDerecha">
                            <b>Página </b> <asp:Label ID="lbCantidadPaginaVariable" runat="server" Text="0" ></asp:Label> <b>de </b>  <asp:Label ID="lbPaginaActualVariable" runat="server" Text=" 0 "></asp:Label>
                        </td>
                    </tr>

                </tfoot>
            </table>
              <div id="DivPaginacion" runat="server" align="center">
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
                           <br />


    <div id="DivBloqueAgregarEditar" runat="server" visible="false">
        <br />
        <h3 class="ContenidoCentro"><asp:Label ID="lbTitulo" runat="server" Text="Titulo" CssClass="Letranegrita"></asp:Label></h3>
        <hr />
        <br />
        <div class="row">
            <div class="form-group col-md-4">
                <asp:Label ID="lbPolizaSeleccionada" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaSeleccionada" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbSecuencia" runat="server" Text="Secuencia" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtSecuencia" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbReclamante" runat="server" Text="Reclamación" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtReclamacionSeleccionada" Enabled="false" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbTipoReclamaciones" runat="server" Text="Tipo Reclamo" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoReclamo" runat="server" ToolTip="Seleccionar el Tipo de Reclamo" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbCodigoReclamante" runat="server" Text="Codigo Reclamante" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoReclamante" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoReclamante_TextChanged" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbNombreReclamante" runat="server" Text="Nombre del Reclamante" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreReclamante" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbFechaReclamo" runat="server" Text="Fecha de Reclamo" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaReclamo" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Date" ></asp:TextBox>
            </div>
        </div>
        <br />
        <div align="center">
            <asp:ImageButton ID="btnGuardar" runat="server" CssClass="BotonImagen" OnClick="btnGuardar_Click" ToolTip="Guardar Registro" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" />
            <asp:ImageButton ID="btnModificar" runat="server" CssClass="BotonImagen" OnClick="btnModificar_Click" ToolTip="Modificar Registro" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" />
            <asp:ImageButton ID="btnVolver" runat="server" CssClass="BotonImagen" OnClick="btnVolver_Click" ToolTip="Volver Atras" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" />
        </div>
        <br />
    </div>
</asp:Content>
