using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaSuperIntendencia
{
    public class LogicaSuperIntendencia
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDSuperIntendenciaConexionDataContext ObjData = new Data.Conexiones.LINQ.BDSuperIntendenciaConexionDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        //BUSCAR REGISTROS CLIENTE
        public List<UtilidadesAmigos.Logica.Entidades.SuperIntendencia.EBuscaPersonasSuperIntendencia> BuscaPersonasSuperIntendenciaCliente(string NumeroIdentificacion = null, string Nombre = null, string Chasis = null, string Placa = null, int? Ramo = null, string Poliza =null, decimal? Cotizacion = null, decimal? Secuencia = null, int? ReportePreciso = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_REGISTROS_SUPER_INTENDENCIA_CLIENTE(NumeroIdentificacion, Nombre, Chasis, Placa, Ramo, Poliza, Cotizacion,Secuencia, ReportePreciso)
                           select new UtilidadesAmigos.Logica.Entidades.SuperIntendencia.EBuscaPersonasSuperIntendencia
                           {
                               Nombre=n.Nombre,
                               NumeroIdentificacion=n.NumeroIdentificacion,
                               EmpresaLabora=n.EmpresaLabora,
                               RNCEmpresaLabora=n.RNCEmpresaLabora,
                               NombreVendedor=n.NombreVendedor,
                               RNCIntermediario=n.RNCIntermediario,
                               LicenciaSeguro=n.LicenciaSeguro,
                               Ramo=n.Ramo,
                               TipoVehiculo=n.TipoVehiculo,
                               Marca=n.Marca,
                               Modelo=n.Modelo,
                               Ano=n.Ano,
                               Placa=n.Placa,
                               Chasis=n.Chasis,
                               Color=n.Color,
                               MontoAsegurado=n.MontoAsegurado,
                               poliza=n.poliza,
                               Cotizacion=n.Cotizacion,
                               Secuencia=n.Secuencia,
                               CodRamo=n.CodRamo,
                               Prima=n.Prima,
                               FechaInicioVigencia=n.FechaInicioVigencia,
                               InicioVigencia=n.InicioVigencia,
                               FechaFinVigencia=n.FechaFinVigencia,
                               FinVigencia=n.FinVigencia
                           }).ToList();
            return Listado;
        }

        //BUSCAR REGISTROS INTERMEDIARIO
        public List<UtilidadesAmigos.Logica.Entidades.SuperIntendencia.EBuscaPersonasSuperIntendenciaIntermediario> BuscaPersonasSuperIntendenciaIntermediario(int? Codigo = null, string NumeroIdentificacion = null, string Nombre = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_REGISTROS_SUPER_INTENDENCIA_INTERMEDIARIO(Codigo, NumeroIdentificacion, Nombre)
                           select new UtilidadesAmigos.Logica.Entidades.SuperIntendencia.EBuscaPersonasSuperIntendenciaIntermediario
                           {
                               Codigo=n.Codigo,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus,
                               TipoRnc=n.TipoRnc,
                               TipoIdentificacion=n.TipoIdentificacion,
                               Rnc=n.Rnc,
                               Supervisor=n.Supervisor,
                               Nombre=n.Nombre,
                               Fecha_Entrada=n.Fecha_Entrada,
                               FechaEntrada=n.FechaEntrada,
                               Fec_Nac=n.Fec_Nac,
                               FechaNacimiento = n.FechaNacimiento,
                               Direccion=n.Direccion,
                               Telefono=n.Telefono,
                               TelefonoOficina=n.TelefonoOficina,
                               Celular=n.Celular,
                               LicenciaSeguro=n.LicenciaSeguro,
                               Oficina=n.Oficina,
                               NombreOficina=n.NombreOficina,
                               CtaBanco=n.CtaBanco,
                               Banco=n.Banco,
                               TipoPago=n.TipoPago,

                           }).ToList();
            return Listado;
        }

        //BUSCAR REGISTROS PROBEEDORES
        public List<UtilidadesAmigos.Logica.Entidades.SuperIntendencia.EBuscaPersonaProveedor> BuscaPersonaSuperIntendenciaProveedor(int? Codigo = null, string Nombre = null, string NumeroIdentificacion = null) {
            ObjData.CommandTimeout = 999999999;

            var Buscar = (from n in ObjData.SP_BUSCA_REGISTRO_SUPER_INTENDENCIA_PROVEEDOR(Codigo, Nombre, NumeroIdentificacion)
                          select new UtilidadesAmigos.Logica.Entidades.SuperIntendencia.EBuscaPersonaProveedor
                          {
                              Codigo=n.Codigo,
                              TipoCliente0=n.TipoCliente0,
                              TipoCliente=n.TipoCliente,
                              TipoRnc=n.TipoRnc,
                              TipoIdentificacion=n.TipoIdentificacion,
                              Rnc=n.Rnc,
                              NombreCliente=n.NombreCliente,
                              Direccion=n.Direccion,
                              FechaAdiciona=n.FechaAdiciona,
                              FechaCreado=n.FechaCreado,
                              TelefonoCasa=n.TelefonoCasa,
                              TelefonoOficina=n.TelefonoOficina,
                              Celular=n.Celular,
                              CuentaBanco=n.CuentaBanco,
                              Banco=n.Banco,
                              TipoCuentaBanco=n.TipoCuentaBanco,
                              ClaseProveedor=n.ClaseProveedor,
                              FechaUltPago0=n.FechaUltPago0,
                              FechaUltPago=n.FechaUltPago,
                              LimiteCredito=n.LimiteCredito,
                              ToTalPagado=n.ToTalPagado,
                              CantidadSolicitud=n.CantidadSolicitud,
                              CantidadSolicitudCanceladas=n.CantidadSolicitudCanceladas,
                              UltimaFechaSolicitud=n.UltimaFechaSolicitud,
                              NoSolicitud=n.NoSolicitud,
                              DescripcionTipoSolicitud=n.DescripcionTipoSolicitud,
                              Valor=n.Valor,
                              NumeroCheque=n.NumeroCheque,
                              FechaCheque=n.FechaCheque,
                              Usuario=n.Usuario,
                              Concepto1=n.Concepto1,
                              Concepto2=n.Concepto2
                          }).ToList();
            return Buscar;
        }
    }
}
