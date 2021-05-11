<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="IntermediariosSupervisores.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.IntermediariosSupervisores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style type="text/css">

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

  <div class="container-fluid">
        <div id="DivBloqueConsulta" runat="server">
            <br />
            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Label ID="lbCodigoIntermediarioConsulta" runat="server" Text="Codigo" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtCodigoIntermediarioConsulta" runat="server" MaxLength="4" TextMode="Number" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-4">
                    <asp:Label ID="lbNombreIntermediarioCnsulta" runat="server" Text="Nombre" CssClass="LetrasNegrita"></asp:Label>
                    <asp:TextBox ID="txtNombreIntermediarioConsulta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group col-md-4">
                    <asp:Label ID="lbOficinaConsulta" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                    <asp:DropDownList ID="ddlSeleccionarOficinaConsulta" runat="server" ToolTip="Seleccionar la Oficina para consultar" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
             <div align="center">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Consultar Registros" OnClick="" />
                 <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Crear nuevo registro" OnClick="btnGenerarBackup_Click" />
                 <asp:Button ID="btnModificar" runat="server" Text="Modificar"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Modificar registro seleccionado" OnClick="btnGenerarBackup_Click" />
                 <asp:Button ID="btnComisiones" runat="server" Text="Comisiones"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Mostrar las comisiones del registro seleccionado" OnClick="btnGenerarBackup_Click" />
                 <asp:Button ID="btnRestabelcer" runat="server" Text="Restablecer"  CssClass="btn btn-outline-secondary btn-sm" ToolTip="Restabelcer Pantalla" OnClick="btnGenerarBackup_Click" />
        </div>
    </div>

    <div id="DivBloqueMantenimiento" runat="server">

    </div>
  </div>
</asp:Content>
