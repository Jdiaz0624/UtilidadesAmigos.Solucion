using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaTransito
{
    public class LogicaTransito
    {

        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionTransitoDataContext ObjData = new Data.Conexiones.LINQ.BDConexionTransitoDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region MARBETE DE POLIZAS EN TRANSITO
        /// <summary>
        /// Muestra la Información de las Polizas que estan en transito, para generar el marbete
        /// </summary>
        /// <param name="Poliza"></param>
        /// <param name="Item"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="Supervisor"></param>
        /// <param name="Intermediario"></param>
        /// <param name="Oficina"></param>
        /// <param name="PolizaImpresa"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Transito.EMarbeteTransito> GenerarMarbeteTransito(string Poliza = null, int? Item = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? Supervisor = null, int? Intermediario = null, int? Oficina = null, string PolizaImpresa = null, string Usuario = null)
        {

            ObjData.CommandTimeout = 999999999;

            var Informacion = (from n in ObjData.SP_GENERAR_MARBETE_VEHICULO_TRANSITO(Poliza, Item, FechaDesde, FechaHasta, Supervisor, Intermediario, Oficina, PolizaImpresa, Usuario)
                               select new UtilidadesAmigos.Logica.Entidades.Transito.EMarbeteTransito
                               {
                                   Poliza = n.Poliza,
                                   ValorAnual = n.ValorAnual,
                                   FechaFacturacion = n.FechaFacturacion,
                                   Fecha = n.Fecha,
                                   Hora = n.Hora,
                                   UsuarioAdiciona = n.UsuarioAdiciona,
                                   Oficina = n.Oficina,
                                   NombreOficina = n.NombreOficina,
                                   ConceptoMov = n.ConceptoMov,
                                   Cliente = n.Cliente,
                                   CodigoIntermediario = n.CodigoIntermediario,
                                   Intermediario = n.Intermediario,
                                   CodigoSupervisor = n.CodigoSupervisor,
                                   Supervisor = n.Supervisor,
                                   TipoVehiculo = n.TipoVehiculo,
                                   Marca = n.Marca,
                                   Modelo = n.Modelo,
                                   Chasis = n.Chasis,
                                   Placa = n.Placa,
                                   NumeroItem = n.NumeroItem,
                                   Color = n.Color,
                                   Uso = n.Uso,
                                   Ano = n.Ano,
                                   Asegurado = n.Asegurado,
                                   FianzaJudicial = n.FianzaJudicial,
                                   InicioVigencia = n.InicioVigencia,
                                   FinVigencia = n.FinVigencia,
                                   Grua = n.Grua,
                                   TelefonoGrua = n.TelefonoGrua,
                                   InformacionGrua = n.InformacionGrua,
                                   Servicios = n.Servicios,
                                   TelefonoServicios = n.TelefonoServicios,
                                   InformacionServicios = n.InformacionServicios,
                                   Impresa = n.Impresa,
                                   CantidadImpresiones = n.CantidadImpresiones
                               }).ToList();
            return Informacion;
        }
        #endregion
    }
}
