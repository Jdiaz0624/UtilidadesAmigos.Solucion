<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ProcesarDataAsegurado.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.ProcesarDataAsegurado" %>
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


    <div class="jumbotron">
        <div align="Center">
            <asp:Label ID="lbTituloMantenimiento" runat="server" Text="Procesar Data Asegura.do"></asp:Label>
        </div>
    </div>

    <div class="container-fluid">
        <div align="center">
            <asp:Label ID="lbSelecionarOperacionTitulo" runat="server" Text="Seleccionar Operación" CssClass="Letranegrita"></asp:Label>
            <br /><br />
          
                <div class="form-group form-check">
                    <div class="form-check-inline">
                        <asp:RadioButton ID="rbEmosiones" runat="server" Text="Emisiones" AutoPostBack="true" GroupName="DataAsegurado" ToolTip="Procesar las emisiones" CssClass="form-check-input" />
                        <asp:RadioButton ID="rbModificaciones" runat="server" Enabled="false" AutoPostBack="true" Text="Modificaciones" GroupName="DataAsegurado" ToolTip="Procesar las Modificaciones" CssClass="form-check-input" />
                        <asp:RadioButton ID="rbCancelaciones" runat="server" Enabled="false" AutoPostBack="true" Text="Cancelaciones" GroupName="DataAsegurado" ToolTip="Procesar las Cancelaciones de los archivos" CssClass="form-check-input" />
                        <asp:RadioButton ID="rbPAgos" runat="server" Text="Pagos" GroupName="DataAsegurado" AutoPostBack="true" ToolTip="Procesar los pagos de los archivos" CssClass="form-check-input" />
                    </div>
                </div>
             <asp:TextBox ID="txtRutaarchivo" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscarRuta" runat="server" Text="Buscar Ruta" ToolTip="Buscar la ruta del archivo" OnClick="btnBuscarRuta_Click" />
          
            <asp:FileUpload ID="FileUpload1"  runat="server" />

            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
          
        </div>
    </div>
</asp:Content>
