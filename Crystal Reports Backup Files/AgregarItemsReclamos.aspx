<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AgregarItemsReclamos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.AgregarItemsReclamos" %>
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

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        
        .BotonEspecial {
           width:100%;
           font-weight:bold;
          }

        th {
            background-color: #1E90FF;
            color: #000000;
        }

        .BotonImagen {
                width:40px;
               height:40px;
           }
    </style>

    <script type="text/javascript">
        function NombreReclamanteNovalido() {
            alert("El codigo de reclamante no existe, favor de verificar.");
            $("#<%=txtCodigoReclamante.ClientID%>").css("border-color", "red");
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
            <asp:TextBox ID="txtNumeroReclamoConsulta" runat="server" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            <asp:ImageButton ID="btnConsultarReclamo" runat="server" CssClass="BotonImagen" OnClick="btnConsultarReclamo_Click1" ToolTip="Buscar Registro" ImageUrl="~/Imagenes/Buscar.png" />
        </div>
    </div>
    <br />

        <table class="table table-hover">
            <thead>
                <tr>
                    <th style="width:10%" align="left"> Poliza </th>
                    <th style="width:10%" align="left"> Reclamo </th>
                    <th style="width:10%" align="left"> Secuencia </th>
                    <th style="width:30%" align="left"> Tipo </th>
                    <th style="width:25%" align="left"> Reclamante </th>
                    <th style="width:5%" align="left">  </th>
                    <th style="width:5%" align="left">  </th>
                    <th style="width:5%" align="left">  </th>
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
                            <td> <%# Eval("Secuencia") %> </td>
                            <td> <%# Eval("TipoReclamacion") %> </td>
                            <td> <%# Eval("Reclamante") %> </td>
                            <td> <asp:ImageButton ID="btnAgregar" runat="server" CssClass="BotonImagen" OnClick="btnAgregar_Click" ToolTip="Agregar Nuevo Registro" ImageUrl="~/Imagenes/Agregar (2).png" /> </td>
                            <td> <asp:ImageButton ID="btnEditarRegistro" runat="server" CssClass="BotonImagen" OnClick="btnEditarRegistro_Click" ToolTip="Editar Registro Seleccionado" ImageUrl="~/Imagenes/Editar.png" /> </td>
                            <td> <asp:ImageButton ID="btnEliminar" runat="server" CssClass="BotonImagen" OnClick="btnEliminar_Click" ToolTip="Eliminar Registro Seleccionado" ImageUrl="~/Imagenes/Eliminar.png" /> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    <div align="center">
                <asp:Label ID="lbPaginaActualTituloAgregarItemReclamo" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableAgregarItemReclamo" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloAgregarItemReclamo" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableAgregarItemReclamo" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionAgregarItemReclamo" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaAgregarItemReclamo" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaAgregarItemReclamo_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorAgregarItemReclamo" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorAgregarItemReclamo_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionAgregarItemReclamo" runat="server" OnItemCommand="dtPaginacionAgregarItemReclamo_ItemCommand" OnItemDataBound="dtPaginacionAgregarItemReclamo_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralAgregarItemReclamo" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteAgregarItemReclamo" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteAgregarItemReclamo_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoAgregarItemReclamo" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoAgregarItemReclamo_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
   </div>
                           <br />


    <div id="DivBloqueAgregarEditar" runat="server" visible="false">
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
                <asp:Label ID="lbReclamante" runat="server" Text="Reclamacion" CssClass="Letranegrita"></asp:Label>
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
                <asp:Label ID="lbNombreReclamante" runat="server" Text="Nombre Reclamante" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreReclamante" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <div align="center">
            <asp:ImageButton ID="btnGuardar" runat="server" CssClass="BotonImagen" OnClick="btnGuardar_Click" ToolTip="Guardar Registro" ImageUrl="~/Imagenes/salvar.png" />
            <asp:ImageButton ID="btnModificar" runat="server" CssClass="BotonImagen" OnClick="btnModificar_Click" ToolTip="Modificar Registro" ImageUrl="~/Imagenes/modificar.png" />
            <asp:ImageButton ID="btnVolver" runat="server" CssClass="BotonImagen" OnClick="btnVolver_Click" ToolTip="Volver Atras" ImageUrl="~/Imagenes/volver-flecha.png" />
        </div>
        <br />
    </div>
</asp:Content>
