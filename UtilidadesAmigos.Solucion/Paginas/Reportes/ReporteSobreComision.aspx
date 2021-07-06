<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReporteSobreComision.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReporteSobreComision" %>
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
                          <th style="width:10%" align="left"> CODIGO</th>
                          <th style="width:60%" align="left"> NOMBRE</th>
                          <th style="width:10%" align="left"> INGRESO</th>
                          <th style="width:10%" align="left"> ESTATUS</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater ID="rpListadoCodigosSobreComision" runat="server">
                          <ItemTemplate>
                              <tr>
                                  

                                  <td style="width:10%" align="left"> <asp:Button ID="btnConsultarInformacion" runat="server" Text="Consultar" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnConsultarInformacion_Click" ToolTip="Consultar Comisiones" /> </td>
                                  <td style="width:10%" align="left"> <%# Eval("CodigoBeneficiario") %> </td>
                                  <td style="width:60%" align="left"> <%# Eval("NombreVendedor") %> </td>
                                  <td style="width:10%" align="left"> <%# Eval("Ingreso") %> </td>
                                  <td style="width:10%" align="left"> <%# Eval("Estatus") %> </td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
          </div>

      </div>

    </div>
</asp:Content>
