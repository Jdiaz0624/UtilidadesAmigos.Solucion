<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoDependientes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.MantenimientoDependientes" %>
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

        .btn-sm{
            width:90px;
        }
          .LetrasNegrita {
          font-weight:bold;
          }
          .tamano {
         font-size:20px;
         color:red;
              }

    </style>
    <script type="text/javascript">

        function ErrorMantenimiento() {
            alert("Error al realizar este mantenimiento");
        }

        function BloquearControlesQuitarModificar() {
            $("#<%=txtNombreQuitarModificar.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtParentezcoQuitarModificar.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtCedulaQuitarModificar.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtFechaNacimientoQuitarModificar.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtSexoQuitarModificar.ClientID%>").attr("disabled", "disabled");
            $("#<%=txtPrimaQuitarModificar.ClientID%>").attr("disabled", "disabled");
            $("#<%=btnQuitar.ClientID%>").show();
            $("#<%=btnModificarMantenimiento.ClientID%>").hide();
        }
        function ActivarControlesQuitarModificar() {
            $("#<%=txtNombreQuitarModificar.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtParentezcoQuitarModificar.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtCedulaQuitarModificar.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtFechaNacimientoQuitarModificar.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtSexoQuitarModificar.ClientID%>").removeAttr("disabled", true);
            $("#<%=txtPrimaQuitarModificar.ClientID%>").removeAttr("disabled", true);
            $("#<%=btnQuitar.ClientID%>").hide();
            $("#<%=btnModificarMantenimiento.ClientID%>").show();
        }
        function PolizaNoEncontrada() {
            alert("El numero de poliza ingresado no esta registrado en la base de datos, favor de verificar");
        }
        function ActivarRestablecerAgregar() {
            $("#<%=btnRestabelecer.ClientID%>").removeAttr("disabled", true);
            $("#btnAgregarDependiente").removeAttr("disabled", true);
            $("#<%=btnConsultar.ClientID%>").attr("disabled", "disabled");
        }
        function DesactivarRestablecerAgregar() {
            $("#<%=btnRestabelecer.ClientID%>").attr("disabled", "disabled");
            $("#btnAgregarDependiente").attr("disabled", "disabled");
            $("#<%=btnConsultar.ClientID%>").removeAttr("disabled", true);
        }

        function ActivarQuitarModificar() {
            $("#btnQuitarDependiente").removeAttr("disabled", true);
            $("#btnModificar").removeAttr("disabled", true);
        }

        function DesactivarQuitarModificar() {
            $("#btnQuitarDependiente").attr("disabled","disabled");
            $("#btnModificar").attr("disabled", "disabled");
        }
        $(document).ready(function () {
            //PROGRAMADOS EL EVENTO CLICO DEL NTON QUITAR
            $("#btnQuitarDependiente").click(function () {
                BloquearControlesQuitarModificar();

            });

             //PROGRAMADOS EL EVENTO CLICO DEL NTON QUITAR
            $("#btnModificar").click(function () {
                ActivarControlesQuitarModificar();

            });

            //PROGRAMAMOS EL EVENTO CLICK DEL BOTON NUEVO
            $("#btnAgregarDependiente").click(function () {
                $("#<%=txtNombreMantenimiento.ClientID%>").val("");
                $("#<%=txtCedula.ClientID%>").val("");
                $("#<%=txtFechaNacimiento.ClientID%>").val("");
                $("#<%=txtPrima.ClientID%>").val("");


            
                $("#<%=txtNombreQuitarModificar.ClientID%>").val("");
                $("#<%=txtCedulaQuitarModificar.ClientID%>").val("");
                $("#<%=txtFechaNacimientoQuitarModificar.ClientID%>").val("");
                $("#<%=txtPrimaQuitarModificar.ClientID%>").val("");


                BloquearControlesQuitarModificar();
            });

            //PROGRAMAMOS EL EVENTO CLICK DEL BOTON CONSULTAR
            $("#<%=btnConsultar.ClientID%>").click(function () {
                var Poliza = $("#<%=txtPolizaConsulta.ClientID%>").val().length;
                if (Poliza < 1) {
                    alert("EL campo poliza no puede estar vacio, para ralizar esta consulta");
                    $("#<%=txtPolizaConsulta.ClientID%>").css("border-color", "red");
                    return false;

                }

            });
            //PROGRAMAMOS EL EVENTO CLICK DEL BOTON GUARDAR
            $("#<%=btnGuardar.ClientID%>").click(function () {
                var Nombre = $("#<%=txtNombreMantenimiento.ClientID%>").val().length;
                if (Nombre < 1) {
                    alert("El campo nombre no puede estar vacio para guardar este registro");
                    $("#<%=txtNombreMantenimiento.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var Parentezco = $("#<%=txtParentezzcoMantenimiento.ClientID%>").val().length;
                    if (Parentezco < 1) {
                        alert("El campo parentezco no puede estar vacio para guardar este registro, favor de verificar");
                        $("#<%=txtParentezzcoMantenimiento.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var Cedula = $("#<%=txtCedula.ClientID%>").val().length;
                        if (Cedula < 1) {
                            alert("El campo cedula no puede estar vacio para guardar este registro, favor de verificar");
                            $("#<%=txtCedula.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else
                        {
                            var FechaNacimiento = $("#<%=txtFechaNacimiento.ClientID%>").val().length;
                            if (FechaNacimiento < 1) {
                                 $("#<%=txtFechaNacimiento.ClientID%>").css("border-color", "red");
                                alert("El campo fecha de nacimiento no puede estar vacio para guardar este registro, favor de verificar");
                                return false;
                            }
                            else {
                                var Sexo = $("<%=txtSexoMantenimiento.ClientID%>").val();
                                if (Sexo < 1) {
                                    alert("El campo sexo no puede estar vacio para guardar este registro, favor de verificar");
                                    return false;
                                }
                                else {
                                    var Prima = $("#<%=txtPrima.ClientID%>").val().length;
                                    if (Prima < 1) {
                                        alert("El campo prima no puede estar vacio para guardar este registro, favor de verificar");
                                        return false;
                                    }
                                    
                                }
                            }
                        }
                    }
                }

            });

            //PROHTAMAMOS EL EVENTO CLICK DEL BOTON GUARDAR
            $("#<%=btnModificarMantenimiento.ClientID%>").click(function () {
                var ModificarNombre = $("#<%=txtNombreQuitarModificar.ClientID%>").val().length;
                if (ModificarNombre < 1) {
                    alert("El campo nombre no puede estar vacio para modificar este registro, favor de verificar");
                    $("#<%=txtNombreQuitarModificar.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var ModificarParentezco = $("#<%=txtParentezcoQuitarModificar.ClientID%>").val();
                    if (ModificarParentezco < 1) {
                        alert("El campo parentezco no puede estar vacio para modificar este registro, favor de verificar");
                        $("#<%=txtParentezcoQuitarModificar.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var ModificarCedula = $("#<%=txtCedulaQuitarModificar.ClientID%>").val().length;
                        if (ModificarCedula < 1) {
                            alert("El campo cedula no puede estar vacio para modificar este registro, favor de verificar");
                            $("#<%=txtCedulaQuitarModificar.ClientID%>").css("border-color", "red");
                            return false;
                        }
                        else {
                            var ModificarFechaNacimiento = $("#<%=txtFechaNacimientoQuitarModificar.ClientID%>").val().length;
                            if (ModificarFechaNacimiento < 1) {
                                alert("El campo Fecha de Nacimiento no puede estar vacio para modificar este registro, favor de verificar");
                                $("#<%=txtFechaNacimientoQuitarModificar.ClientID%>").css("border-color", "red");
                                return false;
                            }
                            else {
                                var ModificarSexo = $("#<%=txtSexoQuitarModificar.ClientID%>").val();
                                if (ModificarSexo < 1) {
                                    alert("El campo sexo no puede estar vacio para modificar este registro, favor de verificar");
                                    $("#<%=txtSexoQuitarModificar.ClientID%>").css("border-color", "red");
                                    return false;
                                }
                                else {
                                    var ModificarPrime = $("#<%=txtPrimaQuitarModificar.ClientID%>").val().length;
                                    if (ModificarPrime < 1) {
                                        alert("El campo prima no puede estar vacio para modificar este registro, favor de verificar");
                                        $("#<%=txtPrimaQuitarModificar.ClientID%>").css("border-color", "red");
                                        return false
                                    }
                                }
                            }
                        }
                    }
                }
            });

        });
    </script>
    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="ldTituloConsulta" runat="server" Text="Consulta de Dependientes"></asp:Label>
            <asp:Label ID="lbIdAsegurado" runat="server" Text="IdAsegurado" Visible="false"></asp:Label>
            <asp:Label ID="lbPolizaFiltrada" runat="server" Text="Poliza" Visible="false"></asp:Label>
        </div>
        <!--INICIO DE LOS CONTROLES PARA REALIZAR LA CONSULTA-->
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbNumeroPoliza" runat="server" CssClass="LetrasNegrita" Text="Poliza"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
               
            </div>
           
            
        </div>
         <div>
             <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnConsultar_Click" />
             <asp:Button ID="btnRestabelecer" runat="server" Text="Restablecer" CssClass="btn btn-outline-primary btn-sm" ToolTip="Consultar Registros" OnClick="btnRestabelecer_Click" />
             <button type="button" id="btnAgregarDependiente" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".AgregarRegistrosPOPO">Agregar</button>
             <button type="button" id="btnQuitarDependiente" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".QuitarModificarRegistrosPOPO">Quitar</button>
             <button type="button" id="btnModificar" class="btn btn-outline-primary btn-sm" data-toggle="modal" data-target=".QuitarModificarRegistrosPOPO">Modificar</button>
            </div>
        <br />
        <div align="center">
            <asp:Label ID="lbEstatusPoliza" runat="server" Text="Estatus" Visible="false" CssClass="LetrasNegrita tamano"></asp:Label><br />
            <asp:Label ID="lbRamo" runat="server" Text="Ramo" Visible="false" CssClass="LetrasNegrita tamano"></asp:Label><br />
            <asp:Label ID="lbSubramo" runat="server" Text="Subramo" Visible="false" CssClass="LetrasNegrita tamano"></asp:Label>
        </div>
         <div>
            <asp:GridView ID="gvDependientes" runat="server" AllowPaging="true" OnPageIndexChanging="gvDependientes_PageIndexChanging" OnSelectedIndexChanged="gvDependientes_SelectedIndexChanged" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                   <%-- <%$ Resources:Traducciones,OrdenNivel %>--%>
                    
                    <asp:BoundField DataField="IdAsegurado" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Parentezco" HeaderText="Parentezco" />
                    <asp:BoundField DataField="Cedula" HeaderText="No. Identificación" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="PorcPrima" HeaderText="Prima" />
                     <asp:CommandField ButtonType="Button" HeaderStyle-Width="11%" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-outline-primary btn-sm" SelectText="Ver" ShowSelectButton="True" />
                </Columns  >
                 <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#7BC5FF" HorizontalAlign="Center" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#7BC5FF" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" HorizontalAlign="Center" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
    </div>
        <!--FIN DE LOS CONTROLES PARA REALIZAR LA CONSULTA-->
    </div>

    <!--INICIO DE LOS CONTROLES DE MANTENIMIENTO -->
    <div class="modal fade bd-example-modal-lg AgregarRegistrosPOPO" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="TituloMantenimiento" runat="server" Text="Mantenimiento de Dependientes"></asp:Label>
          </div>
          <asp:ScriptManager ID="AgregarScriptManager" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="AgregarUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                  <div class="form-row">
              <div class="form-group col-md-6">
                  <asp:Label ID="lbNombreMantenimiento" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtNombreMantenimiento" AutoCompleteType="Disabled" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                    <asp:Label ID="lbParentezco" runat="server" Text="Parentezco" CssClass="LetrasNegrita"></asp:Label>
                   <asp:TextBox ID="txtParentezzcoMantenimiento"  runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbNumeroID" runat="server" Text="Cedula" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtCedula" runat="server" MaxLength="150" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                   <asp:Label ID="lbFechaNacimiento" runat="server" Text="Fecha Nacimiento" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbSexoMantenimiento" runat="server" Text="Sexo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtSexoMantenimiento" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                       <asp:Label ID="lbProma" runat="server" Text="Prima" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtPrima" runat="server" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
              </ContentTemplate>
          </asp:UpdatePanel>
          <div align="center">
              <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Guardar Registros" OnClick="btnGuardar_Click" />
          </div>
          <br />
      </div>
    </div>
  </div>
</div>

<!--QUITAR Y MODIFICAR-->
        <div class="modal fade bd-example-modal-lg QuitarModificarRegistrosPOPO" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="container-fluid">
          <div class="jumbotron" align="center">
              <asp:Label ID="Label1" runat="server" Text="Mantenimiento de Dependientes"></asp:Label>
          </div>
          <asp:UpdatePanel ID="QuitarModificarUpdatePanel" runat="server" Visible="true">
              <ContentTemplate>
                  <div class="form-row">
              <div class="form-group col-md-6">
                  <asp:Label ID="lbNombreQuitarModificar" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtNombreQuitarModificar" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                    <asp:Label ID="lbParentezcoQuitarModificar" runat="server" Text="Parentezco" CssClass="LetrasNegrita"></asp:Label>
                   <asp:TextBox ID="txtParentezcoQuitarModificar" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbCedulaQuitarModificar" runat="server" Text="Cedula" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtCedulaQuitarModificar" runat="server" MaxLength="150" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                   <asp:Label ID="lbFechaNacimientoQuitarModificar" runat="server" Text="Fecha Nacimiento" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtFechaNacimientoQuitarModificar" runat="server"  CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                  <asp:Label ID="lbSexoQuitarModificar" runat="server" Text="Sexo" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtSexoQuitarModificar" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group col-md-6">
                       <asp:Label ID="lbPrimaQUitarModificar" runat="server" Text="Prima" CssClass="LetrasNegrita"></asp:Label>
                  <asp:TextBox ID="txtPrimaQuitarModificar" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
              </ContentTemplate>
          </asp:UpdatePanel>
          <div align="center">
              <asp:Button ID="btnModificarMantenimiento" runat="server" Text="Modificar" CssClass="btn btn-outline-primary btn-sm" ToolTip="Modificar Registros" OnClick="btnModificarMantenimiento_Click" />
              <asp:Button ID="btnQuitar" runat="server" Text="Quitar" CssClass="btn btn-outline-primary btn-sm" ToolTip="quitar Registros" OnClick="btnQuitar_Click" />
          </div>
          <br />
      </div>
    </div>
  </div>
</div>

</asp:Content>
