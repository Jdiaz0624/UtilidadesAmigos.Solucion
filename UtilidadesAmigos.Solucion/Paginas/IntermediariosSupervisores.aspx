<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="IntermediariosSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.IntermediariosSupervisores" %>
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

        .Letranegrita {
        font-weight:bold;
        }
    </style>

    <div class="container-fluid">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbTitulo" runat="server" Text="Mantenimiento Intermediario / Supervisor"></asp:Label>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbCodigoIntermediario" runat="server" Text="Codigo de Intermediario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoIntermediarioCosulta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbNombreIntermediario" runat="server" Text="Nombre Intermediario" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtNombreIntermediarioCOnsulta" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="lbSelecionarOficina" runat="server" Text="Oficina" CssClass="Letranegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionarOficinaConsulta" runat="server" ToolTip="Seleccionar Oficina" CssClass="form-control"></asp:DropDownList>
            </div>
        </div><br />
        <div align="center">
            <asp:Button ID="btnCOnsultarRegistros" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-primary btn-sm"/>
            <button type="button" id="btnNuevo" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoIntermediario">Nuevo</button>
            <button type="button" id="btnModificar" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".MantenimientoIntermediario">Editar</button>
            <button type="button" id="btnComisiones" class="btn btn-outline-primary btn-sm Custom" data-toggle="modal" data-target=".ComisionesIntermediario">Comisiones</button>
        </div>
        <br />
     


        <br />
    </div>

    <!--POPOP DE INTERMEDIARIOS-->
     <div class="modal fade bd-example-modal-lg MantenimientoIntermediario" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="lbEncabezadoMantenimiento" runat="server" Text="Mantenimiento de Intermediario"></asp:Label>
        </div>
        <!--CONTROLES-->
    </div>
  </div>
</div>

    <!--POPOP DE COMISIONES-->
     <div class="modal fade bd-example-modal-lg ComisionesIntermediario" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
        <div class="jumbotron" align="center">
            <asp:Label ID="Label1" runat="server" Text="Mantenimiento de Comisiones de Intermediarios"></asp:Label>
        </div>
        <!--CONTROLES-->
    </div>
  </div>
</div>
</asp:Content>
