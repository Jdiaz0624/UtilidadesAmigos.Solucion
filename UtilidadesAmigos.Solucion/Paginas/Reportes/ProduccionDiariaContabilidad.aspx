<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProduccionDiariaContabilidad.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProduccionDiariaContabilidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
       <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#7BC5FF;
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
        

      

          .BotonImagen {
         width:40px;
         height:40px;
       
       }
        .auto-style1 {
            height: 19px;
        }
        .BotonImagen {
               width:50px;
               height:50px;
           }
    </style>

    <script type="text/javascript">
        function ErrorConsulta() {
            alert("Error al realizar la consulta, favor de verificar los parametros ingresados o contactar al departamento de Tecnologia");
        }
        function OpcionNoDisponible() {
            alert("la Opción de cobros esta en desarrollo en estos momentos");
        }

        function ErrorExportacionConsulta() {
            alert("Error al exportar la data, favor de verificar los parametros ingresados o contactar al departamento de tecnologia");
        }
        function ErrorExportar() {
            alert("Error al Exportar la data");
        }
        function CamposVacios() {
            alert("Has dejado campos vacios que son necesarios para realizar la consulta, favor de verificar");
        }
        function ValidarFechaDesde() {
       
        }

         function ValidarFechaHasta() {
        
        }
        function ValidarCodigoIntermediario() {
            $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
         }

        function CampoAnoVacio() {
            alert("El campo año no puede estar vacio, favor de verificar");
            $("#<%=txtAno.ClientID%>").css("border-color", "red");
        }

        function CampoCodogoIntermediarioVacio() {
            alert("El campo Codigo de Intermediario no puede estar vaicio, favor de verificar");
            $("#<%=txtCodigoIntermediario.ClientID%>").css("border-color", "red");
        }

        function DesactivarCodigoIntermediario() {
            $("#<%=txtCodigoIntermediario.ClientID%>").attr("disabled", "disabled");
        }
        function ActivarCodigoIntermediario() {
            $("#<%=txtCodigoIntermediario.ClientID%>").removeAttr("disabled", true);
        }
        function ModoComparativo() {
            $("#<%=ddlSeleccionarMes.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtAno.ClientID%>").attr("disabled", "disabled");
        }
        function ModoNormal() {

            $("#<%=ddlSeleccionarMes.ClientID%>").removeAttr("disabled", "true");
            $("#<%=txtAno.ClientID%>").removeAttr("disabled", "true");
        }
    </script>

    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <br />
          <div class="form-check-inline">
         
                <asp:CheckBox ID="cbModoComparativo" AutoPostBack="true" CssClass="Letranegrita" OnCheckedChanged="cbModoComparativo_CheckedChanged" runat="server" Text="Modo Comparativo"  ToolTip="Este modo es para comparar dos rangos de fechas" />
     <asp:CheckBox ID="cbTodosLosIntermediarios" runat="server" Visible="false" Text="Todos los Intermediarios" CssClass="Letranegrita" AutoPostBack="true" ToolTip="Mostrar todos los intermediarios" OnCheckedChanged="cbTodosLosIntermediarios_CheckedChanged" /><br />
                <asp:Label ID="lbLetreroTodosIntermediairos" runat="server" Visible="false" Text="La consulta con todos los intermediarios puede tardar hasta 5 minutos debido a la cantidad de registros y calculos de primas." CssClass="LetrasNegrita" ForeColor="Red"></asp:Label>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbTipoReporte" runat="server" Text="Tipo de Reporte" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarTipoReporte" runat="server" ToolTip="Tipo de Información" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSeleccionarTipoReporte_SelectedIndexChanged">
                    <asp:ListItem Value="1">Producción</asp:ListItem>
                    <asp:ListItem Value="2">Cobros</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
      
       
         <%--  MODO COMPARATIVO--%>
        <div class="row">
             
            <div class="col-md-2">
                <asp:Label ID="lbFechaDesdeModoComparativo" runat="server" Visible="false" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeModoComparativo" runat="server" Visible="false" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="col-md-2">
                 <asp:Label ID="lbFechaHastaModoCOmparativo" runat="server" Visible="false" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaModoComparativo" runat="server" Visible="false" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="col-md-2">
                 <asp:Label ID="lbFechaDesdeMesAnteriorModoComparativo" runat="server" Visible="false" Text="Desde Mes Anterior" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaDesdeMesAnteriorModoComparativo" runat="server" Visible="false" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="col-md-2">
                 <asp:Label ID="lbFechaHastaMesAnteriorModoComparativo" runat="server" Visible="false" Text="Hasta Mes Anterior" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHastaMesAnteriorModoCOmparativo" runat="server" Visible="false" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <%--  MODO NORMAL--%>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbSeleccionarMes" runat="server" Text="Seleccionar Mes" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarMes" runat="server" ToolTip="Seleccionar el mes a validar" CssClass="form-control">
                </asp:DropDownList>
            </div>
             <div class="col-md-3">
                 <asp:Label ID="lbAno" runat="server" Text="Año" CssClass="Letranegrita"></asp:Label>
                 <asp:TextBox ID="txtAno" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
             <div class="col-md-3">
                   <asp:Label ID="lbRamo" runat="server" Text="Seleccionar Ramo" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarRamo" runat="server" ToolTip="Seleccionar Ramo" CssClass="form-control"></asp:DropDownList>
            </div>

             

             <div class="col-md-3">
                  <asp:Label ID="lbSeleccionarOficina" runat="server" Text="Seleccionar Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficina" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>

             <div class="col-md-3">
                   <asp:Label ID="lbLlevaIntermediario" runat="server" Text="Lleva Intermediario" CssClass="Letranegrita"></asp:Label>
                 <asp:DropDownList ID="ddlLlevaIntermediario" runat="server" ToolTip="Lleva Intermediario" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlLlevaIntermediario_SelectedIndexChanged">
                     <asp:ListItem Value="1">NO</asp:ListItem>
                     <asp:ListItem Value="2">SI</asp:ListItem>
                   </asp:DropDownList>
            </div>

            <div class="col-md-3">
                   <asp:Label ID="lbIntermediario" Visible="false" runat="server" Text="Codigo Intermediario" CssClass="Letranegrita"></asp:Label>
                 <asp:TextBox ID="txtCodigoIntermediario" Visible="false" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>

        <!--BOTONES-->
        <div align="center">
            <asp:ImageButton ID="btnConsultarNuevo" runat="server" ToolTip="Consultar Información" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultarNuevo_Click" CssClass="BotonImagen" />
            <asp:ImageButton ID="btnExportarNuevo" runat="server" ToolTip="Exportar Información" ImageUrl="~/Imagenes/excel.png" OnClick="btnExportarNuevo_Click" CssClass="BotonImagen" />
        </div>

        <br />
     


        <div id="DivProduccionSinIntermediario" runat="server">
             <table class="table table-striped">
          <thead class="table-dark">
              <tr>
                  <th scope="col"> Ramo </th>
                  <th scope="col"> Tipo </th>
                  <th scope="col"> Oficina </th>
                  <th scope="col"> Concepto </th>
                  <th scope="col"> Total </th>
              </tr>
          </thead>
          <tbody>
              <asp:Repeater ID="rpProduccionSinIntermediario" runat="server">
                  <ItemTemplate>
                      <tr>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%#string.Format("{0:N2}", Eval("")) %> </td>
                      </tr>
                  </ItemTemplate>
              </asp:Repeater>
          </tbody>
      </table>
             <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right">Pagina <asp:Label ID="lbPaginaActual_ProduccionSinIntermediario" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> de <asp:Label ID="lbCantidadPagina_ProduccionSinIntermediario" runat="server" Text="0" CssClass="Letranegrita"></asp:Label></td>
                    </tr>
                     <tr>
                        <td align="left"><b>Facturado Hoy:</b> <asp:Label ID="lbFacturadoHoy_ProduccionSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cantidad de Debitos:</b>  <asp:Label ID="lbCantidadDebitos_ProduccionSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cantidad de Creditos:</b>  <asp:Label ID="lbCantidadCreditos_ProduccionSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Otros:</b>  <asp:Label ID="lbOtros_ProduccionSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Total</b>  <asp:Label ID="lbTotal_ProduccionSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Total Mes Anterior:</b>  <asp:Label ID="lbTotalMesAnterior_ProduccionSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
          <div id="DivPaginacio_ProduccionSinIntermediarion" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_ProduccionSinIntermediario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_ProduccionSinIntermediario_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_ProduccionSinIntermediario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_ProduccionSinIntermediario_Click" ImageUrl="~/Imagenes/Anterior.png" />  </td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacion_ProduccionSinIntermediario" runat="server" OnItemCommand="dtPaginacion_ProduccionSinIntermediario_ItemCommand" OnItemDataBound="dtPaginacion_ProduccionSinIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_ProduccionSinIntermediario" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_ProduccionSinIntermediario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_ProduccionSinIntermediario_Click" ImageUrl="~/Imagenes/Siguiente.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_ProduccionSinIntermediario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_ProduccionSinIntermediario_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>
        <div id="DivProduccionConIntermediario" runat="server">
             <table class="table table-striped">
          <thead class="table-dark">
              <tr>
                  <th scope="col"> Intermediario </th>
                  <th scope="col"> Ramo </th>
                  <th scope="col"> Tipo </th>
                  <th scope="col"> Oficina </th>
                  <th scope="col"> Concepto </th>
                  <th scope="col"> Total </th>
              </tr>
          </thead>
          <tbody>
              <asp:Repeater ID="rpProduccionConIntermediario" runat="server">
                  <ItemTemplate>
                      <tr>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%#string.Format("{0:N2}", Eval("")) %> </td>
                      </tr>
                  </ItemTemplate>
              </asp:Repeater>
          </tbody>
      </table>
             <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right">Pagina <asp:Label ID="lbPaginaActual_ProduccionConIntermediario" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> de <asp:Label ID="lbCantidadPagina_ProduccionConIntermediario" runat="server" Text="0" CssClass="Letranegrita"></asp:Label></td>
                    </tr>
                     <tr>
                        <td align="left"><b>Facturado Hoy:</b> <asp:Label ID="lbFacturadoHoy_ProduccionConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cantidad de Debitos:</b>  <asp:Label ID="lbCantidadDebitos_ProduccionConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cantidad de Creditos:</b>  <asp:Label ID="lbCantidadCreditos_ProduccionConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Otros:</b>  <asp:Label ID="lbOtros_ProduccionConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Total</b>  <asp:Label ID="lbTotal_ProduccionConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Total Mes Anterior:</b>  <asp:Label ID="lbTotalMesAnterior_ProduccionConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
          <div id="DivPaginacio_ProduccionConIntermediario" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_ProduccionConIntermediario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_ProduccionConIntermediario_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_ProduccionConIntermediario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_ProduccionConIntermediario_Click" ImageUrl="~/Imagenes/Anterior.png" />  </td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacion_ProduccionConIntermediario" runat="server" OnItemCommand="dtPaginacion_ProduccionConIntermediario_ItemCommand" OnItemDataBound="dtPaginacion_ProduccionConIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_ProduccionConIntermediario" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_ProduccionConIntermediario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_ProduccionConIntermediario_Click" ImageUrl="~/Imagenes/Siguiente.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_ProduccionConIntermediario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_ProduccionConIntermediario_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>
        <div id="DivCobroSinIntermedairio" runat="server">
             <table class="table table-striped">
          <thead class="table-dark">
              <tr>
                  <th scope="col"> Ramo </th>
                  <th scope="col"> Oficina </th>
                  <th scope="col"> Cobrado </th>
              </tr>
          </thead>
          <tbody>
              <asp:Repeater ID="rpCobradoSinIntermediario" runat="server">
                  <ItemTemplate>
                      <tr>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%#string.Format("{0:N2}", Eval("")) %> </td>
                      </tr>
                  </ItemTemplate>
              </asp:Repeater>
          </tbody>
      </table>
             <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right">Pagina <asp:Label ID="lbPaginaActual_CobradoSinIntermediario" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> de <asp:Label ID="lbCantidadPagina_CobradoSinIntermediario" runat="server" Text="0" CssClass="Letranegrita"></asp:Label></td>
                    </tr>
                     <tr>
                        <td align="left"><b>Cobrado Santo Domingo:</b> <asp:Label ID="lbCobradoSantoDomingo_CobradoSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cobrado Santiago:</b>  <asp:Label ID="lbCobradoSantiago_CobradoSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cobrado Otros:</b>  <asp:Label ID="lbCobradoOtros_CobradoSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Total Cobrado:</b>  <asp:Label ID="lbTotalCobrado_CobradoSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cobrado Hoy</b>  <asp:Label ID="lbCobradoHoy_CobradoSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cobrado Mes Anterior:</b>  <asp:Label ID="lbCobradoMesAnterior_CobradoSinIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
          <div id="DivPaginacio_CobradoSinIntermediario" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_CobradoSinIntermediario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_CobradoSinIntermediario_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_CobradoSinIntermediario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_CobradoSinIntermediario_Click" ImageUrl="~/Imagenes/Anterior.png" />  </td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacion_CobradoSinIntermediario" runat="server" OnItemCommand="dtPaginacion_CobradoSinIntermediario_ItemCommand" OnItemDataBound="dtPaginacion_CobradoSinIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_CobradoSinIntermediario" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_CobradoSinIntermediario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_CobradoSinIntermediario_Click" ImageUrl="~/Imagenes/Siguiente.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_CobradoSinIntermediario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_CobradoSinIntermediario_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>
        <div id="DivCobrosConIntermediario" runat="server">
             <table class="table table-striped">
          <thead class="table-dark">
              <tr>
                  <th scope="col"> Intermediario </th>
                  <th scope="col"> Ramo </th>
                  <th scope="col"> Oficina </th>
                  <th scope="col"> Total </th>
              </tr>
          </thead>
          <tbody>
              <asp:Repeater ID="rpCobradoConIntermediario" runat="server">
                  <ItemTemplate>
                      <tr>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%# Eval("") %> </td>
                           <td> <%#string.Format("{0:N2}", Eval("")) %> </td>
                      </tr>
                  </ItemTemplate>
              </asp:Repeater>
          </tbody>
      </table>
             <table class="table">
                 <tfoot class="table-light">
                    <tr>
                        <td align="right">Pagina <asp:Label ID="lbPaginaActual_CobradoConIntermediario" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> de <asp:Label ID="lbCantidadPagina_CobradoConIntermediario" runat="server" Text="0" CssClass="Letranegrita"></asp:Label></td>
                    </tr>
                     <tr>
                        <td align="left"><b>Cobrado Santo Domingo:</b> <asp:Label ID="lbCobradoSantoDomingo_CobradoConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cobrado Santiago:</b>  <asp:Label ID="lbCobradoSantiago_CobradoConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cobrado Otros:</b>  <asp:Label ID="lbCobradoOtros_CobradoConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Total Cobrado:</b>  <asp:Label ID="lbTotalCobrado_CobradoConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cobrado Hoy</b>  <asp:Label ID="lbCobradoHoy_CobradoConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                      <tr>
                        <td align="left"><b>Cobrado Mes Anterior:</b>  <asp:Label ID="lbCobradoMesAnterior_CobradoConIntermediario" runat="server" Text=" 0 "></asp:Label></td>
                    </tr>
                </tfoot>
            </table>
          <div id="Div1" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPagina_CobradoConIntermediario" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" OnClick="btnPrimeraPagina_CobradoConIntermediario_Click" ImageUrl="~/Imagenes/Primera Pagina.png" /> </td>
                    <td> <asp:ImageButton ID="btnPaginaAnterior_CobradoConIntermediario" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" OnClick="btnPaginaAnterior_CobradoConIntermediario_Click" ImageUrl="~/Imagenes/Anterior.png" />  </td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacion_CobradoConIntermediario" runat="server" OnItemCommand="dtPaginacion_CobradoConIntermediario_ItemCommand" OnItemDataBound="dtPaginacion_CobradoConIntermediario_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentral_CobradoConIntermediario" runat="server" class="btn btn-outline-dark" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePagina_CobradoConIntermediario" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" OnClick="btnSiguientePagina_CobradoConIntermediario_Click" ImageUrl="~/Imagenes/Siguiente.png" />  </td>
                    <td> <asp:ImageButton ID="btnUltimaPagina_CobradoConIntermediario" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" OnClick="btnUltimaPagina_CobradoConIntermediario_Click" ImageUrl="~/Imagenes/Ultima Pagina.png" />  </td>
                </tr>
            </table>
        </div>
        </div>
            <br />
        </div>
    </div>
</asp:Content>
