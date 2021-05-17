<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="VolantesDePagos.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.Procesos.VolantesDePagos" %>
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

    <br />
    <div class="container-fluid">
        <div id="DivBloqueProceso" runat="server">
        <div class="form-row">
            <div class="form-group col-md-2">
                <asp:Label ID="lbCodigoEmpleado" runat="server" Text="Codigo de Empleado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtCodigoEmpleado" runat="server" CssClass="form-control" Placeholder="Opcional" TextMode="Number"></asp:TextBox>
            </div>

             <div class="form-group col-md-6">
                <asp:Label ID="lbNombreEmpleado" runat="server" Text="Nombre de Empleado" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtNombreEmpleado" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionaroficina" runat="server" Text="Oficina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlSeleccionaroficina" runat="server" CssClass="form-control" ToolTip="Seleccionar la Oficina correspondiente para el filtro"></asp:DropDownList>
            </div>

              <div class="form-group col-md-4">
                <asp:Label ID="lbSeleccionarTipoNomina" runat="server" Text="Tipo de Nomina" CssClass="LetrasNegrita"></asp:Label>
                <asp:DropDownList ID="ddlTipoNomina" runat="server" CssClass="form-control" Enabled="false" ToolTip="Seleccionar El tipo de Nomina"></asp:DropDownList>
            </div>

            <div class="form-group col-md-2">
                <asp:Label ID="lbAno" runat="server" Text="Año" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtAno" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

             <div class="form-group col-md-2">
                <asp:Label ID="lbMes" runat="server" Text="Mes" CssClass="LetrasNegrita"></asp:Label>
                <asp:TextBox ID="txtMes" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-check-inline">
            
            <div class="form-group form-check">
                <asp:Label ID="lbTipoNominaLetrero" runat="server" Text="Seleccionar Tipo de Nomina" CssClass="LetrasNegrita"></asp:Label><br />
                 <asp:RadioButton ID="rbPrimeraQuincena" runat="server" Text="Primera Quincena" CssClass="form-check-input" GroupName="TipoNomina" />
                 <asp:RadioButton ID="rbSegundaQuincena" runat="server" Text="Segunda Quincena" CssClass="form-check-input" GroupName="TipoNomina" />
            </div>
           
        </div>
    </div>
    </div>

</asp:Content>
