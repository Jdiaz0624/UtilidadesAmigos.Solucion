<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PatallaPrincila.Master" AutoEventWireup="true" CodeBehind="ConsultaPersonas.aspx.cs" Inherits="UtilidadesAmigos.Solucion.Paginas.SuperIntendencia.ConsultaPersonas" %>
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

          .BotonEspecoal {
           width:100%;
             font-weight:bold;
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
    </style>

   <div class="container-fluid">
       <div class="jumbotron" align="center">
           <asp:Label ID="lbTituloPantalla" runat="server" Text="CONSULTAR REGISTRO PERSONAS"></asp:Label>
       </div>
       <div class="form-check-inline">
           <div class="form-group form-check">
               
               <asp:RadioButton ID="rbExportarPDF" runat="server" Text="Exportar a PDF" CssClass="form-check-input" GroupName="Exportar" ToolTip="Exportar Informacion a PDF" />
               <asp:RadioButton ID="rbExportarWord" runat="server" Text="Exportar a Word" CssClass="form-check-input" GroupName="Exportar" ToolTip="Exportar Informacion a Word" />
           </div>
       </div>
       <div class="form-row">
           <div class="form-group col-md-4">
               <asp:Label ID="lbConsuktarRNC" runat="server" Text="RNC / Cedula" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtRNCCedula" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
           <div class="form-group col-md-4">
               <asp:Label ID="lbNombre" runat="server" Text="Nombre" CssClass="Letranegrita"></asp:Label>
               <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
           </div>
       </div>
       <div align="center">
           <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ToolTip="Consultar Registros" CssClass="btn btn-outline-secondary btn-sm" />
       </div>

       <br />
       <div align="center">
           <asp:Label ID="lbCantidadRegistrosClienteTitulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosClienteVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosClienteCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
        <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionCobertura" data-toggle="collapse" data-target="#InformacionCliente" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE CLIENTE
                     </button><br />
                <div class="collapse" id="InformacionCliente">
                <div class="card card-body">
                   INFORMACION DE CLIENTE
                   </div>
                </div>
       <br />
        <div align="center">
           <asp:Label ID="lbCantidadIntermediariosSupervisorTitulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadIntermediariosSupervisorVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadIntermediariosSupervisorCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
        <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionIntermediarioSupervisor" data-toggle="collapse" data-target="#InformacionIntermediarioSupervisor" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE INTERMEDIARIO / SUPERVISOR
                     </button><br />
                <div class="collapse" id="InformacionIntermediarioSupervisor">
                <div class="card card-body">
                   INFORMACION DE INTERMEDIARIO / SUPERVISOR
                   </div>
                </div>
       <br />
       <div align="center">
           <asp:Label ID="lbCantidadProveedorTitulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadProveedorVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadProveedorCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
        <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionproveedor" data-toggle="collapse" data-target="#InformacionProveedor" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE PROVEEDOR
                     </button><br />
                <div class="collapse" id="InformacionProveedor">
                <div class="card card-body">
                   INFORMACION DE PROVEEDOR
                   </div>
                </div>
       <br />

        <div align="center">
           <asp:Label ID="lbCantidadRegistrosAseguradoBajoPolizaTitulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosAseguradoBajoPolizaVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosAseguradoBajoPolizaCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
       <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnAseguradoBajoPoliza" data-toggle="collapse" data-target="#InformacionAsegurdoBajoPoliza" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE ASEGURADO BAJO POLIZA
                     </button><br />
                <div class="collapse" id="InformacionAsegurdoBajoPoliza">
                <div class="card card-body">
                   INFORMACION DE ASEGURADO BAJO POLIZA
                   </div>
                </div>
       <br />

       <div align="center">
           <asp:Label ID="lbCantidadRegistrosAseguradoTitulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosAseguradoVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosAseguradoCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
       <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionAsegurado" data-toggle="collapse" data-target="#InformacionAsegurado" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE ASEGURADO 
                     </button><br />
                <div class="collapse" id="InformacionAsegurado">
                <div class="card card-body">
                   INFORMACION DE ASEGURADO 
                   </div>
                </div>
       <br />
        <div align="center">
           <asp:Label ID="lbCantidadRegistrosDependienteTitulo" runat="server" Text="Cantidad de Registros (" CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosDependienteVariable" runat="server" Text=" 0 " CssClass="Letranegrita"></asp:Label>
           <asp:Label ID="lbCantidadRegistrosDependienteCerrar" runat="server" Text=" )" CssClass="Letranegrita"></asp:Label>
       </div>
        <button class="btn btn-outline-primary btn-sm BotonEspecoal" type="button" id="btnInformacionDependiente" data-toggle="collapse" data-target="#InformacionDependiente" aria-expanded="false" aria-controls="collapseExample">
                     INFORMACION DE DEPENDIENTE 
                     </button><br />
                <div class="collapse" id="InformacionDependiente">
                <div class="card card-body">
                   INFORMACION DE DEPENDIENTE 
                   </div>
                </div>
       <br />
   </div>
</asp:Content>
