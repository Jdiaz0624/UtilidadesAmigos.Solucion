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
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EBuscaHistoricoImpresionMarbetes> BuscaHistoricoImpresionMarbetes(decimal? IdRegistro = null, string Poliza = null, string Item = null, string InicioVigencia = null, string FinVigencia = null, decimal? Cotizacion = null, string NombreCliente = null, string Asegurado = null, string TipoVehiculo = null, string MarcaVehiculo = null, string ModeloVehiculo = null, string Chasis = null, string Placa = null, string Ano = null, string Vendedor = null, int? TipoImpresion = null, string NombreUsuario = null, DateTime? FechaImpresionDesde = null, DateTime? FechaImpresionHasta = null) {
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
        #region MANTENIMIENTO IMPRESION MARBETE RESUMIDO
        //LISTADO MANTENIMIENTO IMPRESION MARBETE RESUMIDO
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EHistoricoImpresionResumido> BuscaHistoricoImpresionMarbeteResumido(decimal? IdUsuario = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_HISTORICO_IMPRESION_MARBETE_RESUMIDO(IdUsuario)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.EHistoricoImpresionResumido
                           {
                               IdUsuario=n.IdUsuario,
                               UsuarioImprime=n.UsuarioImprime,
                               TipoImprecion=n.TipoImprecion,
                               CantidadImpresion=n.CantidadImpresion,
                               CantidadPVC=n.CantidadPVC,
                               CantidadHoja=n.CantidadHoja,
                               TotalImpresiones=n.TotalImpresiones,
                               CantidadMovimientos=n.CantidadMovimientos,

                           }).ToList();
            return Listado;
        }

        //MANTENIMIENTO HISTORIAL IMPRESION MARBETE RESUMIDO
        public UtilidadesAmigos.Logica.Entidades.Procesos.EHistoricoImpresionResumido MantenimientoHistoricoImpresionMarbeteResumido(UtilidadesAmigos.Logica.Entidades.Procesos.EHistoricoImpresionResumido Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.EHistoricoImpresionResumido Mantenimiento = null;

            var ImpresionmarbeteResumido = ObjData.SP_MANTENIMIENTO_HISTORICO_IMPRESION_MARBETE_RESUMIDO(
                Item.IdUsuario,
                Item.IdRegistro,
                Item.UsuarioImprime,
                Item.TipoImprecion,
                Item.CantidadImpresion,
                Item.CantidadPVC,
                Item.CantidadHoja,
                Item.TotalImpresiones,
                Item.CantidadMovimientos,
                Accion);
            if (ImpresionmarbeteResumido != null) {
                Mantenimiento = (from n in ImpresionmarbeteResumido
                                 select new UtilidadesAmigos.Logica.Entidades.Procesos.EHistoricoImpresionResumido
                                 {
                                     IdUsuario = n.IdUsuario,
                                     IdRegistro=n.IdRegistro,
                                     UsuarioImprime=n.UsuarioImprime,
                                     TipoImprecion=n.TipoImprecion,
                                     CantidadImpresion=n.CantidadImpresion,
                                     CantidadPVC=n.CantidadPVC,
                                     CantidadHoja=n.CantidadHoja,
                                     TotalImpresiones=n.TotalImpresiones,
                                     CantidadMovimientos=n.CantidadMovimientos
                                 }).FirstOrDefault();
            }
            return Mantenimiento;
        }
        #endregion
        #region MANTENIMIENTO DE CORREOS EMISORES DE SISTEMA
        //LISTADO DE CORREOS EMISORES DEL SISTEMA
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.ECorreosEmisonesSistema> ListadoCorreosEmisores(int? IdCorreo = null, int? IdProceso = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_INFORMACION_CORREOS_EMISORES_SISTEMA(IdCorreo, IdProceso)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.ECorreosEmisonesSistema
                           {
                               IdCorreo=n.IdCorreo,
                               IdProceso=n.IdProceso,
                               Proceso=n.Proceso,
                               Correo=n.Correo,
                               Clave=n.Clave,
                               Puerto=n.Puerto,
                               SMTP=n.SMTP
                           }).ToList();
            return Listado;
        }

        //MANTENIMIENTO DE CORREOS EMISIONES DEL SISTEMA
        public UtilidadesAmigos.Logica.Entidades.Procesos.ECorreosEmisonesSistema ProcesarCorreosEmisiones(UtilidadesAmigos.Logica.Entidades.Procesos.ECorreosEmisonesSistema Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.ECorreosEmisonesSistema Procesar = null;

            var CorreosEmisores = ObjData.SP_MODIFICAR_CORREOS_EMISORES_SISTEMA(
                Item.IdCorreo,
                Item.IdProceso,
                Item.Correo,
                Item.Clave,
                Item.Puerto,
                Item.SMTP,
                Accion);
            if (CorreosEmisores != null) {
                Procesar = (from n in CorreosEmisores
                            select new UtilidadesAmigos.Logica.Entidades.Procesos.ECorreosEmisonesSistema
                            {
                                IdCorreo=n.IdCorreo,
                                IdProceso=n.IdProceso,
                                Correo=n.Correo,
                                Clave=n.Clave,
                                Puerto=n.Puerto,
                                SMTP=n.SMTP
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
        #region VOLANTES DE PAGOS
        //BUSCAR INFORMACION PARA LOS VOLANTES DE PAGOS
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EBuscarInformacionVolantesPagos> BuscaInformacionVolantesPagos(int? CodigoEmpleado = null, int? Ano = null, byte? Mes = null, int? TipoMovimiento = null, byte? TipoNomina = null, int? NoPago = null, int? CodigoSucursal = null, int? CodigoDepartamento = null,string NombreEmpleado = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCAR_INFORMACION_VOLANTES_PAGOS(CodigoEmpleado, Ano, Mes, TipoMovimiento, TipoNomina, NoPago, CodigoSucursal, CodigoDepartamento, NombreEmpleado)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.EBuscarInformacionVolantesPagos
                           {
                               CodEmpleado=n.CodEmpleado,
                               Ano=n.Ano,
                               Mes=n.Mes,
                               NombreMes=n.NombreMes,
                               TipoMovimiento=n.TipoMovimiento,
                               DescTipoMovimiento=n.DescTipoMovimiento,
                               TipoNomina=n.TipoNomina,
                               DescTipoNomina=n.DescTipoNomina,
                               NoPago=n.NoPago,
                               Sucursal=n.Sucursal,
                               DescSucursal=n.DescSucursal,
                               Departamento=n.Departamento,
                               DescDepto=n.DescDepto,
                               NombreEmpleado=n.NombreEmpleado,
                               Origen=n.Origen,
                               Valor=n.Valor,
                               Ingresos=n.Ingresos,
                               Deducciones=n.Deducciones,
                               TotalIngreso=n.TotalIngreso,
                               TotalDeducciones=n.TotalDeducciones,
                               Total=n.Total
                           }).ToList();
            return Listado;
        }


        //BUSCAR INFORMACION DE LOS EMPLEADOS
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EEMpleados> BuscaInformacionEmpleados(int? CodigoEmpleado = null, string NombreEmpleado = null, int? Sucursar = null, int? Departamento = null, int? Cargo = null, DateTime? FechaIngresoDesde = null, DateTime? FechaIngresoHasta = null, string Estatus = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_EMPLEADOS(CodigoEmpleado, NombreEmpleado, Sucursar, Departamento, Cargo, FechaIngresoDesde, FechaIngresoHasta, Estatus)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.EEMpleados
                           {
                               CodigoEmpleado=n.CodigoEmpleado,
                               Nombre=n.Nombre,
                               Sucursal=n.Sucursal,
                               DescSucursal=n.DescSucursal,
                               Departamento=n.Departamento,
                               DescDepto=n.DescDepto,
                               Cargo=n.Cargo,
                               DescCargo=n.DescCargo,
                               Cedula=n.Cedula,
                               Direccion=n.Direccion,
                               FechaIngreso0=n.FechaIngreso0,
                               FechaIngreso=n.FechaIngreso,
                               Email=n.Email,
                               Email1=n.Email1,
                               Email2=n.Email2,
                               Estatus0=n.Estatus0,
                               Estatus=n.Estatus
                           }).ToList();
            return Listado;
        }

        //BUSCAR LA RUTA DE LOS ACHIVOS GUARDADOS
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.ESacarRutaArchivoGaurdado> SacarRutaArchivosGuardados(decimal? IdArchivo = null) {
            ObjData.CommandTimeout = 999999999;

            var SacarRutaArchivoGuardado = (from n in ObjData.SP_SACAR_RUTA_ARCHIVO_GUARDADO(IdArchivo)
                                            select new UtilidadesAmigos.Logica.Entidades.Procesos.ESacarRutaArchivoGaurdado
                                            {
                                                IdRutaGuardado=n.IdRutaGuardado,
                                                Descripcion=n.Descripcion,
                                                Ruta=n.Ruta
                                            }).ToList();
            return SacarRutaArchivoGuardado;
        }

        //SACAR LAS CREDENCIALES DE BASE DE DATOS
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.ECredencialesBD> SacarCredencialesBD(decimal? IdCredencial = null) {
            ObjData.CommandTimeout = 999999999;

            var SacarInformacion = (from n in ObjData.SP_SACAR_CREDENCIALES_BD(IdCredencial)
                                    select new UtilidadesAmigos.Logica.Entidades.Procesos.ECredencialesBD
                                    {
                                        IdCredencial=n.IdCredencial,
                                        Usuario=n.Usuario,
                                        Clave=n.Clave
                                    }).ToList();
            return SacarInformacion;
        }


        //MODIFICAR LAS CREDENCIALES LAS CREDENCIALES DE BASE DE DATOS
        
        #endregion
    }
}
