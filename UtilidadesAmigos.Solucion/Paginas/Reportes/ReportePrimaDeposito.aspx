<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ReportePrimaDeposito.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ReportePrimaDeposito" %>
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

        .BotonSolicitud {
               width:50px;
               height:50px;
           }
        .BotonImagen {
               width:40px;
               height:40px;
           }
               .auto-style1 {
                   width: 199px;
               }
    </style>

    <script type="text/javascript">
        function ErrorValidacion() {
            alert("Se produjo una error en la validación de este registro, favor de contactar al administrador del sistema para consultar este caso.");
        }
        function USuarioNoValido() {
            alert("No tienes permiso para realizar esta operación.");
        }
    </script>

    <div class="container-fluid">
        <br />
        <div id="DIVBloqueConsulta" runat="server">
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                 <div class="col-md-6">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="col-md-2">
                    <asp:Label ID="lbCCodigoSupervisor" runat="server" Text="Supervisor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoSupervisor" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoSupervisor_TextChanged" CssClass="form-control" TextMode="Number" MaxLength="4" ></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label ID="lbNombreSupervisor" runat="server" Text="Nombre Supervisor" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreSupervisor" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
                </div>

                 <div class="col-md-2">
                    <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Intermediario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediario" runat="server" AutoPostBack="true" OnTextChanged="txtCodigoIntermediario_TextChanged" CssClass="form-control" TextMode="Number" MaxLength="4" ></asp:TextBox>
                </div>

                 <div class="col-md-4">
                    <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre Intermediario" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediario" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbNumeroDeposito" runat="server" Text="Deposito" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroDeposito" runat="server" CssClass="form-control" TextMode="Number" ></asp:TextBox>
                </div>


            </div>
            <br />
            <div class="form-check-inline">
                <asp:Label ID="lbEstatusRegistro" runat="server" Text="Estatus de Registro: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbTodos" runat="server" Text="Todos" GroupName="Estatus" />
                <asp:RadioButton ID="rbPendientes" runat="server" Text="Pendientes" GroupName="Estatus" />
                <asp:RadioButton ID="rbPagados" runat="server" Text="Pagados" GroupName="Estatus" />
                <br />
                <asp:Label ID="lbTipoReporteGenerar" runat="server" Text="Formato Reporte" CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbPDF" runat="server" Text="PDF" GroupName="Formato" />
                <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" GroupName="Formato" />
                <asp:RadioButton ID="rbExelPlano" runat="server" Text="Excel Plano" GroupName="Formato" />
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnConsultar" runat="server" ToolTip="Consultar Registros" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultar_Click" />
                <asp:ImageButton ID="btnReporte" runat="server" ToolTip="Generar Reporte" CssClass="BotonImagen" ImageUrl="~/Imagenes/Reporte.png" OnClick="btnReporte_Click" />
            </div>
            <br />
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col"> Deposito </th>
                         <th scope="col"> Fecha </th>     
                         <th scope="col"> Supervisor </th>
                         <th scope="col"> Intermediario </th>
                        <th scope="col"> Aplicado </th>
                        <th scope="col"> Deposito </th>
                        <th scope="col"> Prima </th>
                         <th scope="col"> Estatus </th>
                         <th scope="col">  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpListadoPrimaDeposito" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroDeposito" runat="server" Value='<%# Eval("NumeroDeposito") %>' />
                                 <asp:HiddenField ID="hfMontoDeposito" runat="server" Value='<%# Eval("MontoPagado") %>' />

                                <td> <%# Eval("NumeroDeposito") %> </td>
                                <td> <%# Eval("Fecha") %> </td>
                                <td> <%# Eval("Supervisor") %> </td>
                                <td> <%# Eval("Intermediario") %> </td>
                                <td> <%#string.Format("{0:N2}", Eval("MontoPagado")) %> </td>
                                <td> <%#string.Format("{0:N2}", Eval("MontoDeposito")) %> </td>
                                <td> <%#string.Format("{0:N2}", Eval("MontoPrima")) %> </td>
                                <td> <%# Eval("Estatus") %> </td>
                                <td> <asp:ImageButton ID="btnSeleccionar" runat="server" ToolTip="Seleccionar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/Procesar.png" OnClick="btnSeleccionar_Click" /> </td>


                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
               <div align="center">
                <asp:Label ID="lbPaginaActualTituloPrimaDeposito" runat="server" Text="Pagina " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbPaginaActualVariablePrimaDeposito" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaTituloPrimaDeposito" runat="server" Text=" de " CssClass="Letranegrita"></asp:Label>
                <asp:Label ID="lbCantidadPaginaVAriablePrimaDeposito" runat="server" Text="0" CssClass="Letranegrita"></asp:Label>
            </div>
             <div id="divPaginacionPolizasNoContactadas" runat="server" align="center">
        <div style="margin-top: 20px;">
            <table style="width: 600px">
                <tr>
                    <td> <asp:ImageButton ID="btnPrimeraPaginaPrimaDeposito" runat="server" ToolTip="Ir a la Primera Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPaginaPrimaDeposito_Click" /> </td>
                    <td> <asp:ImageButton ID="btnAnteriorPrimaDeposito" runat="server" ToolTip="Ir a la Pagina Anterior" CssClass="BotonImagen" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnAnteriorPrimaDeposito_Click" /> </td>
                    <td align="center">
                        <asp:DataList ID="dtPaginacionPrimaDeposito" runat="server" OnItemCommand="dtPaginacionPrimaDeposito_ItemCommand" OnItemDataBound="dtPaginacionPrimaDeposito_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:Button ID="btnPaginacionCentralPrimaDeposito" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                            </ItemTemplate>
                        </asp:DataList>

                    </td>
                    <td> <asp:ImageButton ID="btnSiguientePrimaDeposito" runat="server" ToolTip="Ir a la Pagina Siguiente" CssClass="BotonImagen" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePrimaDeposito_Click" /> </td>
                    <td> <asp:ImageButton ID="btnUltimoPrimaDeposito" runat="server" ToolTip="Ir a la Ultima Pagina" CssClass="BotonImagen" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimoPrimaDeposito_Click" /> </td>
                </tr>
            </table>
        </div>
        </div>
                           <br />
        </div>
    </div>
</asp:Content>
