<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MatrizDeRiezgo.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MatrizRiezgo.MatrizDeRiezgo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/EstilosComunes.css" rel="stylesheet" />

    <script type="text/javascript">
        $(function () {

            $("#<%=btnCompletar.ClientID%>").click(function () {

                var Mensaje = " no puede estar vacio para completar este proceso, favor de validar.";

                var Nombre = $("#<%=txtNombre_Proceso.ClientID%>").val().length;
                if (Nombre < 1) {

                    alert("El campo Nombre" + Mensaje);
                    $("#<%=txtNombre_Proceso.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var TipoIdentificacion = $("#<%=ddlTipoIdentificacion_Proceso.ClientID%>").val();
                    if (TipoIdentificacion < 1) {

                        alert("El campo Tipo de Identificación" + Mensaje);
                        $("#<%=ddlTipoIdentificacion_Proceso.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var NumeroIdentificacion = $("#<%=txtNumeroIDentificcion_Proceso.ClientID%>").val().length;
                        if (NumeroIdentificacion < 1) {

                            alert("El campo Numero de Identificación" + Mensaje);
                            $("#<%=txtNumeroIDentificcion_Proceso.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {

                            var Ramo = $("#<%=ddlProducto_Proceso.ClientID%>").val();
                            if (Ramo < 1) {

                                alert("El campo Producto" + Mensaje);
                                $("#<%=ddlProducto_Proceso.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var SubRamo = $("#<%=ddlSubProducto_Proceso.ClientID%>").val();
                                if (SubRamo < 1) {

                                    alert("El campo Sub Producto" + Mensaje);
                                    $("#<%=ddlSubProducto_Proceso.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                                else {
                                    var CanalDistribucion = $("#<%=ddlCanalDistribucion_Proceso.ClientID%>").val();
                                    if (CanalDistribucion < 1) {

                                        alert("El campo Canal de Distribución" + Mensaje);
                                        $("#<%=ddlCanalDistribucion_Proceso.ClientID%>").css("border-color", "red");
                                        return false;
                                    }
                                    else {
                                        var PaisProcedencia = $("#<%=ddlPaisProcedencia_Proceso.ClientID%>").val();
                                        if (PaisProcedencia < 1) {

                                            alert("El campo Pais de Procedencia" + Mensaje);
                                            $("#<%=ddlPaisProcedencia_Proceso.ClientID%>").css("border-color", "red");
                                            return false;
                                        }
                                        else {
                                            var PaisResidencia = $("#<%=ddlPaisResidencia_Proceso.ClientID%>").val();
                                            if (PaisResidencia < 1) {

                                                alert("El campo Pais de Residencia" + Mensaje);
                                                $("#<%=ddlPaisResidencia_Proceso.ClientID%>").css("border-color", "red");
                                                return false;
                                            }
                                            else {
                                                var Provincia = $("#<%=ddlProvincia_Proceso.ClientID%>").val();
                                                if (Provincia < 1) {

                                                    alert("El campo Provincia" + Mensaje);
                                                    $("#<%=ddlProvincia_Proceso.ClientID%>").css("border-color", "red");
                                                    return false;
                                                }
                                                else {
                                                    var MontoRiesgo = $("#<%=ddlMontoRiezgo_Proceso.ClientID%>").val();
                                                    if (MontoRiesgo < 1) {

                                                        alert("El campo Monto de Riesgo" + Mensaje);
                                                        $("#<%=ddlMontoRiezgo_Proceso.ClientID%>").css("border-color", "red");
                                                        return false;
                                                    }
                                                    else {
                                                        var ActividadEconomica = $("#<%=ddlActividadEconomica_Proceso.ClientID%>").val();
                                                        if (ActividadEconomica < 1) {

                                                            alert("El campo Actividad Economica" + Mensaje);
                                                            $("#<%=ddlActividadEconomica_Proceso.ClientID%>").css("border-color", "red");
                                                            return false;
                                                        }
                                                        else {
                                                            var IngresoAnual = $("#<%=ddlPromedioIngresoAnuales_Proceso.ClientID%>").val();
                                                            if (IngresoAnual < 1) {

                                                                alert("El campo Promedio de Ingresos Anuales" + Mensaje);
                                                                $("#<%=ddlPromedioIngresoAnuales_Proceso.ClientID%>").css("border-color", "red");
                                                                return false;
                                                            }
                                                            else {
                                                                var PEP = $("#<%=ddlPersonaPEP_Proceso.ClientID%>").val();
                                                                if (PEP < 1) {

                                                                    alert("El campo PEP" + Mensaje);
                                                                    $("#<%=ddlPersonaPEP_Proceso.ClientID%>").css("border-color", "red");
                                                                    return false;
                                                                }
                                                                else {
                                                                    var PrimaAnual = $("#<%=ddlPrimaAnual_Proceso.ClientID%>").val();
                                                                    if (PrimaAnual < 1) {

                                                                        alert("El campo Prima Anual" + Mensaje);
                                                                        $("#<%=ddlPrimaAnual_Proceso.ClientID%>").css("border-color", "red");
                                                                        return false;
                                                                    }
                                                                    else {
                                                                        var TipoMonitoreo = $("#<%=ddlTipoMonitoreo_Proceso.ClientID%>").val();
                                                                        if (TipoMonitoreo < 1) {

                                                                            alert("El campo Tipo de Monitoreo" + Mensaje);
                                                                            $("#<%=ddlTipoMonitoreo_Proceso.ClientID%>").css("border-color", "red");
                                                                            return false;
                                                                        }
                                                                        else {
                                                                            var TipoDebidaDiligencia = $("#<%=ddlTipoDebidaDiligencia_Proceso.ClientID%>").val();
                                                                            if (TipoDebidaDiligencia < 1) {

                                                                                alert("El campo Tipo de Debida Diligencia" + Mensaje);
                                                                                $("#<%=ddlTipoDebidaDiligencia_Proceso.ClientID%>").css("border-color", "red");
                                                                                return false;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                    }

                                    
                                }
                            }
                        }
                    }
                }
            });

        })
    </script>

    <div class="container-fluid">
        <br />
        <div id="DIVBloqueConsulta" runat="server"></div>

        <div id="DIVBloqueProceso" runat="server">

            <asp:ScriptManager ID="ScripManagerMatrizRiezgo" runat="server"></asp:ScriptManager> 


            <div class="table-responsive">
                <table class="table">
                    <thead class="table-light">
                        <tr>
                        <th class="ContenidoCentro">
                            
                                <h4>MATRIZ DE CLASIFICACION DE RIESGO</h4>
                        </th>
                             </tr>
                          <tr>
                          <th class="ContenidoCentro">
                              
                                  <h5>PARA CLIENTES</h5>
                          </th>
                         </tr>
                    </thead>
                </table>
                <hr />
                 <table class="table">
     <thead class="table-light">
         <tr>
         <th class="ContenidoCentro">
             
                 <label class="Letranegrita">NOMBRES</label>
             <label class="Letranegrita Rojo"> * </label>
         </th>
             <th><asp:TextBox ID="txtNombre_Proceso" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="100" ></asp:TextBox> </th>
              </tr>

          <tr>
           <th class="ContenidoCentro">
               
                   <label class="Letranegrita">TIPO DE IDENTIFICACION</label>
                <label class="Letranegrita Rojo"> * </label>
           </th>
               <th><asp:DropDownList ID="ddlTipoIdentificacion_Proceso" runat="server" ToolTip="Seleccionar Tipo de Identificación" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoIdentificacion_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList> </th>
          </tr>
           <tr>
           <th class="ContenidoCentro">
               
                   <label class="Letranegrita">NUMERO DE IDENTIFICACION</label>
                <label class="Letranegrita Rojo"> * </label>
           </th>
               <th><asp:TextBox ID="txtNumeroIDentificcion_Proceso" runat="server" CssClass="form-control" MaxLength="50" ></asp:TextBox> 
                    <ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="txtNumeroIDentificcion_Proceso" Mask="999-9999999-9" 
                        MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                        MaskType="Number" InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                        ErrorTooltipEnabled="True"  ID="MascaraCedula" />
                     
                    <ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="txtNumeroIDentificcion_Proceso" Mask="999-999999" 
                       MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                       MaskType="Number" InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None"
                       ErrorTooltipEnabled="True"  ID="MascaraRNC" />

               </th>
          </tr>
     </thead>
 </table>


    <table class="table table-active">
        <thead class="table-dark">
            <tr>
               <th class="ContenidoCentro" scope="col"> <label>Clasificación</label> </th>
               <th class="ContenidoCentro" scope="col"> <label>Seleccione y / o Complete</label> </th>
               <th class="ContenidoCentro" scope="col"> <label>Nivel de Riesgo</label> </th>
           </tr>
        </thead>
        <tbody>
            <tr>
              <td class="ContenidoCentro">
                  <label class="Letranegrita">PRODUCTO </label>
                   <label class="Letranegrita Rojo"> * </label>
              </td>
              <td class="ContenidoCentro">
                 <asp:DropDownList ID="ddlProducto_Proceso" runat="server" ToolTip="Seleccionar Producto" AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
              </td>
              <td class="ContenidoCentro">
                 <asp:DropDownList ID="ddlNivelRiesgoProducto_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
              </td>
          </tr>


              <tr>
               <td class="ContenidoCentro">
                   <label class="Letranegrita">SUB PRODUCTO </label>
                    <label class="Letranegrita Rojo"> * </label>
               </td>
               <td class="ContenidoCentro">
                  <asp:DropDownList ID="ddlSubProducto_Proceso" runat="server" ToolTip="Seleccionar Sub Producto" AutoPostBack="true" OnSelectedIndexChanged="ddlSubProducto_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                  
               </td>
               <td class="ContenidoCentro">
                  <asp:DropDownList ID="ddlNivelRiesgoSubProducto_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
               </td>
           </tr>

               <tr>
                <td class="ContenidoCentro">
                    <label class="Letranegrita">CANAL DE DISTRIBUCION </label>
                     <label class="Letranegrita Rojo"> * </label>
                </td>
                <td class="ContenidoCentro">
                   <asp:DropDownList ID="ddlCanalDistribucion_Proceso" runat="server" ToolTip="Seleccionar Canal de Distribución" AutoPostBack="true" OnSelectedIndexChanged="ddlCanalDistribucion_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                <td class="ContenidoCentro">
                   <asp:DropDownList ID="ddlNivelRiesgoCanalDistribucion_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
                </td>
             </tr>

              <tr>
                <td class="ContenidoCentro">
                    <label class="Letranegrita">UBICACION GEOGRAFICA (PAIS PROCEDENCIA) </label>
                     <label class="Letranegrita Rojo"> * </label>
                </td>
                <td class="ContenidoCentro">
                   <asp:DropDownList ID="ddlPaisProcedencia_Proceso" runat="server" ToolTip="Seleccionar Pais de Procedencia" AutoPostBack="true" OnSelectedIndexChanged="ddlPaisProcedencia_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                <td class="ContenidoCentro">
                   <asp:DropDownList ID="ddlNivelRiesgoPaisProcedencia_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
                </td>
             </tr>

             <tr>
               <td class="ContenidoCentro">
                   <label class="Letranegrita">UBICACION GEOGRAFICA (PAIS RESIDENCIA) </label>
                    <label class="Letranegrita Rojo"> * </label>
               </td>
               <td class="ContenidoCentro">
                  <asp:DropDownList ID="ddlPaisResidencia_Proceso" runat="server" ToolTip="Seleccionar Pais de Residencia" AutoPostBack="true" OnSelectedIndexChanged="ddlPaisResidencia_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
               </td>
               <td class="ContenidoCentro">
                  <asp:DropDownList ID="ddlNivelRiesgoPaisResidencia_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
               </td>
            </tr>

             <tr>
               <td class="ContenidoCentro">
                   <label class="Letranegrita"> PROVINCIA </label>
                    <label class="Letranegrita Rojo"> * </label>
               </td>
               <td class="ContenidoCentro">
                  <asp:DropDownList ID="ddlProvincia_Proceso" runat="server" ToolTip="Seleccionar Provincia" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
               </td>
               <td class="ContenidoCentro">
                  <asp:DropDownList ID="ddlNivelRiesgoProvincia_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
               </td>
            </tr>

             <tr>
              <td class="ContenidoCentro">
                  <label class="Letranegrita"> MONTO DE RIESGO </label>
                   <label class="Letranegrita Rojo"> * </label>
              </td>
              <td class="ContenidoCentro">
                 <asp:DropDownList ID="ddlMontoRiezgo_Proceso" runat="server" ToolTip="Seleccionar Monto del Riezgo" AutoPostBack="true" OnSelectedIndexChanged="ddlMontoRiezgo_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
              </td>
              <td class="ContenidoCentro">
                 <asp:DropDownList ID="ddlNivelRiesgoMontoRiesgo_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
              </td>
           </tr>

              <tr>
                <td class="ContenidoCentro">
                    <label class="Letranegrita"> ACTIVIDAD ECONOMICA </label>
                     <label class="Letranegrita Rojo"> * </label>
                </td>
                <td class="ContenidoCentro">
                   <asp:DropDownList ID="ddlActividadEconomica_Proceso" runat="server" ToolTip="Seleccionar Actividad Economica" AutoPostBack="true" OnSelectedIndexChanged="ddlActividadEconomica_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                <td class="ContenidoCentro">
                   <asp:DropDownList ID="ddlNivelRiesgoActividadEconomica_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
                </td>
             </tr>

             <tr>
              <td class="ContenidoCentro">
                  <label class="Letranegrita"> PROMEDIO DE INGRESOS ANUALES </label>
                   <label class="Letranegrita Rojo"> * </label>
             </td>
             <td class="ContenidoCentro">
                <asp:DropDownList ID="ddlPromedioIngresoAnuales_Proceso" runat="server" ToolTip="Seleccionar Promedio de ingresos anuales" AutoPostBack="true" OnSelectedIndexChanged="ddlPromedioIngresoAnuales_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
             </td>
             <td class="ContenidoCentro">
                <asp:DropDownList ID="ddlNivelRiesgoPromedioIngresoAnuales" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
             </td>
          </tr>

               <tr>
                 <td class="ContenidoCentro">
                     <label class="Letranegrita"> PERSONA EXPUESTA POLITICAMENTE </label>
                      <label class="Letranegrita Rojo"> * </label>
                </td>
                <td class="ContenidoCentro">
                   <asp:DropDownList ID="ddlPersonaPEP_Proceso" runat="server" ToolTip="Seleccionar Persona Politicamente Expuesta" AutoPostBack="true" OnSelectedIndexChanged="ddlPersonaPEP_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </td>
                <td class="ContenidoCentro">
                   <asp:DropDownList ID="ddlNivelRiesgoPersonaPEP_Proceso" runat="server"  ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
                </td>
             </tr>

              <tr>
    <td class="ContenidoCentro">
        <label class="Letranegrita"> PRIMA ANUAL </label>
         <label class="Letranegrita Rojo"> * </label>
   </td>
   <td class="ContenidoCentro">
      <asp:DropDownList ID="ddlPrimaAnual_Proceso" runat="server"  ToolTip="Nivel de Riesgo"  AutoPostBack="true" OnSelectedIndexChanged="ddlPrimaAnual_Proceso_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
   </td>
   <td class="ContenidoCentro">
      <asp:DropDownList ID="ddlNivelRiesgo_PrimaAnual_Proceso" runat="server" ToolTip="Nivel de Riesgo" Enabled="false" CssClass="form-control"></asp:DropDownList>
   </td>
</tr>

                          <tr>
                         <td class="ContenidoCentro">
                             <label class="Letranegrita"> TIPO DE MONITOREO </label>
                              <label class="Letranegrita Rojo"> * </label>
                        </td>
                        <td class="ContenidoCentro">
                          <asp:DropDownList ID="ddlTipoMonitoreo_Proceso" runat="server" ToolTip="Tipo de Monitoreo"   CssClass="form-control"></asp:DropDownList>
                        </td>
                        <td class="ContenidoCentro">
                           
                        </td>
                     </tr>


                 <tr>
    <td class="ContenidoCentro">
        <label class="Letranegrita"> TIPO DE DEBIDA DILIGENCIA </label>
         <label class="Letranegrita Rojo"> * </label>
   </td>
   <td class="ContenidoCentro">
     <asp:DropDownList ID="ddlTipoDebidaDiligencia_Proceso" runat="server" ToolTip="Tipo de Debida Diligencia"   CssClass="form-control"></asp:DropDownList>
   </td>
   <td class="ContenidoCentro">
      
   </td>
</tr>

                             <tr>
    <td class="ContenidoCentro">
        <label class="Letranegrita"> OBSERVACIONES </label>
   </td>
   <td class="ContenidoCentro">
      <asp:TextBox ID="txtObservaciones_Proceso" runat="server" CssClass="form-control" TextMode="MultiLine" AutoCompleteType="Disabled" MaxLength="8000"></asp:TextBox>
   </td>
   <td class="ContenidoCentro">
      
   </td>
</tr>
        </tbody>
    </table>
</div>
            <br />
            <div class="ContenidoCentro">
                <asp:ImageButton ID="btnCompletar" runat="server" ImageUrl="~/ImagenesBotones/Completado.png" OnClick="btnCompletar_Click" CssClass="BotonImagen" ToolTip="Completar Proceso" />
                 <asp:ImageButton ID="btnVolver" runat="server" ImageUrl="~/ImagenesBotones/Volver_Nuevo.png" OnClick="btnVolver_Click" CssClass="BotonImagen" ToolTip="Volver Atras" />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
