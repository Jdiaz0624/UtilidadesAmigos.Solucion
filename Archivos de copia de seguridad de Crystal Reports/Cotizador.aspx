<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="Cotizador.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProcesoPoliza.Cotizador" %>
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

        .Letranegrita2 {
             font-weight:bold;
          font-size:30px;
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

        .BotonImagen {
                width:80px;
               height:80px;
           }
    </style>

    <script type="text/javascript">
        function OpcionNoDisponible(){
            alert("Esta opción no esta disponible por el momento.");
        }
        $(document).ready(function () {

            $("#<%=btnCotizar.ClientID%>").click(function () {

                var Ano = $("#<%=ddlSeleccionarAnoVehiculo.ClientID%>").val();
                if (Ano < 1) {
                    alert("El campo Año de Vehiculo no puede estar vacio para cotizar, favor de verificar.");
                    $("#<%=ddlSeleccionarAnoVehiculo.ClientID%>").css("border-color", "red");
                    return false;
                }
                else {
                    var TipoVehiculo = $("#<%=ddlSeleccionarTipoVehiculo.ClientID%>").val();
                    if (TipoVehiculo < 1) {
                        alert("El campo Tipo de Vehiculo no puede estar vacio para cotizar, favor de verificar.");
                        $("#<%=ddlSeleccionarTipoVehiculo.ClientID%>").css("border-color", "red");
                        return false;
                    }
                    else {
                        var ValorVehiculo = $("#<%=txtValorVehiculo.ClientID%>").val().length;
                        if (ValorVehiculo < 1) {
                            alert("El campo valor de vehiculo no puede estar vacio para cotizar, favor de verificar.");
                            $("#<%=txtValorVehiculo.ClientID%>").css("border-color", "red");
                            return false;
                        }
                    }
                }
            });
        })
    </script>

    <div class="container-fluid">
        <asp:Label ID="lbIdPerfil" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <div class="form-check-inline">
            <asp:RadioButton ID="rbSegurosFull" runat="server" Text="Cotizar Full" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="rbSegurosFull_CheckedChanged" GroupName="Cotizador" /> 
            <asp:RadioButton ID="rbSegurosLey" runat="server" Text="Cotizar Ley" CssClass="form-check-input Letranegrita" AutoPostBack="true" OnCheckedChanged="rbSegurosLey_CheckedChanged" GroupName="Cotizador" /> 
        </div>

        <div id="DIVBloqueSegurosFull" visible="false" runat="server">
             <div id="DIVBloqueCotizador" runat="server">
            <br />
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lbSeleccionarAno" runat="server" Text="Año de Vehiculo" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarAnoVehiculo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarAnoVehiculo_SelectedIndexChanged" ToolTip="Seleccionar Año de Vehiculo" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbSeleccionarTipoVehiculo" runat="server" Text="Tipo de Vehiculo" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarTipoVehiculo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionarTipoVehiculo_SelectedIndexChanged" ToolTip="Seleccionar Tipo de Vehiculo" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbSeleccionarPorcentaje" runat="server" Text="Porcentaje" CssClass="Letranegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarPorcentaje" runat="server" ToolTip="Seleccionar el Porcentaje" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label ID="lbValorVehiculo" runat="server" Text="Valor de Vehiculo" CssClass="Letranegrita"></asp:Label>
                    <asp:TextBox ID="txtValorVehiculo" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
                </div>
            </div>
            <br />
            <div align="center">
                <asp:ImageButton ID="btnCotizar" runat="server" ToolTip="Cotizar" CssClass="BotonImagen" ImageUrl="~/Imagenes/Cotizar.png" OnClick="btnCotizar_Click" />
                <br />
                <asp:Label ID="lbPrimaFullTitulo" runat="server" Text="Monto de Prima ( " CssClass="Letranegrita2"></asp:Label>
                 <asp:Label ID="lbPrimaFullVariable" runat="server" Text="0" CssClass="Letranegrita2"></asp:Label>
                 <asp:Label ID="lbPrimaFullCerrar" runat="server" Text=")" CssClass="Letranegrita2"></asp:Label>
            </div>
        </div>

        <div id="DIVBloqueAno" runat="server"></div>

        <div id="DIVBloqueTipoVehiculo" runat="server"></div>

        <div id="DIVBloquePorcentaje" runat="server"></div>

        </div>
        <div id="DIVBloqueSegurosLey" visible="false" runat="server"></div>

         
    </div>
</asp:Content>
