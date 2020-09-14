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
        #region PROCESAR INFORMACION IMPRESION MARBETES
        public UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarInformacionMarbetes ProcesarImpresionMarbete(UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarInformacionMarbetes Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarInformacionMarbetes Mantenimiento = null;

            var ImpresionMarbete = ObjData.SP_PROCESAR_INFORMACION_MARBETES(
                Item.IdUsuario,
                Item.Poliza,
                Item.Cotizacion,
                Item.CodigoCliente,
                Item.Secuencia,
                Item.NombreCliente,
                Item.InicioVigencia,
                Item.FinVigencia,
                Item.Asegurado,
                Item.TipoVehiculo,
                Item.Marca,
                Item.Modelo,
                Item.Chasis,
                Item.Placa,
                Item.Color,
                Item.Uso,
                Item.Ano,
                Item.Capacidad,
                Item.ValorVehiculo,
                Item.FianzaJudicial,
                Item.Vendedor,
                Item.Grua,
                Item.AeroAmbulancia,
                Item.OtrosServicios,
                Item.CantidadRegistros,
                Accion);
            if (ImpresionMarbete != null) {
                Mantenimiento = (from n in ImpresionMarbete
                                 select new UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarInformacionMarbetes
                                 {
                                     IdUsuario = n.IdUsuario,
                                     Poliza = n.Poliza,
                                     Cotizacion = n.Cotizacion,
                                     CodigoCliente = n.CodigoCliente,
                                     Secuencia = n.Secuencia,
                                     NombreCliente = n.NombreCliente,
                                     InicioVigencia = n.InicioVigencia,
                                     FinVigencia = n.FinVigencia,
                                     Asegurado = n.Asegurado,
                                     TipoVehiculo = n.TipoVehiculo,
                                     Marca = n.Marca,
                                     Modelo = n.Modelo,
                                     Chasis = n.Chasis,
                                     Placa = n.Placa,
                                     Color = n.Color,
                                     Uso = n.Uso,
                                     Ano = n.Ano,
                                     Capacidad = n.Capacidad,
                                     ValorVehiculo = n.ValorVehiculo,
                                     FianzaJudicial = n.FianzaJudicial,
                                     Vendedor = n.Vendedor,
                                     Grua = n.Grua,
                                     AeroAmbulancia = n.AeroAmbulancia,
                                     OtrosServicios = n.OtrosServicios,
                                     CantidadRegistros = n.CantidadRegistros
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion
        #region MANTENIMIENTO DE HISTORICO DE IMPRESION DE MARBETES
        //MANTENIMIENTO DE IMPRESION DE MARBETE
        public UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarHistoricoImprsionMarbete MantenimientoHistoricoImpresionMarbete(UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarHistoricoImprsionMarbete Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarHistoricoImprsionMarbete Procesar = null;

            var HistoricoImpresionMarbete = ObjData.SP_PROCESAR_HISTORICO_IMPRESION_MARBETE(
                Item.IdRegistro,
                Item.Poliza,
                Item.Cotizacion,
                Item.CodigoCliente,
                Item.Secuencia,
                Item.NombreCliente,
                Item.InicioVigencia,
                Item.FinVigencia,
                Item.Asegurado,
                Item.TipoVehiculo,
                Item.MarcaVehiculo,
                Item.ModeloVehiculo,
                Item.Chasis,
                Item.Placa,
                Item.Color,
                Item.uso,
                Item.Ano,
                Item.Capacidad,
                Item.ValorVehiculo,
                Item.FianzaJudicial,
                Item.Vendedor,
                Item.Grua,
                Item.AeroAmbulancia,
                Item.OtrosServicios,
                Item.UsuarioImprime,
                Item.TipoImpresion,
                Item.CantidadImpreso,
                Accion);
            if (HistoricoImpresionMarbete != null) {
                Procesar = (from n in HistoricoImpresionMarbete
                            select new UtilidadesAmigos.Logica.Entidades.Procesos.EProcesarHistoricoImprsionMarbete
                            {
                                IdRegistro=n.IdRegistro,
                                Poliza=n.Poliza,
                                Cotizacion=n.Cotizacion,
                                CodigoCliente=n.CodigoCliente,
                                Secuencia=n.Secuencia,
                                NombreCliente=n.NombreCliente,
                                InicioVigencia=n.InicioVigencia,
                                FinVigencia=n.FinVigencia,
                                Asegurado=n.Asegurado,
                                TipoVehiculo=n.TipoVehiculo,
                                MarcaVehiculo=n.MarcaVehiculo,
                                ModeloVehiculo=n.ModeloVehiculo,
                                Chasis=n.Chasis,
                                Placa=n.Placa,
                                Color=n.Color,
                                uso=n.uso,
                                Ano=n.Ano,
                                Capacidad=n.Capacidad,
                                ValorVehiculo=n.ValorVehiculo,
                                FianzaJudicial=n.FianzaJudicial,
                                Vendedor=n.Vendedor,
                                Grua=n.Grua,
                                AeroAmbulancia=n.AeroAmbulancia,
                                OtrosServicios=n.OtrosServicios,
                                UsuarioImprime=n.UsuarioImprime,
                                TipoImpresion=n.TipoImpresion,
                                CantidadImpreso=n.CantidadImpreso
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
        #region BUSCA HISTORICO IMPRESION MARBETES
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EBuscaHistoricoImpresionMarbetes> BuscaHistoricoImpresionMarbetes(decimal? IdRegistro = null, string Poliza = null, int? Item = null, string InicioVigencia = null, string FinVigencia = null, decimal? Cotizacion = null, string NombreCliente = null, string Asegurado = null, string TipoVehiculo = null, string MarcaVehiculo = null, string ModeloVehiculo = null, string Chasis = null, string Placa = null, string Ano = null, string Vendedor = null, int? TipoImpresion = null, string NombreUsuario = null, DateTime? FechaImpresionDesde = null, DateTime? FechaImpresionHasta = null) {
            ObjData.CommandTimeout = 999999999;

            var Historico = (from n in ObjData.SP_BUSCA_HISTORICO_IMPRESION_MARBETES(IdRegistro, Poliza, Item, InicioVigencia, FinVigencia, Cotizacion, NombreCliente, Asegurado, TipoVehiculo, MarcaVehiculo, ModeloVehiculo, Chasis, Placa, Ano, Vendedor, TipoImpresion, NombreCliente, FechaImpresionDesde, FechaImpresionHasta)
                             select new UtilidadesAmigos.Logica.Entidades.Procesos.EBuscaHistoricoImpresionMarbetes
                             {
                                 IdRegistro=n.IdRegistro,
                                 Poliza=n.Poliza,
                                 Cotizacion=n.Cotizacion,
                                 CodigoCliente=n.CodigoCliente,
                                 Secuencia=n.Secuencia,
                                 NombreCliente=n.NombreCliente,
                                 InicioVigencia=n.InicioVigencia,
                                 FinVigencia=n.FinVigencia,
                                 Asegurado=n.Asegurado,
                                 TipoVehiculo=n.TipoVehiculo,
                                 MarcaVehiculo=n.MarcaVehiculo,
                                 ModeloVehiculo=n.ModeloVehiculo,
                                 Chasis=n.Chasis,
                                 Placa=n.Placa,
                                 Color=n.Color,
                                 uso=n.uso,
                                 Ano=n.Ano,
                                 Capacidad=n.Capacidad,
                                 ValorVehiculo=n.ValorVehiculo,
                                 FianzaJudicial=n.FianzaJudicial,
                                 Vendedor=n.Vendedor,
                                 Grua=n.Grua,
                                 AeroAmbulancia=n.AeroAmbulancia,
                                 OtrosServicios=n.OtrosServicios,
                                 FechaCreado0=n.FechaCreado0,
                                 FechaCreado=n.FechaCreado,
                                 UsuarioImprime=n.UsuarioImprime,
                                 TipoImpresion0=n.TipoImpresion0,
                                 TipoImpresion=n.TipoImpresion,
                                 CantidadImpreso=n.CantidadImpreso,
                                 CandidadImpresionesPVC=n.CandidadImpresionesPVC,
                                 CandidadImpresionesHoja=n.CandidadImpresionesHoja,
                                 CandidadImpresiones=n.CandidadImpresiones,
                                 CandidadRegistros=n.CandidadRegistros
                             }).ToList();
            return Historico;
        } 
        #endregion
    }
}
