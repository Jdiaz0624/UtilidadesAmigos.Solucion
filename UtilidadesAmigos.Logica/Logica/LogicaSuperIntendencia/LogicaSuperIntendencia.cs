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
    }
}
