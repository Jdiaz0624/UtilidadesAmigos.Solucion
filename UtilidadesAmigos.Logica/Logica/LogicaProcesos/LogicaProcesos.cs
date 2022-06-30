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
        public UtilidadesAmigos.Logica.Entidades.Procesos.ECredencialesBD ModificarCredenciales(UtilidadesAmigos.Logica.Entidades.Procesos.ECredencialesBD Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.ECredencialesBD Modificar = null;

            var Credenciales = ObjData.SP_MODIFICAR_REDENCIALES_BD(
                (int)Item.IdCredencial,
                Item.Usuario,
                Item.Clave,
                Accion);
            if (Credenciales != null) {
                Modificar = (from n in Credenciales
                             select new UtilidadesAmigos.Logica.Entidades.Procesos.ECredencialesBD
                             {
                                 IdCredencial=n.IdCredencial,
                                 Usuario=n.Usuario,
                                 Clave=n.Clave
                             }).FirstOrDefault();
            }
            return Modificar;
        }

        //VALIDAR CODIGOS DE EMPLEADOS PARA ENVIAR VOLANTES DE PAGOS
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.ECodigoEmpleadosVolantePagos> ValidarCodigosEmpleadosVolantePagos(int? CodigoEmpleado = null) {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_VALIDAR_CODIGO_EMPLEADO_VOLANTE_PAGO(CodigoEmpleado)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.ECodigoEmpleadosVolantePagos
                           {
                               IdRegistro = n.IdRegistro,
                               CodigoEmpleado = CodigoEmpleado,
                               Nombre = n.Nombre,
                               Correo = n.Correo,
                               EnvioCorreo0 = n.EnvioCorreo0,
                               EnvioCorreo = n.EnvioCorreo
                           }).ToList();
            return Listado;
        }

        //MODIFICAR LOS CODIGOS DE LOS EMPLEADOS PARA ENVIAR LOS VOLANTES DE PAGOS
        public UtilidadesAmigos.Logica.Entidades.Procesos.ECodigoEmpleadosVolantePagos ModificarCodigosEmpleadosVolantePagos(UtilidadesAmigos.Logica.Entidades.Procesos.ECodigoEmpleadosVolantePagos Item, string Accion) {
            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.ECodigoEmpleadosVolantePagos Modificar = null;

            var CodigosEmpleadosVolantePagos = ObjData.SP_MODIFICAR_CODIGOS_EMPLEADOS_VOLANTE_PAGOS(
                Item.IdRegistro,
                Item.CodigoEmpleado,
                Item.Nombre,
                Item.Correo,
                Item.EnvioCorreo0,
                Accion);
            if (CodigosEmpleadosVolantePagos != null) {
                Modificar = (from n in CodigosEmpleadosVolantePagos
                             select new UtilidadesAmigos.Logica.Entidades.Procesos.ECodigoEmpleadosVolantePagos
                             {
                                 IdRegistro=n.IdRegistro,
                                 CodigoEmpleado=n.CodigoEmpleado,
                                 Nombre=n.Nombre,
                                 Correo=n.Correo,
                                 EnvioCorreo0=n.EnvioCorreo
                             }).FirstOrDefault();

            }
            return Modificar;
        }

        #endregion
        #region UTILIDADES GESTION COBROS
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EBuscaFormaPagoCobros> BuscaPolizaFormaPago(decimal? NumeroRecibo = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_FORMA_PAGO_COBROS(NumeroRecibo)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.EBuscaFormaPagoCobros
                           {
                               Poliza=n.Poliza,
                               Numero_Recibo=n.Numero_Recibo,
                               Fecha_pago=n.Fecha_pago,
                               Fecha=n.Fecha,
                               Tipo=n.Tipo,
                               Monto=n.Monto
                           }).ToList();
            return Listado;
        }

        public UtilidadesAmigos.Logica.Entidades.Procesos.EModificarFormaPago ModificarFormaPago(UtilidadesAmigos.Logica.Entidades.Procesos.EModificarFormaPago Item, string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.EModificarFormaPago Modificar = null;

            var FormaPago = ObjData.SP_MODIFICAR_FORMA_PAGO_RECIBO(
                Item.NumeroRecibo,
                Item.Tipo,
                Accion);
            if (FormaPago != null) {
                Modificar = (from n in FormaPago
                             select new UtilidadesAmigos.Logica.Entidades.Procesos.EModificarFormaPago
                             {
                                   Compania  =n.Compania,
                                   TipoFactura =n.TipoFactura,
                                   Anulado =n.Anulado,
                                   sistema =n.sistema,
                                   tipodocumento = n.tipo_documento,
                                   NumeroRecibo=n.Numero_Recibo,
                                   Fechapago =n.Fecha_pago,
                                   Tipo =n.Tipo,
                                   Monto =n.Monto,
                                   NoDocumento=n.No_Documento, 
                                   NoAprobacion=n.No_Aprobacion,
                                   FechaVencimiento =n.Fecha_Vencimiento,
                                   CodBanco =n.Cod_Banco,
                                   TipoTarjeta =n.Tipo_Tarjeta
                             }).FirstOrDefault();
            }
            return Modificar;
        }
        #endregion

        #region RECLAMACIONES AGREGAR ITEMS
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EBuscaDatoReclamacionesAgregarItems> BuscaDatosReclamacionesAgregarItems(string Poliza = null,decimal? NumeroReclamo = null,int? Secuencia=null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_DATO_RECLAMACION_AGREGAR_ITEMS(Poliza,NumeroReclamo,Secuencia)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.EBuscaDatoReclamacionesAgregarItems
                           {
                               Poliza=n.Poliza,
                               Reclamacion=n.Reclamacion,
                               Secuencia=n.Secuencia,
                               IdTipoReclamacion=n.IdTipoReclamacion,
                               TipoReclamacion=n.TipoReclamacion,
                               IdReclamante=n.IdReclamante,
                               Reclamante=n.Reclamante
                           }).ToList();
            return Listado;
        }

        public List<UtilidadesAmigos.Logica.Entidades.Procesos.ESacarNombreReclamante> SacarNombreReclamante(decimal? CodigoReclamante = null) {

            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCAR_NOMBRE_RECLAMANTE(CodigoReclamante)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.ESacarNombreReclamante
                           {
                               Codigo=n.Codigo,
                               NombreReclamante=n.NombreReclamante
                           }).ToList();
            return Listado;
        }

        public UtilidadesAmigos.Logica.Entidades.Procesos.AgregarEditarEliminarItemsReclamos ProcesarItemsReclamaciones(UtilidadesAmigos.Logica.Entidades.Procesos.AgregarEditarEliminarItemsReclamos Item,string Accion) {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.AgregarEditarEliminarItemsReclamos AgregarModificarEliminar = null;

            var ItemsReclamaciones = ObjData.SP_AGREGAR_EDITAR_ELIMINAR_ITEMS_RECLAMACIONES(
                Item.Reclamacion,
                Item.Secuencia,
                Item.IdReclamante,
                Item.IdTipoReclamacion,
                Accion);
            if (ItemsReclamaciones != null) {
                AgregarModificarEliminar = (from n in ItemsReclamaciones
                                            select new UtilidadesAmigos.Logica.Entidades.Procesos.AgregarEditarEliminarItemsReclamos
                                            {
                                                  Compania =n.Compania,
                                                  Reclamacion = n.Reclamacion,
                                                  Secuencia = n.Secuencia,
                                                  IdTipoReclamacion = n.IdTipoReclamacion,
                                                  IdReclamante = n.IdReclamante,
                                                  MontoReclamado = n.MontoReclamado,
                                                  MontoAjustado = n.MontoAjustado,
                                                  MontoReserva = n.MontoReserva,
                                                  MontoDeducible = n.MontoDeducible,
                                                  UsuarioAdiciona = n.UsuarioAdiciona,
                                                  FechaAdiciona = n.FechaAdiciona,
                                                  UsuarioModifica = n.UsuarioModifica,
                                                  FechaModifica = n.FechaModifica,
                                                  Estatus = n.Estatus,
                                                  IdEjecutivoReclamacion = n.IdEjecutivoReclamacion
                                            }).FirstOrDefault();
            }
            return AgregarModificarEliminar;


        }
        #endregion

        #region MANTENIMIENTO DE RECIBOS DIGITALES
        /// <summary>
        /// Este metodo muestra el listado de los recibos registrados en la base de datos
        /// </summary>
        /// <param name="NumeroRecibo"></param>
        /// <param name="CodigoIntermediario"></param>
        /// <param name="CodigoSupervisor"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="IdTipoPago"></param>
        /// <returns></returns>
        public List<UtilidadesAmigos.Logica.Entidades.Procesos.EReciboDigital> BuscaReciboDigital(decimal? NumeroRecibo = null, int? CodigoIntermediario = null, int? CodigoSupervisor = null, DateTime? FechaDesde = null, DateTime? FechaHasta = null, int? IdTipoPago = null, int? Oficina = null, decimal? GeneradoPor = null)
        {
            ObjData.CommandTimeout = 999999999;

            var Listado = (from n in ObjData.SP_BUSCA_INFORMACION_RECIBO_DIGITAL(NumeroRecibo, CodigoIntermediario, CodigoSupervisor, FechaDesde, FechaHasta, IdTipoPago, Oficina, GeneradoPor)
                           select new UtilidadesAmigos.Logica.Entidades.Procesos.EReciboDigital
                           {
                               NumeroRecibo = n.NumeroRecibo,
                               CodigoIntermediario = n.CodigoIntermediario,
                               Intermediario = n.Intermediario,
                               CodigoSupervisor = n.CodigoSupervisor,
                               NombreIntermediario = n.Intermediario,
                               FechaRecibo0 = n.FechaRecibo0,
                               Fecha = n.Fecha,
                               Hora = n.Hora,
                               ValorRecibo = n.ValorRecibo,
                               ValorReciboLetra=n.ValorReciboLetra,
                               IdTipoPago = n.IdTipoPago,
                               TipoPago = n.TipoPago,
                               Detalle = n.Detalle,
                               CreadoPor = n.CreadoPor,
                               CreadoPor0 = n.CreadoPor0,
                               IdOficina=(int)n.IdOficina,
                               Oficina=n.Oficina,
                               GeneradoPor = n.GeneradoPor,
                               TotalEfectivo=n.TotalEfectivo,
                               TotalTransferencia=n.TotalTransferencia,
                               TotalDeposito=n.TotalDeposito,
                               TotalCheque=n.TotalCheque,
                               TotalOtro=n.TotalOtro
                           }).ToList();
            return Listado;
        }

        /// <summary>
        /// Este metodo procesa los recibos digitales
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Accion"></param>
        /// <returns></returns>
        public UtilidadesAmigos.Logica.Entidades.Procesos.EReciboDigital ProcesarReciboDigital(UtilidadesAmigos.Logica.Entidades.Procesos.EReciboDigital Item, string Accion)
        {

            ObjData.CommandTimeout = 999999999;

            UtilidadesAmigos.Logica.Entidades.Procesos.EReciboDigital Procesar = null;

            var ReciboDigital = ObjData.SP_PROCESAR_RECIBO_DIGITAL(
                Item.NumeroRecibo,
                Item.CodigoIntermediario,
                Item.ValorRecibo,
                Item.IdTipoPago,
                Item.Detalle,
                Item.CreadoPor0,
                (int)Item.IdOficina,
                Accion);
            if (ReciboDigital != null)
            {

                Procesar = (from n in ReciboDigital
                            select new UtilidadesAmigos.Logica.Entidades.Procesos.EReciboDigital
                            {
                                NumeroRecibo = n.NumeroRecibo,
                                CodigoIntermediario = n.CodigoIntermediario,
                                FechaRecibo0 = n.FechaRecibo,
                                ValorRecibo = n.ValorRecibo,
                                IdTipoPago = n.IdTipoPago,
                                Detalle = n.Detalle,
                                CreadoPor0 = n.CreadoPor,
                                IdOficina=n.Oficina
                            }).FirstOrDefault();
            }
            return Procesar;
        }
        #endregion
    }
}
