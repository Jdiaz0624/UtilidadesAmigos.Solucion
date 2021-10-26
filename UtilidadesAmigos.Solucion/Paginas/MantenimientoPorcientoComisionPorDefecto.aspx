<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoPorcientoComisionPorDefecto.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoPorcientoComisionPorDefecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style type="text/css">
        .jumbotron{
            color:#000000; 
            background:#7BC5FF;
            font-size:30px;
            font-weight:bold;
            font-family:'Gill Sans';
            padding:25px;
        }

        .letraNegrita {
        font-weight:bold;
            }
        .Custom{
            width: 78px;
        }
          table {
            border-collapse: collapse;
        }
        

        th {
            background-color: #0094ff;
            color: #000000;
        }
    </style>
    <script type="text/javascript">
        function ClaveSeguridadNoValida() {
            alert("La clave de seguridad ingresada no es valida, favor de verificar");
        }
        function ErrorMantenimiento() {
            alert("Error al realizar al procesar la información, favor de contactar al departamento de IT");
        }
        $(document).ready(function(){

            //FUNCION DEL BOTON PROCESAR
            $("#<%=btnProcesar.ClientID%>").click(function () {
                //VALIDAMOS SI EL CAMPO % DE COMISION ESTA VACIO
                var ValidarcampoPorcientoComision = $("#<%=txtPorcientoComision.ClientID%>").val().length;
                if (ValidarcampoPorcientoComision < 1) {
                    alert("El campo % de comisión no puede estar vacio, favor de verificar");
                    $("#<%=txtPorcientoComision.ClientID%>").css("border-color", "red");
                    return false;

                }
                else {
                    //VALIDAMOS EL CAMPO CLAVE DE SEGURIDAD NO ESTE VACIO
                    var ValidarCampoClaveSeguridad = $("#<%=txtClaveSeguridad.ClientID%>").val().length;
                    if (ValidarCampoClaveSeguridad < 1) {
                        alert("El campo clave de seguridad no puede estar vacio, favor de verificar");
                        $("#<%=txtClaveSeguridad.ClientID%>").css("border-color", "red");
                        return false;
                    }
                }

            });
        })
    </script>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Mantenimiento de Comisiones por defecto"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScripmanagerPorcientoComision" runat="server">
           
        </asp:ScriptManager>

      
        <div class="row">

            <div class="col-md-3">
                <asp:Label ID="lbCodigoRamoConsulta" runat="server" Text="Codigo de Ramo" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoRamoConsulta" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Number" AutoPostBack="true" OnTextChanged="txtCodigoRamoConsulta_TextChanged"></asp:TextBox>
            </div>
             <div class="col-md-3">
                <asp:Label ID="lbDescripcionRamoConsulta" runat="server" Text="Descripción de Ramo" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtDescripcionRamoConsulta" Enabled="false" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>

              <div class="col-md-3">
                <asp:Label ID="lbCodigoSubramoConsulta" runat="server" Text="Codigo de SubRamo" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSubramoConsulta" runat="server" CssClass="form-control" TextMode="Number" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtCodigoSubramoConsulta_TextChanged"></asp:TextBox>
            </div>
             <div class="col-md-3">
                <asp:Label ID="lbDescripcionSunramoConsulta" runat="server" Text="Descripción de SubRamo" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtDescripcionSubramoConsulta" Enabled="false" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Buscar" ToolTip="Buscar" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnConsultar_Click"/>
        </div>
        
        
        <br />
            <!--INICIO DEL GRID-->
    <div class="container-fluid">
            <asp:GridView ID="gvEmpleados" runat="server" AllowPaging="true" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged" OnPageIndexChanging="gvEmpleados_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Seleccionar"  ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Seleccionar" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdRegistro" HeaderText="ID" />
                    <asp:BoundField DataField="CodRamo" HeaderText="CodRamo" />
                    <asp:BoundField DataField="Ramo" HeaderText="Ramo" />
                    <asp:BoundField DataField="CodSubramo" ItemStyle-HorizontalAlign="Left" HeaderText="CodSubramo" />
                    <asp:BoundField DataField="Subramo" ItemStyle-HorizontalAlign="Left" HeaderText="SubRamo" />
                    <asp:BoundField DataField="PorcientoComision" HeaderText="% de Comisión" />
                </Columns  >
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Left" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="center" />
                <RowStyle BackColor="#EEEEEE" HorizontalAlign="Left" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
    </div>
    <!--FIN DEL GRID-->
        <br />

        <!--MANTENIMIENTO DE PORCIENTO DE COMISIONES-->
        <div class="form-check-inline">

                <asp:Label ID="lbTipoPrceso" runat="server" Text="Seleccionar Tipo de Modificación" Visible="false" CssClass="letraNegrita"></asp:Label><br />
                <asp:RadioButton ID="rbModificarSubRamoSeleccionadoMantenimiento" Visible="false" runat="server" Text="Modificar Sub Ramo Seleccionado" CssClass="form-check-input" ToolTip="Modificar el % de Comisión del subramo seleccionado" GroupName="Modificar" />
                 <asp:RadioButton ID="rbModificarTodoRamoSeleccionado" runat="server" Visible="false" Text="Modificar Todo el Ramo" CssClass="form-check-input" ToolTip="Modificar el % de Comisión de todo el ramo" GroupName="Modificar" />
     
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lbCodigoRamoMantenimiento" runat="server" Text="Codigo de Ramo" Visible="false" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoRamoMantenimiento" runat="server" CssClass="form-control" Visible="false" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbDescripcionRamomantenimiento" runat="server" Text="Descripción de Ramo" Visible="false" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtDescripcionRamoMantenimiento" runat="server" CssClass="form-control" Visible="false" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbCodigoSubRamoMantenimiento" runat="server" Text="Codigo de SubRamo" Visible="false" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoSubramoMantenimiento" runat="server" CssClass="form-control" Visible="false" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbDescripcionSubramoMantenimiento" runat="server" Text="Descripción de SubRamo" Visible="false" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtDescripcionSubramoMantenimiento" runat="server" Visible="false" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lbPorcientoComisionMantenimiento" runat="server" Visible="false" Text="% de Comisión" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtPorcientoComision" runat="server" Visible="false" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Number" step="0.01" ></asp:TextBox>
            </div>
             <div class="col-md-3">
                <asp:Label ID="lbClaveSeguridad" runat="server" Visible="false" Text="Clave de Seguridad" CssClass="letraNegrita"></asp:Label>
                <asp:TextBox ID="txtClaveSeguridad" runat="server" Visible="false" AutoCompleteType="Disabled" CssClass="form-control" TextMode="Password" ></asp:TextBox>
            </div>
        </div>
         <div align="center">
            <asp:Button ID="btnProcesar" runat="server" Text="Procesar" Visible="false" ToolTip="Procesar Registro" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnProcesar_Click"/>
             <asp:Button ID="btnVolver" runat="server" Text="Volver" Visible="false" ToolTip="VolverAtras" CssClass="btn btn-outline-primary btn-sm Custom" OnClick="btnVolver_Click"/>
        </div>
    </div>
</asp:Content>
