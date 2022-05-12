<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="MantenimientoMonedas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Mantenimientos.MantenimientoMonedas" %>
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
                width:50px;
               height:50px;
           }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            //VALIDAR CAMPO TASA DE MONEDA
            $("#<%=btnGuardar.ClientID%>").click(function () {

                var Tasa = $("#<%=txtTasa.ClientID%>").val().length;
                if (Tasa < 1) {

                    alert("El campo tasa no puede estar vacio para modificar este registro, favor de verificar.");
                    $("#<%=txtTasa.ClientID%>").css("border-color", "red");
                    return false;
                }
            });

        })
    </script>

    <br />

    <div align="center">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lbTitulo" runat="server" Text="Mantenimiento de Monedas" CssClass="Letranegrita"></asp:Label>
        <asp:Label ID="lbCodigoMoneda" runat="server" Text="0" Visible="false"></asp:Label>
    </div>

        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col"> Modificar </th>
                    <th scope="col"> Moneda </th>
                    <th scope="col"> SIgla </th>
                    <th scope="col"> Tasa </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpListadoMoneda" runat="server">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hfCodigoMoneda" runat="server" Value='<%# Eval("Codigo") %>' />

                            <td> <asp:ImageButton ID="btnSeleccionarRegistro" runat="server" OnClick="btnSeleccionarRegistro_Click" CssClass="BotonImagen" ToolTip="Modificar Registro" ImageUrl="~/Imagenes/modificar.png" /> </td>
                            <td> <%# Eval("Descripcion") %> </td>
                            <td> <%# Eval("Sigla") %> </td>
                            <td> <%#string.Format("{0:n2}", Eval("Tasa")) %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
 
    <br />
    <div id="DivBloqueModificar" runat="server">
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lbNombreMonedaSeleccionada" runat="server" Text="Moneda" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreMneda" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbsIGLAmONEDA" runat="server" Text="Sigla" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtSiglaMoneda" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lbTasaMoneda" runat="server" Text="Tasa" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtTasa" runat="server" TextMode="Number" step="0.01" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div align="center">
            <asp:ImageButton ID="btnGuardar" runat="server" ToolTip="Guardar Registro" CssClass="BotonImagen" ImageUrl="~/Imagenes/salvar.png" OnClick="btnGuardar_Click" />
            <asp:ImageButton ID="btnVolver" runat="server" ToolTip="Volver Atras" CssClass="BotonImagen" ImageUrl="~/Imagenes/volver-flecha.png" OnClick="btnVolver_Click"/>
        </div>
        <br />
    </div>
</asp:Content>
