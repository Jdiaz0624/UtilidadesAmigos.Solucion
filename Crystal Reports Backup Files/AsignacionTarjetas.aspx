 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="AsignacionTarjetas.aspx.cs" EnableViewState ="true" Inherits="UtilidadesAmigos.Solucion.Paginas.AsignacionTarjetas" %>
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
            background-color: #1E90FF;
            color: #000000;
        }
          .BotonImagen {
              width: 40px;
              height: 40px;
          }
    </style>
    <script type="text/javascript">

        $(function () {
            //FUNCION DEL BOTON GAURDAR
            $("#<%=btnGuardar.ClientID%>").click(function () {

                var Oficina = $("#<%=ddlOficinaMantenimiento.ClientID%>").val();
                if (Oficina < 1) {
                    alert("El campo Oficina no puede estar vacio para realizar esta operación, favor de verificar.");
                    $("#<%=ddlOficinaMantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Departamento = $("#<%=ddlDepartamentoMantenimiento.ClientID%>").val();
                    if (Departamento < 1) {
                        alert("El campo Departamento no puede estar vacio para realizar esta operación, favor de verificar.");
                        $("#<%=ddlOficinaMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var NombreEmpleado = $("#<%=txtEmpleadoMantenimiento.ClientID%>").val().length;
                        if (NombreEmpleado < 1) {
                            alert("El campo Nombre de Empleado no puede estar vacio para realizar esta operación, favor de verificar.");
                            $("#<%=txtEmpleadoMantenimiento.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var NumeroTarjeta = $("#<%=txtNumeroTarjetaMantenimiento.ClientID%>").val().length;
                            if (NumeroTarjeta < 1) {
                                alert("El campo Numero de Tarjeta no puede estar vacio para realizar esta operación, favor de verificar.");
                                $("#<%=txtNumeroTarjetaMantenimiento.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var Secuencia = $("#<%=txtSecuenciaInternaMantenimiento.ClientID%>").val().length;
                                if (Secuencia < 1) {
                                    alert("El campo Secuencia no puede estar vacio para realizar esta operación, favor de verificar.");
                                    $("#<%=txtSecuenciaInternaMantenimiento.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                            }
                        }
                    }
                }

            });

        });
    </script>

    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lbIdRegistroSeleccionado" runat="server" Text="0" Visible="false"></asp:Label>
         <asp:Label ID="lbAcionTomar" runat="server" Text="0" Visible="false"></asp:Label>
        <br />
        <div id="DIVBloqueConsulta" runat="server">
            <div class="row">
                <div class="col-md-4"> 
                    <asp:Label ID="lbOficinaCOnsulta" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlOficinaCOnsulta" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOficinaCOnsulta_SelectedIndexChanged" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                       <asp:Label ID="lbDepartamentoConsulta" runat="server" Text="Departamento" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlDepartamentoConsulta" runat="server" ToolTip="Seleccionar Departamento" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                       <asp:Label ID="lbEstatusCOnsulta" runat="server" Text="Estatus" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlEstatusCOnsulta" runat="server" ToolTip="Seleccionar Estatus" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                       <asp:Label ID="lbEmpleadoConsulta" runat="server" Text="Empleado" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtEmpleadoConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-4">
                      <asp:Label ID="lbNumeroTarjeta" runat="server" Text="No. Tarjeta" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <div class="col-md-4">
                      <asp:Label ID="lbSecuenciaInterna" runat="server" Text="Secuencia" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtSecuenciainterna" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Buscar Registros" CssClass="BotonImagen" OnClick="btnConsultar_Click" ImageUrl="~/Imagenes/Buscar.png" />
                 <asp:ImageButton ID="btnNuevo" runat="server" ToolTip="Crear Nuevo Registro" CssClass="BotonImagen" OnClick="btnNuevo_Click" ImageUrl="~/Imagenes/Agregar (2).png" />
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" OnClick="btnReporte_Click" ImageUrl="~/Imagenes/Reporte.png" />
                 <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar Registro Seleccionado" CssClass="BotonImagen" OnClick="btnEditar_Click" ImageUrl="~/Imagenes/Editar.png" />
                 <asp:ImageButton ID="btnRestabelcer" runat="server" ToolTip="Restablecer Pantalla" CssClass="BotonImagen" OnClick="btnRestabelcer_Click" ImageUrl="~/Imagenes/auto.png" />
            </div>
            <br />
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Empleado </th>
                        <th scope="col"> Departamento </th>
                        <th scope="col"> Secuencia </th>
                        <th scope="col"> No. Tarjeta </th>
                        <th scope="col"> Fecha </th>
                        <th scope="col"> Estatus </th>
                        <th scope="col">  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoTarjetas" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfIdRegistro" runat="server" Value='<%# Eval("IdRegistro") %>' />

                                <td> <%# Eval("Empleado") %> </td>
                                <td> <%# Eval("Departamento") %> </td>
                                <td> <%# Eval("SecuenciaInterna") %> </td>
                                <td> <%# Eval("NumeroTarjeta") %> </td>
                                <td> <%# Eval("FechaEntrada") %> </td>
                                <td> <%# Eval("Estatus") %> </td>
                                <td> <asp:ImageButton ID="btnSeleccionar" runat="server" CssClass="BotonImagen" ToolTip="Seleccionar Registro" ImageUrl="~/Imagenes/Seleccionar2.png" OnClick="btnSeleccionar_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
                    <div align="center">
                <asp:Label ID="lbPaginaActualTituloTarjetaAcceso" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariableTarjetaAcceso" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloTarjetaAcceso" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableTarjetaAcceso" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionTarjetaAcceso" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPaginaTarjetaAcceso" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaTarjetaAcceso_Click" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorTarjetaAcceso" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnAnteriorTarjetaAcceso_Click" /> </td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacionTarjetaAcceso" runat="server" OnItemCommand="dtPaginacionTarjetaAcceso_ItemCommand" OnItemDataBound="dtPaginacionTarjetaAcceso_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralTarjetaAcceso" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguienteTarjetaAcceso" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguienteTarjetaAcceso_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoTarjetaAcceso" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimoTarjetaAcceso_Click" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        </div>


        <div id="DIVBloqueMantenimiento" runat="server">
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lbOficinaMantenimiento" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlOficinaMantenimiento" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOficinaMantenimiento_SelectedIndexChanged" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                </div>

                 <div class="col-md-4">
                    <asp:Label ID="lbDepartamentoMantenimiento" runat="server" Text="Departamento" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlDepartamentoMantenimiento" runat="server" ToolTip="Seleccionar Departamento" CssClass="form-control"></asp:DropDownList>
                </div>

                 <div class="col-md-4">
                    <asp:Label ID="lbEmpleadoMantenimiento" runat="server" Text="Empleado" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtEmpleadoMantenimiento" runat="server" AutoCompleteType="Disabled" MaxLength="100" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label ID="lbNumeroTarjetaMAntenimiento" runat="server" Text="No. Tarjeta" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroTarjetaMantenimiento" runat="server" AutoCompleteType="Disabled" MaxLength="30" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label ID="lbSecuenciaInternaMantenimiento" runat="server" Text="Secuencia" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtSecuenciaInternaMantenimiento" runat="server" AutoCompleteType="Disabled" MaxLength="4" CssClass="form-control"></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label ID="lbEstatusMantenimiento" runat="server" Text="Estatus" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlEstatusMantenimiento" runat="server" ToolTip="Seleccionar Estatus" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <br />
            <div align="center">
                <asp:ImageButton ID="btnGuardar" runat="server" ToolTip="Guardar Registro" CssClass="BotonImagen" OnClick="btnGuardar_Click" ImageUrl="~/Imagenes/salvar.png" />
                 <asp:ImageButton ID="btnVolverAtras" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" OnClick="btnVolverAtras_Click" ImageUrl="~/Imagenes/volver-flecha.png" />
            </div>
            <br />
        </div>
    </div>

</asp:Content>
