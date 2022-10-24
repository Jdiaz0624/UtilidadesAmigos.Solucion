<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ImpresionCheques.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Reportes.ImpresionCheques" %>
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

         .btn-ddd{
            width:200px;
        }

        .Letranegrita {
        font-weight:bold;
        }
        table {
            border-collapse: collapse;
        }
        

        th {
            background-color: dodgerblue;
            color: white;
        }
          .BotonImagen {
         width:40px;
         height:40px;
       
       }
    </style>

    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
       <br /><br />

        <div id="DIVFormatos" runat="server" class="form-check-inline">
            <asp:Label ID="lbFormatoCheque" runat="server" Text="Formato: " CssClass="Letranegrita"></asp:Label>
            <asp:RadioButton ID="rbPDF" runat="server" Text="PDF"  ToolTip="Generar en PDF" GroupName="FormatoCheque" />
            <asp:RadioButton ID="rbExcel" runat="server" Text="Excel" ToolTip="Generar en Excel" GroupName="FormatoCheque" />
            <asp:RadioButton ID="rbWord" runat="server" Text="Word"  ToolTip="Generar en Word" GroupName="FormatoCheque" />

        </div>
        <br />
        <div class="form-check-inline">
            <asp:Label ID="lbEstatusCheque" runat="server" Text="Estatus: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbActivos" runat="server" Text="Activos"  ToolTip="Mostrar solo los cheques activos" GroupName="Estatus" />
                <asp:RadioButton ID="rbAnulados" runat="server" Text="Anulados"  ToolTip="Mostrar solo los cheques anulados" GroupName="Estatus" />
                <asp:RadioButton ID="rbTodos" runat="server" Text="Todos"  ToolTip="Mostrar todos los cheques" GroupName="Estatus" />
        </div>
        <br />
        <div class="form-check-inline">
                <asp:Label ID="lbParametrosEspeciales" runat="server" Text="Otros Parametros: " CssClass="Letranegrita"></asp:Label>
                <asp:RadioButton ID="rbSinParametros" runat="server" Text="No Aplicar"  AutoPostBack="true" OnCheckedChanged="rbSinParametros_CheckedChanged" ToolTip="No Aplicar PArametros" GroupName="Parametros" />
                <asp:RadioButton ID="rbRangoFecha" runat="server" Text="Rango de Fecha"  AutoPostBack="true" OnCheckedChanged="rbRangoFecha_CheckedChanged" ToolTip="Agregar filtro por rango de fecha" GroupName="Parametros" />
                <asp:RadioButton ID="rbRangoValor" runat="server" Text="Rango de Valor"  AutoPostBack="true" OnCheckedChanged="rbRangoValor_CheckedChanged" ToolTip="Agregar filtro por rango de valor" GroupName="Parametros" />
                <asp:RadioButton ID="rbRangoCheque" runat="server" Text="Rango de Cheque"  AutoPostBack="true" OnCheckedChanged="rbRangoCheque_CheckedChanged" ToolTip="Agregar filtro por rango de cheque" GroupName="Parametros" />
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lbNumeroChequeConsulta" runat="server" Text="Numero de Cheque" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNumeroChequeConsulta" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbBeneficiarioConsulta" runat="server" Text="Beneficiario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtBeneficiario" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lbBAnco" runat="server" Text="Banco" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarBanco" runat="server" ToolTip="Seleccionar Banco para Filtro" CssClass="form-control"></asp:DropDownList>
            </div>
           <div class="col-md-12">
                    <asp:Label ID="lbImpresora" runat="server" Text="Seleccionar Impresora" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlImpresoras" runat="server" ToolTip="Seleccionar Impresora" CssClass="form-control"></asp:DropDownList> 
                </div>
        </div>
        <div id="DivRangoFecha" runat="server">
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbFechaDesde" runat="server" Text="Fecha Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <asp:Label ID="lbFechaHasta" runat="server" Text="Fecha Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            
        </div>
        <div id="DivRangoCheque" runat="server">
               <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbNumeroChequeDesde" runat="server" Text="Cheque Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtChequeDesde" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <asp:Label ID="lbNumeroChqequeHasta" runat="server" Text="Cheque Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtNumeroChequeHasta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="divRangoValor" runat="server">
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbRangoValorDesde" runat="server" Text="Valor Desde" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtValorDesde" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <asp:Label ID="lbValorHasta" runat="server" Text="Valor Hasta" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtVAlorHasta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                 
            </div>
        </div>
        <br />
        <br />
        <div align="center">
            <asp:ImageButton ID="btnConsultarRegistros" runat="server" ToolTip="Consultar Información" CssClass="BotonImagen" ImageUrl="~/Imagenes/Buscar.png" OnClick="btnConsultarRegistros_Click" />
            <br /><br />
            <asp:Label ID="lbCantidadRegistrosTitulo" runat="server" Text="Cantidad de Registros ( " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
            <asp:Label ID="lbCantidadRegistrosCerrar" runat="server" Text=" ) " CssClass="Letranegrita"></asp:Label>
        </div>
        <br />
        <div class="table">
            <table class="table table-striped">
                <thead class="table-dark">
                    <tr>
                        
                        <th scope="col"> <asp:Label ID="lbChequeHEaderRepeater" runat="server" Text="Cheque" CssClass="Letranegrita"></asp:Label> </th>
                        <th scope="col"> <asp:Label ID="lbFechaHEaderRepeater" runat="server" Text="Fecha" CssClass="Letranegrita"></asp:Label> </th>
                        <th scope="col"> <asp:Label ID="lbBeneficiarioHEaderRepeater" runat="server" Text="Beneficiario" CssClass="Letranegrita"></asp:Label> </th>
                        <th scope="col"> <asp:Label ID="lbValorHEaderRepeater" runat="server" Text="Valor" CssClass="Letranegrita"></asp:Label> </th>
                        <th scope="col"> <asp:Label ID="lbBAncoHEaderRepeater" runat="server" Text="Banco" CssClass="Letranegrita"></asp:Label> </th>
                        <th scope="col"> <asp:Label ID="lbAnulado" runat="server" Text="Anulado" CssClass="Letranegrita"></asp:Label> </th>
                        <th scope="col" >  </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rbListadoCheques" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hfNumeroChqeue" runat="server" Value='<%# Eval("NumeroCheque") %>' />
                                <asp:HiddenField ID="hfBeneficiario" runat="server" Value='<%# Eval("Beneficiario1") %>' />
                                <asp:HiddenField ID="hfBanco" runat="server" Value='<%# Eval("CtaBanco") %>' />

                                
                                <td> <%# Eval("NumeroCheque") %> </td>
                                <td> <%# Eval("FechaCheque") %> </td>
                                <td> <%# Eval("Beneficiario1") %> </td>
                                <td> <%#string.Format("{0:n2}", Eval("Valor")) %> </td>
                                <td> <%# Eval("Banco") %> </td>
                                <td> <%# Eval("Anulado") %> </td>
                                <td> <asp:ImageButton ID="btnImprimir" runat="server" ToolTip="Generar Cheque" CssClass="BotonImagen" OnClick="btnImprimir_Click" ImageUrl="~/Imagenes/impresora.png" /> </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
       <table class="table">
                <tfoot class="table-light">
                    <tr>
                        <td align="right"><b>Pagina </b> <asp:Label ID="lbPaginaActual" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label> <b>De </b>   <asp:Label ID="lbCantidadPagina" runat="server" Text="0" CssClass="Letranegrita"></asp:Label> </td>
                    </tr>
                   
                </tfoot>
            </table>
              <div id="DivPaginacionListadoPrincipal" runat="server" align="center" >
                <div style="margin-top=20px;">
                    <table style="width:600px;">
                        <tr>
                            <td> <asp:ImageButton ID="btnPrimeraPagina" runat="server" ImageUrl="~/Imagenes/Primera Pagina.png" OnClick="btnPrimeraPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnPaginaAnterior" runat="server" ImageUrl="~/Imagenes/Anterior.png" OnClick="btnPaginaAnterior_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td align="center">
                                <asp:DataList ID="dtPaginacionListadoPrincipal" runat="server" OnCancelCommand="dtPaginacionListadoPrincipal_CancelCommand" OnItemDataBound="dtPaginacionListadoPrincipal_ItemDataBound" RepeatDirection="Horizontal" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnPaginacionCentral" runat="server" CommandArgument='<%# Eval("IndicePagina") %>' CommandName="newPage" Text='<%# Eval("TextoPagina") %>' CssClass="btn btn-outline-dark" />
                                    </ItemTemplate>
                                </asp:DataList>

                            </td>
                            <td> <asp:ImageButton ID="btnSiguientePagina" runat="server" ImageUrl="~/Imagenes/Siguiente.png" OnClick="btnSiguientePagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                            <td> <asp:ImageButton ID="btnUltimaPagina" runat="server" ImageUrl="~/Imagenes/Ultima Pagina.png" OnClick="btnUltimaPagina_Click" CssClass="BotonImagen" ToolTip="Ir a la Primera Pagina" /> </td>
                           
                        </tr>
                    </table>
                </div>
            </div>
        <br />
           


   
    </div>
</asp:Content>
