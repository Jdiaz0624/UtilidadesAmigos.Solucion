<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="GenerarMarbetes.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.GenerarMarbetes" %>
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
            <asp:Label ID="lbTituloGenerarMarbetes" runat="server" Text="GENERAR MARBETES"></asp:Label>
        </div>
        <div align="center">
            <asp:Label ID="lbSeleccionarFiltros" runat="server" Text="Seleccionar Filtros" CssClass="Letranegrita"></asp:Label><br />
            <div class="form-check-inline">
                <div class="form-group form-check">
                    <asp:CheckBox ID="cbOtrosFiltros" runat="server" Text="Buscar por Chasis o Placa" AutoPostBack="true" CssClass="form-check-input Letranegrita" />
                    <asp:RadioButton ID="rbBuscarPorChasis" runat="server" Text="Buscar por Chasis" GroupName="OtrosFiltros" CssClass="form-check-input Letranegrita" />
                    <asp:RadioButton ID="rbBuscarPorPlaca" runat="server" Text="Buscar por Placa" GroupName="OtrosFiltros" CssClass="form-check-input Letranegrita" />

                </div>
            </div><br />
            <div class="form-check-inline">
                <div class="form-group form-check">
                     <asp:RadioButton ID="rbMarbetePVC" runat="server" Text="Solo Marbete PVC" GroupName="TipoMarbete" CssClass="form-check-input Letranegrita" />
                    <asp:RadioButton ID="rbMarbeteHoja" runat="server" Text="Solo Marbete Hoja" GroupName="TipoMarbete" CssClass="form-check-input Letranegrita" />
                    <asp:RadioButton ID="rbTodosMarbetes" runat="server" Text="Ambos" GroupName="TipoMarbete" CssClass="form-check-input Letranegrita" />
                </div>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label ID="lbPolizaConsulta" runat="server" Text="Poliza" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPolizaConsulta" MaxLength="50" CssClass="form-control" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbItemConsulta" runat="server" Text="Item" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtItemConsulta" TextMode="Number" MaxLength="50" AutoCompleteType="Disabled" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbChasisConsulta" runat="server" Text="Chasis" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtChasisConsulta" AutoCompleteType="Disabled" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="lbPlacaConsulta" runat="server" Text="Placa" CssClass="Letranegrita"></asp:Label>
                <asp:TextBox ID="txtPlacaConsulta" AutoCompleteType="Disabled" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
