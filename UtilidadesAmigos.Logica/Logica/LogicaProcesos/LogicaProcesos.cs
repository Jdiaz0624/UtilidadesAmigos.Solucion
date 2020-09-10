using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesAmigos.Logica.Logica.LogicaProcesos
{
    public class LogicaProcesos
    {
        UtilidadesAmigos.Data.Conexiones.LINQ.BDConexionProcesosDataContext ObjData = new Data.Conexiones.LINQ.BDConexionProcesosDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["UtilidadesAmigosConexion"].ConnectionString);

        #region GENERAR DATOS PARA MARBETE VEHICULO
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EGenerarDatosMarbeteVehiculo> GenerarDatosParaMarbeteVehiculos(string Poliza = null, string Item = null, string Chasis = null, string Placa = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_GENERAR_DATOS_PARA_MARBETE_VEHICULO(Poliza, Item, Chasis, Placa)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.EGenerarDatosMarbeteVehiculo
                           {
                               Poliza=n.Poliza,
                               Cotizacion=n.Cotizacion,
                               CodigoCliente=n.CodigoCliente,
                               Secuencia=n.Secuencia,
                               NombreCliente=n.NombreCliente,
                               InicioVigencia=n.InicioVigencia,
                               FinVigencia=n.FinVigencia,
                               Asegurado=n.Asegurado,
                               TipoVehiculo=n.TipoVehiculo,
                               Marca=n.Marca,
                               Modelo=n.Modelo,
                               Chasis=n.Chasis,
                               Placa=n.Placa,
                               Color=n.Color,
                               Uso=n.Uso,
                               Ano=n.Ano,
                               Capacidad=n.Capacidad,
                               ValorVehiculo=n.ValorVehiculo,
                               FianzaJudicial=n.FianzaJudicial,
                               Vendedor=n.Vendedor,
                               Grua=n.Grua,
                               AeroAmbulancia=n.AeroAmbulancia,
                               OtrosServicios=n.OtrosServicios,
                               CantidadRegistros=n.CantidadRegistros
                           }).ToList();
            return Listado;
        }
        #endregion
    }
}
