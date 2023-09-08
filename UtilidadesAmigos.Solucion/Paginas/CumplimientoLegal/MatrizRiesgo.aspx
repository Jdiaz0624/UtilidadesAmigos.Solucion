<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MatrizRiesgo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.CumplimientoLegal.MatrizRiesgo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Content/EstilosComunes.css" />

    <script type="text/javascript">

        function ProcesoCompletado() {
            alert("Registro Guardado con Exito.");
        }
        function NumeroIdentificacionNoValido() {

            alert("Este numero de Cedula ya esta registrado favor de validar.");
            $("#<%=txtNumeroidentificacion.ClientID%>").css("border-color", "blue");
        }
        function NumeroRNCEncontrado() {

            alert("Este numero de RNC ya esta registrado favor de validar.");
            $("#<%=txtNumeroidentificacion.ClientID%>").css("border-color", "blue");
         }
        var MensajeComun = " vacio para completar este registro, favor de verificar.";
       
        $(function () {

            $("#<%=btnGuardar.ClientID%>").click(function () {

                var Nombre = $("#<%=txtNombre_Matriz.ClientID%>").val().length;
                if (Nombre < 1) {
                    alert("El campo Nombre" + MensajeComun);
                    $("#<%=txtNombre_Matriz.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {

                    var TipoIdentificacion = $("#<%=ddlTipoIdentificacion_Matriz.ClientID%>").val();
                    if (TipoIdentificacion < 1) {
                        alert("El campo Tipo de Identificación" + MensajeComun);
                        $("#<%=ddlTipoIdentificacion_Matriz.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var NumeroIdentificacion = $("#<%=txtNumeroidentificacion.ClientID%>").val().length;
                        if (NumeroIdentificacion < 1) {
                            alert("El Campo Numero de identificación" + MensajeComun);
                            $("#<%=txtNumeroidentificacion.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var PrimaAnual = $("#<%=txtPrimaAnual.ClientID%>").val().length;
                            if (PrimaAnual < 1) {
                                alert("El campo Prima Anual" + MensajeComun);
                                $("#<%=txtPrimaAnual.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var IngresosAdicionales = $("#<%=txtIngresosAdicionales.ClientID%>").val().length;
                                if (IngresosAdicionales < 1) {
                                    alert("El campo de Ingresos Adicionales" + MensajeComun);
                                    $("#<%=txtIngresosAdicionales.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                            }
                        }
                    }
                }
            });
        })
    </script>

    <div class="container-fluid">
        <div id="DivBloqueConsulta" runat="server">
            <br />
            <div class="row">
                <div class="col-md-3">
                    <label class="Letranegrita"> Nombre </label>
                    <asp:TextBox ID="txtNombreConsulta" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
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
                <asp:ImageButton ID="btnPlantilla" runat="server" ToolTip="Generar una Plantilla de la matiz de Riezgo" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnPlantilla_Click" />
            </div>
            <br />
            <div class="table-responsive">
                <table class="table table-striped">
                    <thead class="table-dark">
                        <tr>
                            <th scope="col"> Nombre </th>
                            <th scope="col"> Tipo </th>
                            <th scope="col"> Identificacion </th>
                            <th scope="col"> Fecha </th>
                            <th scope="col"> Hora </th>
                            <th scope="col"> Riesgo </th>
                            <th scope="col" class="ContenidoDerecha"> Matriz </th>
                            <th scope="col" class="ContenidoDerecha"> Editar </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpListado" runat="server">
                            <ItemTemplate>
                                <tr>
                                     <asp:HiddenField ID="hfIdRegistro" runat="server" Value='<%# Eval("IdRegistro") %>' />
                                    <asp:HiddenField ID="hfNombre" runat="server" Value='<%# Eval("Nombre") %>' />

                                    <td> <%# Eval("Nombre") %> </td>
                                    <td> <%# Eval("TipoIdentificacion") %> </td>
                                    <td> <%# Eval("NumeroIdentificacion") %> </td>
                                    <td> <%# Eval("FechaCreado") %> </td>
                                    <td> <%# Eval("HoraCreado") %> </td>
                                    <td> <%# Eval("NivelRiesgoConsolidado") %> </td>
                                     <td class="ContenidoDerecha">  <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Mostrar Hoja de Matriz de Riezgo" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Reporte_Nuevo.png" OnClick="btnReporte_Click" /> </td>
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
            <asp:HiddenField ID="hfAccionTomar" runat="server" />

            <div class="row">
                <div class="col-md-2">
                    <label class="Letranegrita">Nombre</label>
                    <label class="Letranegrita Rojo">*</label>
                </div>
                 <div class="col-md-3">
                     <asp:TextBox ID="txtNombre_Matriz" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="100"></asp:TextBox>
                 </div>
                <div class="col-md-7"></div>

                <div class="col-md-2">
                    <label class="Letranegrita">Tipo de Identificación</label>
                    <label class="Letranegrita Rojo">*</label>
                </div>
                 <div class="col-md-3">
                    <asp:DropDownList ID="ddlTipoIdentificacion_Matriz" runat="server" ToolTip="Seleccionar Tipo de Identificación" CssClass="form-control"></asp:DropDownList>
                 </div>
                <div class="col-md-7"></div>

                <div class="col-md-2">
                    <label class="Letranegrita">Numero de Identificación</label>
                    <label class="Letranegrita Rojo">*</label>
                </div>
                 <div class="col-md-3">
                     <asp:TextBox ID="txtNumeroidentificacion" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="20"></asp:TextBox>
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

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">POSICION </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlPocision_Matriz" runat="server" ToolTip="Seleccionar Pocisión" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_Posicion_Matriz" runat="server" ToolTip="Nivel de Riesgo Pocisión" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">NIVEL ACADEMICO </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelAcademico_Matriz" runat="server" ToolTip="Seleccionar Nivel Academico" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_NivelAcademico_Matriz" runat="server" ToolTip="Nivel de Nivel Academico" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">PAIS DE PROCEDENCIA </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlPaisProcedencia_Matriz" runat="server" ToolTip="Seleccionar Pais de Procedencia" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_PaisProcedencia_Matriz" runat="server" ToolTip="Nivel de Riesgo del Pais de Procedencia" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">PAIS DE RESIDENCIA </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlPaisResidencia_Matriz" runat="server" ToolTip="Seleccionar Pais de Residencia" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_PaisResidencia_Matriz" runat="server" ToolTip="Nivel de Riesgo del Pais de Residencia" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">PROVINCIA </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlProvincia_Matriz" runat="server" ToolTip="Seleccionar Provincia" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_Provincia_Matriz" runat="server" ToolTip="Nivel de Riesgo de la Provincia" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">SALARIO DEVENGADO </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlSalarioDevengado_Matriz" runat="server" ToolTip="Seleccionar Salario Devengado" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgoSalarioDevengado" runat="server" ToolTip="Nivel de Riesgo del Salario Devengado" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                     <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">ACTIVIDAD SEGUNDARIA </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:TextBox ID="txtActividadSegundaria_Matriz" runat="server" AutoCompleteType="Disabled" CssClass="form-control" MaxLength="100" PlaceHolder="Opcional"></asp:TextBox>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_ActividaSegundaria" runat="server" ToolTip="Nivel de Riesgo de la actividad segundaria" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">INGRESOS ADICIONALES </label>
                            <label class="Letranegrita Rojo">*</label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:TextBox ID="txtIngresosAdicionales" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Number" PlaceHolder="Llenar en caso de tener actividad segundaria"></asp:TextBox>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_IngresosAdicionales_Matriz" runat="server" ToolTip="Nivel de Riesgo de la actividad segundaria" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                     <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">PERSONA EXPUESTA (PEP) </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlPEP_Matriz" runat="server" ToolTip="Seleccionar PEP" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_PEP_Matriz" runat="server" ToolTip="Nivel de Riesgo del Salario Devengado" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                     <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">PRIMA ANUAL </label>
                            <label class="Letranegrita Rojo">*</label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:TextBox ID="txtPrimaAnual" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_PrimaAnual_Matriz" runat="server" ToolTip="Nivel de riesgo Prima anual" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">TIPO DE MONITOREO </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlTipoMonitoreo_Matriz" runat="server" ToolTip="Seleccionar Tipo de Monitoreo" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
       
                        </td>
                    </tr>

                     <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">TIPO DEBIDA DILIGENCIA </label>
                        </td>
                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlTipoDebidaDiligencia" runat="server" ToolTip="Seleccionar Tipo de Monitoreo" CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
       
                        </td>
                    </tr>

                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">NIVEL DE RIESGO CONSOLIDADO </label>
                        </td>
                        
                        <td class="ContenidoCentro">
       
                        </td>

                        <td class="ContenidoCentro">
                           <asp:DropDownList ID="ddlNivelRiesgo_Consolidado_Matriz" runat="server" ToolTip="Seleccionar Nivel de riesgo consolidado" CssClass="form-control"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="ContenidoCentro">
                            <label class="Letranegrita">OBSERVACIONES </label>
                        </td>
                        
                        <td class="ContenidoCentro">
                           <asp:TextBox ID="txtObservaciones" runat="server" AutoCompleteType="Disabled" CssClass="form-control" TextMode="MultiLine" PlaceHolder="Opcional"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                </tbody>
            </table>
           </div>
            <br />
            <div class="ContenidoCentro">
                <asp:ImageButton ID="btnGuardar" runat="server" ToolTip="Guardar Información" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Nuevo_Nuevo.png" OnClick="btnGuardar_Click" />
                <asp:ImageButton ID="btnVolver" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolver_Click" />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
