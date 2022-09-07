﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GestionCobros.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Consulta.GestionCobros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">

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

       

        .BotonSolicitud {
               width:50px;
               height:50px;
           }
        .BotonImagen {
               width:50px;
               height:50px;
           }
    </style>

    <div class="container-fluid">
        <div id="DIVBloqueConsulta" runat="server">
            <br />
            <div class="form-check-inline">
                <asp:CheckBox ID="cbReporteComentaro" runat="server" Text="Reporte de Comentarios" CssClass="Letranegrita" AutoPostBack="true" OnCheckedChanged="cbReporteComentaro_CheckedChanged" />
            </div>
            <br />
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lbFechaDesdeConsulta" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesdeConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="col-md-3">
                     <asp:Label ID="lbFechaHastaConsulta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHastaConsulta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbRamoConsulta" runat="server" Text="Ramo" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlRamoConsulta" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRamoConsulta_SelectedIndexChanged" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbSuvRamoConsulta" runat="server" Text="Sub Ramo" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSubRamoConsulta" runat="server" AutoPostBack="true" on ToolTip="Seleccionar Sub Ramo" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-2">
                    <asp:Label ID="lbSupervisor" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisor" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-2">
                    <asp:Label ID="lbIntermediario" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediarioConsulta" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediarioConsulta_TextChanged" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbOficina" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddloficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbValidarBalance" runat="server" Text="Validar Balance" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlValidarBalance" runat="server" ToolTip="Validar Balance" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3" id="DivExcluirMotores" runat="server" >
                    <asp:Label ID="lbExcluirMotores" runat="server" Text="Excluir Motores" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlExcluirMotores" runat="server" ToolTip="Excluir Motores" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbPoliza" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
                 <asp:ImageButton ID="btnExportarExcel" runat="server" ToolTip="Exportar a Excel" CssClass="BotonImagen" ImageUrl="~/Imagenes/excel.png" OnClick="btnExportarExcel_Click" />
                 <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Reporte de Antiguedad" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        <th scope="col">Poliza</th>
                        <th scope="col">0-10</th>
                        <th scope="col">11-30</th>
                        <th scope="col">31-60</th>
                        <th scope="col">61-90</th>
                        <th scope="col">91-120</th>
                        <th scope="col">121-Mas</th>
                        <th scope="col"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpAntiguedadSaldo" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfPoliza" runat="server" Value='<%# Eval("") %>' />

                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <%# Eval("") %> </td>
                                <td> <asp:ImageButton ID="btnGestionCobros" runat="server" ToolTip="Gestion de Cobros" CssClass="BotonImagen" ImageUrl="~/Imagenes/Cobros.png" OnClick="btnGestionCobros_Click" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina</b> <asp:Label ID="lbPaginaActual_Antiguedad" runat="server" Text=" 0 "></asp:Label> <b>de</b> <asp:Label ID="lbCantidadPaginaVariable_Antiguedad" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
              <div id="divPaginacion_Antiguedad" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_Antiguedad" runat="server" ToolTip="Ir a la Primera Pagina del Listado" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Antiguedad_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_Antiguedad" runat="server" ToolTip="Ir a la Pagina Anterior del Listado" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Antiguedad_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>

                    <td>
                        <asp:DataList ID="dtPaginacion_Antiguedad" runat="server" OnItemCommand="dtPaginacion_Antiguedad_ItemCommand" OnItemDataBound="dtPaginacion_Antiguedad_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_Antiguedad" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnPaginaSiguiente_Antiguedad" runat="server" ToolTip="Ir a la Siguiente Pagina del Listado" CssClass="BotonImagen" OnClick="btnPaginaSiguiente_Antiguedad_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_Antiguedad" runat="server" ToolTip="Ir a la Ultima Pagina del Listado" CssClass="BotonImagen" OnClick="btnUltimaPagina_Antiguedad_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        </div>
          <div id="DIVBloqueProceso" runat="server">
              <br />
              <asp:ScriptManager ID="ScripManagerGestionCobros" runat="server"></asp:ScriptManager>

               <button class="btn btn-dark btn-sm BotonEspecial" type="button" id="btnInformacionCobertura" data-toggle="collapse" data-target="#InformacionCliente" aria-expanded="false" aria-controls="collapseExample">
                  
                  <asp:Label ID="lbDetalleGeneralesPolizaSeleccionada" runat="server" Text="  DETALLES GENERALES DE LA POLIZA SELECCIONADA" CssClass="Letranegrita"></asp:Label>
                     </button><br />


       <div class="collapse" id="InformacionCliente">
                <div class="card card-body">
                   <asp:UpdatePanel ID="UpdatePanelCliente" runat="server">
                       <ContentTemplate>
                           <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lbPolizaGestionCobro" runat="server"  Text="Poliza" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtPolizaGestionCObros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbEstatusGestionCobros" runat="server"  Text="Estatus" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtEstatusGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbRamoGestionCobros" runat="server"  Text="Ramo" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtRamoGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--SEGUNDA LINEA-->
                <div class="col-md-4">
                    <asp:Label ID="lbClienteGestionCobros" runat="server" Text="Cliente" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtClienteGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbTelefonosGestionCObros" runat="server" Text="Telefonos" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTelefonosGestonCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbDireccionGestionCobros" runat="server" Text="Dirección" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtDireccionGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--TERCERA FILA-->

                 <div class="col-md-4">
                    <asp:Label ID="lbSupervisorGestionCobros" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtSupervisorGEstionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbIntermediarioGEstionCobros" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtIntermediarioGestionCobro" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbLicenciaGestionCobros" runat="server" Text="Licencia" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtLicencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--CUARTA FILA-->
                 <div class="col-md-4">
                    <asp:Label ID="lbFechaCreadaGestionCobros" runat="server" Text="Fecha Creada" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaCreadaGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbInicioVigenciaGestionCObros" runat="server" Text="Inicio de Vigencia" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtInicioVigencia" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbFInVigenciaGestionCobros" runat="server" Text="Fin de Vigencia" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFInVigenciaGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--QUINTA FILA-->
                 <div class="col-md-4">
                    <asp:Label ID="lbTotalFActuradoGestionCobros" runat="server" Text="Total Facturado" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalFacturado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbTotalCobradoGestionCobros" runat="server" Text="Total Cobrado" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalCobradoGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbBalanceGestionCobros" runat="server" Text="Balance" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtBalanceGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <!--SEXTA FILA-->
                 <div class="col-md-4">
                    <asp:Label ID="lbTotalFacturasGestionCobros" runat="server" Text="Facturas" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalFacturasGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbTotalRecibos" runat="server" Text="Recibos" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalRecibosGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:Label ID="lbTotalReclamaciones" runat="server" Text="Reclamaciones" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtTotalReclamacionesGestionCobros" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                               <br /> <br /> <br /> <br />
                 <asp:Label ID="lbLetreroUltimoComentario" runat="server" Text="Datos del ultimo comentario agregado en el listado de renovacion" CssClass="Letranegrita" align="center"></asp:Label>
                               <hr />

                <div class="col-md-6">
                    <asp:Label ID="lbUltimoConcepto" runat="server" Text="Ultimo Concepto de Llamada" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtUltimoConcepto" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

               <div class="col-md-6">
                    <asp:Label ID="lbUltimoEstatus" runat="server" Text="Ultimo Estatus de Llamada" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

                <div class="col-md-12">
                    <asp:Label ID="lbUltimoComentario" runat="server" Text="Ultimo Comentario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtUltimoComentario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>

              
            </div>
                           <br />
                           <div id="DivDatoVehiculo" runat="server">
               
                                   <table class="table table-striped">
                                       <thead class="table-dark">
                                           <tr>
                                               <th scope="col"> Item </th>
                                               <th scope="col"> Tipo </th>
                                               <th scope="col"> Marca </th>
                                               <th scope="col"> Modelo </th>
                                               <th scope="col"> Color </th>
                                               <th scope="col"> Año </th>
                                               <th scope="col"> Placa </th>
                                               <th scope="col"> Chasis </th>
                                           </tr>
                                       </thead>

                                       <tbody>
                                           <asp:Repeater ID="rpDatosVehiculo" runat="server">
                                               <ItemTemplate>
                                                   <tr>
                                                       <td> <%# Eval("Item") %> </td>
                                                       <td> <%# Eval("Tipo") %> </td>
                                                       <td> <%# Eval("Marca") %> </td>
                                                       <td> <%# Eval("Modelo") %> </td>
                                                       <td> <%# Eval("Color") %> </td>
                                                       <td> <%# Eval("Ano") %> </td>
                                                       <td> <%# Eval("Placa") %> </td>
                                                       <td> <%# Eval("Chasis") %> </td>
                                                   </tr>
                                               </ItemTemplate>
                                           </asp:Repeater>
                                       </tbody>

                                   </table>
                               <table class="table">
                                   <tfoot class="table-light">
                                       <tr>
                                           <td align="right"><b>Pagina</b><asp:Label ID="lbPaginaActual_DatoVehiculo" runat="server" Text=" 0 "></asp:Label> <b>De</b> <asp:Label ID="lbCantidadPagina_DatoVehiculo" runat="server" Text="0"></asp:Label></td>
                                       </tr>
                                   </tfoot>
                               </table>
                            
               <div id="divPaginacion_DatoVehiculo" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_DatoVehiculo" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPagina_DatoVehiculo_Click" /> </td>
                     <td> <asp:ImageButton ID="btnPaginaAnterior_DatoVehiculo" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnterior_DatoVehiculo_Click" /> </td>

                    <td align="center">
                        <asp:DataList ID="dtPaginacion_DatoVehiculo" runat="server" OnItemCommand="dtPaginacion_DatoVehiculo_ItemCommand" OnItemDataBound="dtPaginacion_DatoVehiculo_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_DatoVehiculo" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                     <td> <asp:ImageButton ID="btnSiguientePagina_DatoVehiculo" runat="server" ToolTip="Ir a la Siguiente Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePagina_DatoVehiculo_Click" /> </td>
                     <td> <asp:ImageButton ID="btnUltimaPagina_DatoVehiculo" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPagina_DatoVehiculo_Click" /> </td>
                </tr>
            </table>
        </div>
        </div>
               <br />
                           </div>
            </ContentTemplate>
                   </asp:UpdatePanel>
                </div>
            </div>


                <div class="row">
                  <!--SEPTIMA FILA-->
                <div class="col-md-4">
                    <asp:Label ID="lbEstatusDeLlamada" runat="server" Text="Concepto de Llamada" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarEstatusLLamadaGestionCobros" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarEstatusLLamadaGestionCobros_SelectedIndexChanged" CssClass="form-control" ToolTip="Seleccionar el Estatus de llamada"></asp:DropDownList>
                </div>

                 <div class="col-md-8">
                    <asp:Label ID="lbConceptoEstatusLlamada" runat="server" Text="Concepto" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarConceptoGestionCobros" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarConceptoGestionCobros_SelectedIndexChanged" ToolTip="Seleccionar el Estatus de llamada"></asp:DropDownList>
                </div>

                <div class="col-md-4" id="DivFechaLlamada" runat="server" visible="false" >
                    <asp:Label ID="lbFechaNuevallamada" runat="server" Text="Fecha de Nueva LLamada" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaNuevaLLamada" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-md-4" id="DIVHoraLLamada" runat="server" visible="false">
                    <asp:Label ID="lbHoranUevaLLamada" runat="server" Text="Hora de Nueva LLamada" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtHoraNuevaLLamada" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-md-12">
                    <asp:Label ID="lbComentarioGestionCobros" runat="server" Text="Comentario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtComentarioGestionCobros" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="MultiLine" Height="60px"></asp:TextBox>
                </div>
             
            </div>
               <br />
        

        <br />
        <div align="center">
            <asp:ImageButton ID="btnGuardar_GestionCobros" runat="server" CssClass="BotonImagen" OnClick="btnGuardar_GestionCobros_Click" ToolTip="Guardar Registro" ImageUrl="~/Imagenes/salvar.png" />
            <asp:ImageButton ID="btnVolver_GestionCobros" runat="server" CssClass="BotonImagen" OnClick="btnVolver_GestionCobros_Click" ToolTip="Volver Atras" ImageUrl="~/Imagenes/volver-flecha.png" />
            <br /><br />
        </div>
       
        

            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                    <th scope="col"> Estatus </th>
                    <th scope="col"> Concepto </th>
                    <th scope="col"> Comentario </th>
                    <th scope="col"> Vigencia </th>
                    <th scope="col"> Usuario </th>
                    <th scope="col"> Fecha </th>
                   </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="rpComentarios_GestionCobros" runat="server">
                        <ItemTemplate>
                            <tr>
                       

                        <td> <%# Eval("") %> </td>
                        <td> <%# Eval("") %> </td>
                        <td> <%# Eval("") %> </td>
                        <td> <%# Eval("") %> </td>
                        <td> <%# Eval("") %> </td>
                        <td> <%# Eval("") %> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina</b> <asp:Label ID="lbPaginaActual_Comentarios" runat="server" Text=" 0 "></asp:Label> <b>de</b> <asp:Label ID="lbCantidadPagina_Comentarios" runat="server" Text="0"></asp:Label></td>
                    </tr>

                     <tr>
                         <td align="left"><b>Cantidad de Registros: </b> <asp:Label ID="lbCantidadRegistros_Comentarios" runat="server" Text="0"></asp:Label> </td>
                     </tr>
                </tfoot>
            </table>


               <div id="divPaginacionGestionCobros" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_Comentarios" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_Comentarios_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_Comentarios" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_Comentarios_Click" ImageUrl="~/Imagenes/Anterior.png" /> </td>

                    <td>
                        <asp:DataList ID="dtPaginacion_Comentarios" runat="server" OnItemCommand="dtPaginacion_Comentarios_ItemCommand" OnItemDataBound="dtPaginacion_Comentarios_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_Comentarios" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnPaginaSiguiente_Comentarios" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnPaginaSiguiente_Comentarios_Click" ImageUrl="~/Imagenes/Siguiente.png" /> </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_Comentarios" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_Comentarios_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" /> </td>

                </tr>
            </table>
        </div>
        </div>
               <br />
              </div>

       <br />
          </div>

</asp:Content>
