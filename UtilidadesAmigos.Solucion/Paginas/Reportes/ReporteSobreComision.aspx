﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteSobreComision.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReporteSobreComision" %>
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
            background-color: dodgerblue;
            color: white;
        }
    </style>

    <script type="text/javascript">
        function FechaDesdeVacio() {
            $("#<%=txtFechadesde.ClientID%>").css("border-color", "red");
        }
        function FechaHastaVacio() {
            $("#<%=txtFechaHAsta.ClientID%>").css("border-color", "red");
        }
    </script>

    <br />
    <div class="container-fluid">

      <div id="DivBloqueConsulta" runat="server">
          <asp:Label ID="lbCodigobeneficiarioSeleccionado" Text="0" runat="server"></asp:Label>
           <asp:Label ID="lbPorcientoComisionBeneficiario" Text="0" runat="server"></asp:Label>

            <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechadesde" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-6">
                <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtFechaHAsta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
          <br />
        <div align="center">
            <asp:Button ID="btnCodigosPermitidos" runat="server" Text="Codigos" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnCodigosPermitidos_Click" />
        </div>
          <br />

          <div class="table-responsive">
              <table class="table table-hover">
                  <thead>
                      <tr>
                          <th style="width:10%" align="left"> CONSULTAR</th>
                         <%-- <th style="width:10%" align="left"> CODIGO</th>--%>
                          <th style="width:60%" align="left"> NOMBRE</th>
                          <th style="width:10%" align="left"> % COMISION</th>
                          <th style="width:10%" align="left"> INGRESO</th>
                          <th style="width:10%" align="left"> ESTATUS</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater ID="rpListadoCodigosSobreComision" runat="server">
                          <ItemTemplate>
                              <tr>
                                  
                                  <asp:HiddenField ID="hfCodigoBeneficiario" runat="server" Value='<%# Eval("CodigoBeneficiario") %>' />
                                  <asp:HiddenField ID="hfPorcientoComisionBeneficiario" runat="server" Value='<%# Eval("PorcientoComision") %>' />


                                  <td style="width:10%" align="left"> <asp:Button ID="btnConsultarInformacion" runat="server" Text="Consultar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultarInformacion_Click" ToolTip="Consultar Comisiones" /> </td>
                                  <%--<td style="width:10%" align="left"> <%# Eval("CodigoBeneficiario") %> </td>--%>
                                  <td style="width:60%" align="left"> <%# Eval("NombreVendedor") %> </td>
                                  <td style="width:50%" align="left"> <%# string.Format("{0:n2}", Eval("Comision")) %> </td>
                                  <td style="width:10%" align="left"> <%# Eval("Ingreso") %> </td>
                                  <td style="width:10%" align="left"> <%# Eval("Estatus") %> </td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
          </div>
          <br />
          <div align="center">
              <asp:Label ID="lbTotalCobradoNetoTitulo" runat="server" Text="Total Cobrado Neto ( " CssClass="LetrasNegrita"></asp:Label>
               <asp:Label ID="lbTotalCobradoVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
               <asp:Label ID="lbTotalCobradoCerrar" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
               <asp:Label ID="lbSeparador" runat="server" Text=" " CssClass="LetrasNegrita"></asp:Label>
               <asp:Label ID="lbComisionPagarTitulo" runat="server" Text="Comisión a Pagar ( " CssClass="LetrasNegrita"></asp:Label>
               <asp:Label ID="lbComisionPagarVariable" runat="server" Text="0" CssClass="LetrasNegrita"></asp:Label>
               <asp:Label ID="lbComisionPagarCerrar" runat="server" Text=" )" CssClass="LetrasNegrita"></asp:Label>
          </div>
          <br />
          <div class="table-responsive">
              <table class="table table-hover">
                  <thead>
                      <tr>
                          <th style="width:25%" align="left"> SUPERVISOR </th>
                          <th style="width:10%" align="left"> MONEDA </th>
                          <th style="width:10%" align="left"> CANTIDAD </th>
                          <th style="width:15%" align="left"> BRUTO </th>
                          <th style="width:10%" align="left"> IMPUESTO </th>
                          <th style="width:15%" align="left"> NETO </th>
                          <th style="width:15%" align="left"> PESOS </th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater ID="rpCobradoSupervisores" runat="server">
                          <ItemTemplate>
                              <tr>
                                  <td style="width:25%" align="left"> <%# Eval("#") %> </td>
                                  <td style="width:10%" align="left"> <%# Eval("#") %> </td>
                                  <td style="width:10%" align="left"> <%# string.Format("{0:n0}", Eval("#")) %> </td>
                                  <td style="width:15%" align="left"> <%# string.Format("{0:n2}", Eval("#")) %> </td>
                                  <td style="width:10%" align="left"> <%# string.Format("{0:n2}", Eval("#")) %> </td>
                                  <td style="width:15%" align="left"> <%# string.Format("{0:n2}", Eval("#")) %> </td>
                                  <td style="width:15%" align="left"> <%# string.Format("{0:n2}", Eval("#")) %> </td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
          </div>

            <div align="center">
                <asp:Label ID="lbPaginaActualTituloCobradoSupervisores" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariavleCobradoSupervisores" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloCobradoSupervisores" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriableCobradoSupervisores" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionCobradoSupervisores" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:LinkButton ID="LinkPrimeraPaginaCobradoSupervisores" runat="server" Text="Primero" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la primera pagina del listado" OnClick="LinkPrimeraPaginaCobradoSupervisores_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkAnteriorCobradoSupervisores" runat="server" Text="Anterior" CssClass="btn btn-outline-success btn-sm" ToolTip="Ir a la pagina anterior del listado" OnClick="LinkAnteriorCobradoSupervisores_Click"></asp:LinkButton> </td>
                    <td>
                        <asp:DataList ID="dtPaginacionCobradoSupervisores" runat="server" OnItemCommand="dtPaginacionCobradoSupervisores_ItemCommand" OnItemDataBound="dtPaginacionCobradoSupervisores_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkPaginacionCentralCobradoSupervisores" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' Width="20px"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:LinkButton ID="LinkSiguienteCobradoSupervisores" runat="server" Text="Siguiente" ToolTip="Ir a la siguiente pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkSiguienteCobradoSupervisores_Click"></asp:LinkButton> </td>
                    <td> <asp:LinkButton ID="LinkUltimoCobradoSupervisores" runat="server" Text="Ultimo" ToolTip="Ir a la ultima pagina del listado" CssClass="btn btn-outline-success btn-sm" OnClick="LinkUltimoCobradoSupervisores_Click"></asp:LinkButton> </td>
                </tr>
            </table>
        </div>
        </div>
          <br />

      </div>

    </div>
</asp:Content>
